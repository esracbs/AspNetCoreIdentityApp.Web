using AspNetCoreIdentityApp.Web.Models;
using Microsoft.AspNetCore.Identity;

namespace AspNetCoreIdentityApp.Web.CustomValidators
{
    public class UserValidator : IUserValidator<AppUser>
    {
        public Task<IdentityResult> ValidateAsync(UserManager<AppUser> manager, AppUser user)
        {
            var errors = new List<IdentityError>();
            var isDigit = int.TryParse(user.UserName![0].ToString(), out _);
            if (isDigit)
            {
                errors.Add(new() { Code = "UsernameContainFirstLetterDigit", Description = "Kullanıcı Adının İlk Karakteri Sayısal Bir Karakter Olamaz" });
            }
            if (errors.Any())
            {
                return Task.FromResult(IdentityResult.Failed(errors.ToArray()));  //errros listesi doluysa failed dön
            }
            return Task.FromResult(IdentityResult.Success);
        }
    }
}