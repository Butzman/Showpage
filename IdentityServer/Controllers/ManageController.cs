using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using IdentityServer.Models;
using IdentityServer.Models.ManageViewModels;
using IdentityServer.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace IdentityServer.Controllers
{
    [Authorize]
    public class ManageController: Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ILogger<ManageController> _logger;
        private readonly IStringLocalizer _sharedLocalizer;

        public ManageController(UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            ILogger<ManageController> logger,
            IStringLocalizerFactory factory)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
           
            
            var type = typeof(SharedResource);
            var assemblyName = new AssemblyName(type.GetTypeInfo().Assembly.FullName!);
            _sharedLocalizer = factory.Create("SharedResource", assemblyName.Name);
        }
        
        [TempData]
        public string StatusMessage { get; set; }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound(_sharedLocalizer["USER_NOTFOUND", _userManager.GetUserId(User)]);
            }

            var model = new IndexViewModel
            {
                Username = user.UserName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                IsEmailConfirmed = user.EmailConfirmed,
                StatusMessage = StatusMessage
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(IndexViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound(_sharedLocalizer["USER_NOTFOUND", _userManager.GetUserId(User)]);
            }

            var email = user.Email;
            if (model.Email != email)
            {
                var setEmailResult = await _userManager.SetEmailAsync(user, model.Email);
                if (!setEmailResult.Succeeded)
                {
                    throw new ApplicationException($"Unexpected error occurred setting email for user with ID '{user.Id}'.");
                }
            }

            var phoneNumber = user.PhoneNumber;
            if (model.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, model.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    throw new ApplicationException($"Unexpected error occurred setting phone number for user with ID '{user.Id}'.");
                }
            }

            StatusMessage = _sharedLocalizer["STATUS_MESSAGE_PROFILE_HAS_BEEN_RESET"];
            return RedirectToAction(nameof(Index));
        }
        
        [HttpGet]
        public async Task<IActionResult> ChangePassword()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound(_sharedLocalizer["USER_NOTFOUND", _userManager.GetUserId(User)]);
            }

            var hasPassword = await _userManager.HasPasswordAsync(user);
            if (!hasPassword)
            {
                return RedirectToAction(nameof(SetPassword));
            }

            var model = new ChangePasswordViewModel { StatusMessage = StatusMessage };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel passwordViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(passwordViewModel);
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound(_sharedLocalizer["USER_NOTFOUND", _userManager.GetUserId(User)]);
            }

            var changePasswordResult = await _userManager.ChangePasswordAsync(user, passwordViewModel.OldPassword, passwordViewModel.NewPassword);
            if (!changePasswordResult.Succeeded)
            {
                AddErrors(changePasswordResult);
                return View(passwordViewModel);
            }

            await _signInManager.SignInAsync(user, isPersistent: false);
            _logger.LogInformation("User changed their password successfully.");
            StatusMessage = _sharedLocalizer["CHANGE_PASSWORD_STATUS"];

            return RedirectToAction(nameof(ChangePassword));
        }

        
        [HttpGet]
        public async Task<IActionResult> SetPassword()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound(_sharedLocalizer["USER_NOTFOUND", _userManager.GetUserId(User)]);
            }

            var hasPassword = await _userManager.HasPasswordAsync(user);

            if (hasPassword)
            {
                return RedirectToAction(nameof(ChangePassword));
            }

            var model = new SetPasswordViewModel { StatusMessage = StatusMessage };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SetPassword(SetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound(_sharedLocalizer["USER_NOTFOUND", _userManager.GetUserId(User)]);
            }

            var addPasswordResult = await _userManager.AddPasswordAsync(user, model.NewPassword);
            if (!addPasswordResult.Succeeded)
            {
                AddErrors(addPasswordResult);
                return View(model);
            }

            await _signInManager.SignInAsync(user, isPersistent: false);
            StatusMessage = _sharedLocalizer["SET_PASSWORD_STATUS"];

            return RedirectToAction(nameof(SetPassword));
        }
        
        
        [HttpGet]
        public async Task<IActionResult> PersonalData()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound(_sharedLocalizer["USER_NOTFOUND", _userManager.GetUserId(User)]);
            }

            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DownloadPersonalData()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound(_sharedLocalizer["USER_NOTFOUND", _userManager.GetUserId(User)]);
            }

            _logger.LogInformation("User with ID '{UserId}' asked for their personal data.", _userManager.GetUserId(User));

            // Only include personal data for download
            var personalDataProps = typeof(IdentityUser).GetProperties().Where(
                            prop => Attribute.IsDefined(prop, typeof(PersonalDataAttribute)));
            var personalData = personalDataProps.ToDictionary(p => p.Name, p => p.GetValue(user)?.ToString() ?? "null");

            Response.Headers.Add("Content-Disposition", "attachment; filename=PersonalData.json");
            return new FileContentResult(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(personalData)), "text/json");
        }

        [HttpGet]
        public async Task<IActionResult> DeletePersonalData()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound(_sharedLocalizer["USER_NOTFOUND", _userManager.GetUserId(User)]);
            }

            var deletePersonalDataViewModel = new DeletePersonalDataViewModel();
            deletePersonalDataViewModel.RequirePassword = await _userManager.HasPasswordAsync(user);
            return View(deletePersonalDataViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePersonalData(DeletePersonalDataViewModel deletePersonalDataViewModel)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound(_sharedLocalizer["USER_NOTFOUND", _userManager.GetUserId(User)]);
            }

            deletePersonalDataViewModel.RequirePassword = await _userManager.HasPasswordAsync(user);
            if (deletePersonalDataViewModel.RequirePassword)
            {
                if (!await _userManager.CheckPasswordAsync(user, deletePersonalDataViewModel.Password))
                {
                    ModelState.AddModelError(string.Empty, _sharedLocalizer["INCORRECT_PASSWORD"]);
                    return View(deletePersonalDataViewModel);
                }
            }

            var result = await _userManager.DeleteAsync(user);
            var userId = await _userManager.GetUserIdAsync(user);
            if (!result.Succeeded)
            {
                throw new InvalidOperationException($"Unexpected error occurred deleteing user with ID '{userId}'.");
            }

            await _signInManager.SignOutAsync();

            _logger.LogInformation("User with ID '{UserId}' deleted themselves.", userId);

            return Redirect("~/");
        }
        
        
        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

    }
}