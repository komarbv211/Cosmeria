using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace WebApiDiploma.Controllers.User
{
    public class LanguageController : Controller
    {
        public IActionResult SetLanguage(string lang)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(lang)),
                new CookieOptions
                {
                    Expires = DateTimeOffset.UtcNow.AddYears(1)
                }
            );

            // повернення на попередню сторінку
            var referer = Request.Headers["Referer"].ToString();
            if (!string.IsNullOrEmpty(referer))
                return Redirect(referer);

            return RedirectToAction("Index", "Home");
        }
    }
}
