using Microsoft.AspNetCore.Mvc.Rendering;

namespace IdentityServer.Views.Helper
{
    public static class ManageNavPages
    {
       public static string Index => "Index";

        public static string ChangePassword => "ChangePassword";

        public static string PersonalData => "PersonalData";

        public static string DeletePersonalData => "DeletePersonalData";

        public static string IndexNavClass(ViewContext viewContext) => NavPagesBase.PageNavClass(viewContext, Index);

        public static string ChangePasswordNavClass(ViewContext viewContext) => NavPagesBase.PageNavClass(viewContext, ChangePassword);

        public static string PersonalDataNavClass(ViewContext viewContext) => NavPagesBase.PageNavClass(viewContext, PersonalData);
    }
}
