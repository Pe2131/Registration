using Registration.Areas.AdminPanel.Controllers;
using Registration.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Registration.Areas.AdminPanel.Utilitis
{
    public static class UrlHelperExtensions
    {
        public static string EmailConfirmationLink(this IUrlHelper urlHelper, string userId, string code, string scheme)
        {
            return urlHelper.Action(
                action: nameof(AccountController.ConfirmEmail),
                controller: "Account",
                values: new { userId, code },
                protocol: scheme);
        }
        public static string DownloadLink(this IUrlHelper urlHelper,string code,int code2, string scheme)
        {
            return urlHelper.Action(
                protocol: scheme,
                controller: "SetData",
                action: "Download",
                values: new {code,code2}
                );

        }
        public static string ResetPasswordCallbackLink(this IUrlHelper urlHelper, string userId, string code, string scheme)
        {
            return urlHelper.Action(
                action: nameof(AccountController.ResetPassword),
                controller: "Account",
                values: new { userId, code },
                protocol: scheme);
        }
    }
}
