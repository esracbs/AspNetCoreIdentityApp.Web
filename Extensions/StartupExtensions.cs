using AspNetCoreIdentityApp.Web.CustomValidators;
using AspNetCoreIdentityApp.Web.Localizations;
using AspNetCoreIdentityApp.Web.Models;
using Microsoft.AspNetCore.Identity;

namespace AspNetCoreIdentityApp.Web.Extensions
{
    public static class StartupExtensions
    {
        public static void AddIdentityWithExtension(this IServiceCollection services)
        {
            services.Configure<DataProtectionTokenProviderOptions>(options => { options.TokenLifespan = TimeSpan.FromHours(2); });
            //üst satırdaki kod oluşturulan tokenin ömrünü belirler
            services.AddIdentity<AppUser, AppRole>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.User.AllowedUserNameCharacters = "abcdefghıijklmnoöprsştuüvyzwj1234567890_*"; //usernamede sadece abcd karakterleri olsun

                options.Password.RequiredLength = 6; //şifre altı karakter olsun
                options.Password.RequireNonAlphanumeric = false; //* gibi özel karakterlerin olmasına gerek yok.
                options.Password.RequireLowercase = true; // küçük karakter zorunluu olsun
                options.Password.RequireUppercase = false; // byük harf zorunlu olmasın
                options.Password.RequireDigit = false; //sayısal karakterler zorunlu değil
                
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(3);
                options.Lockout.MaxFailedAccessAttempts = 3;

            }).AddPasswordValidator<PasswordValidator>().AddUserValidator<UserValidator>()
            .AddErrorDescriber<LocalizationIdentityErrorDescriber>().AddDefaultTokenProviders().
            AddEntityFrameworkStores<AppDbContext>();
        }
    }
}