using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.DependencyInjection;

namespace WebApiDiploma.ServiceExtensions
{
    public static class TranslationsServiceExtensions
    {
        // 1️⃣ Підтримка локалізації сайту
        public static void AddLocalizationSupport(this IServiceCollection services)
        {
            services.AddLocalization(options => options.ResourcesPath = "Resources");

            var supportedCultures = new[] { "uk", "en" };

            services.Configure<RequestLocalizationOptions>(options =>
            {
                options.SetDefaultCulture("uk"); // мова за замовчуванням
                options.AddSupportedCultures(supportedCultures);
                options.AddSupportedUICultures(supportedCultures);

                // отримаємо мову через кукі
                options.RequestCultureProviders.Insert(0, new CookieRequestCultureProvider());
            });
        }

        // 2️⃣ Додаємо MVC + підтримка .resx
        public static void AddMvcWithLocalization(this IServiceCollection services)
        {
            services
                .AddControllersWithViews()
                .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                .AddDataAnnotationsLocalization();
        }
    }

}
