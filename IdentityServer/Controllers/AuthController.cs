using System.Security.Claims;
using System.Threading.Tasks;
using IdentityServer.Models;
using IdentityServer.Models.AuthViewModels;
using IdentityServer.Resources;
using IdentityServer.Services;
using IdentityServer4.Extensions;
using IdentityServer4.Models;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityServer.Controllers
{
    public class AuthController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IIdentityServerInteractionService _identityServerInteractionService;
        private readonly IMailerService _mailerService;
        private readonly IIdentityServerInteractionService _interaction;

        public AuthController(
            SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userManager,
            IIdentityServerInteractionService identityServerInteractionService,
            IMailerService mailerService,
            IIdentityServerInteractionService interaction)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _identityServerInteractionService = identityServerInteractionService;
            _mailerService = mailerService;
            _interaction = interaction;
        }

        [HttpGet]
        public IActionResult Register(string returnUrl)
        {
            return View(new RegisterViewModel {ReturnUrl = returnUrl});
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (!ModelState.IsValid)
                return View(registerViewModel);

            var user = new IdentityUser(registerViewModel.Username);
            var result = await _userManager.CreateAsync(user, registerViewModel.Password);

            if (result.Succeeded)
                return RedirectToAction("SendEmailVerification", new SendEmailVerificationViewModel {Email = registerViewModel.Email, Username = user.UserName});
            
            return View();
        }

        public async Task<IActionResult> VerifyEmail(string userId, string code)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null) return BadRequest();

            var result = await _userManager.ConfirmEmailAsync(user, code);

            if (result.Succeeded)
            {
                return View();
            }

            return BadRequest();
        }

        public async Task<IActionResult> SendEmailVerification(SendEmailVerificationViewModel viewModel)
        {
            var user = await _userManager.FindByNameAsync(viewModel.Username);

            if (user == null)
                return View("Error");

            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);

            var link = Url.Action(nameof(VerifyEmail), "Auth", new {userId = user.Id, code}, Request.Scheme, Request.Host.ToString());

            await _mailerService.SendEmailAsync(viewModel.Email, "Email Verification - Coders Shop", $"<a href=\"{link}\">Verify Email</a>");
            
            return RedirectToAction("EmailVerification");
        }

        public IActionResult EmailVerification() => View();


        [HttpGet]
        public async Task<IActionResult> Logout(string logoutId)
        {
            await _signInManager.SignOutAsync();
            var logoutRequest = await _identityServerInteractionService.GetLogoutContextAsync(logoutId);

            if (logoutRequest.PostLogoutRedirectUri.IsNullOrEmpty())
            {
                return RedirectToAction("Login");
            }

            return Redirect(logoutRequest.PostLogoutRedirectUri);
        }

        [HttpGet]
        public async Task<IActionResult> Login(string returnUrl)
        {
            var externalProviders = await _signInManager.GetExternalAuthenticationSchemesAsync();
            return View(new LoginViewModel
            {
                ReturnUrl = returnUrl,
                ExternalProviders = externalProviders
            });
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (loginViewModel.ExternalProviders.IsNullOrEmpty())
                loginViewModel.ExternalProviders = await _signInManager.GetExternalAuthenticationSchemesAsync();

            if (!ModelState.IsValid)
                return View(loginViewModel);

            var result = await _signInManager.PasswordSignInAsync(loginViewModel.Username, loginViewModel.Password, false, false);

            if (result.Succeeded)
                return Redirect(loginViewModel.ReturnUrl);
            if (result.IsLockedOut)
                return View("Lockout");

            loginViewModel.StatusMessage = SharedResource.INCORRECT_PASSWORD;
            return View(loginViewModel);
        }


        public IActionResult ExternalLogin(string provider, string returnUrl)
        {
            var redirectUri = Url.Action(nameof(ExternalLoginCallback), "Auth", new {provider, returnUrl});
            var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUri);
            return Challenge(properties, provider);
        }

        public async Task<IActionResult> ExternalLoginCallback(string provider, string returnUrl)
        {
            var info = await _signInManager.GetExternalLoginInfoAsync();
            if (info == null)
            {
                return RedirectToAction("Login");
            }

            var result = await _signInManager
                .ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, false);

            if (result.Succeeded)
            {
                return Redirect(returnUrl);
            }

            var username = info.Principal.FindFirst(ClaimTypes.Name).Value.Replace(" ", "_");
            var email = info.Principal.FindFirst(ClaimTypes.Email).Value;

            return View("ExternalRegister", new ExternalRegisterViewModel
            {
                Username = username,
                Email = email,
                ReturnUrl = returnUrl,
                Provider = provider
            });
        }

        public async Task<IActionResult> ExternalRegister(ExternalRegisterViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            var info = await _signInManager.GetExternalLoginInfoAsync();
            if (info == null)
            {
                return RedirectToAction("Login");
            }

            var user = new IdentityUser(viewModel.Username) {Email = viewModel.Email, EmailConfirmed = true};
            var result = await _userManager.CreateAsync(user);

            if (!result.Succeeded)
            {
                return View(viewModel);
            }

            result = await _userManager.AddLoginAsync(user, info);

            if (!result.Succeeded)
            {
                return View(viewModel);
            }

            await _signInManager.SignInAsync(user, false);

            return Redirect(viewModel.ReturnUrl);
        }


        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user == null || !(await _userManager.IsEmailConfirmedAsync(user)))
                {
                    return View("ForgotPasswordConfirmation");
                }

                var code = await _userManager.GeneratePasswordResetTokenAsync(user);
                var link = Url.Action(nameof(ResetPassword), "Auth", new {userId = user.Id, code}, HttpContext.Request.Scheme);

                await _mailerService.SendEmailAsync(model.Email, "Password Reset - Coders Shop", $"Please reset your password by clicking: <a href=\"{link}\">Reset Password</a>");

                return View("ForgotPasswordConfirmation");
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ResetPassword(string code = null)
        {
            return code == null ? View("Error") : View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return RedirectToAction(nameof(ResetPasswordConfirmation), "Auth");
            }

            var result = await _userManager.ResetPasswordAsync(user, model.Code, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction(nameof(ResetPasswordConfirmation), "Auth");
            }

            AddErrors(result);
            return View();
        }

        [HttpGet]
        public IActionResult ResetPasswordConfirmation()
        {
            return View();
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