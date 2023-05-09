using System.ComponentModel.DataAnnotations;

namespace AspNetCoreIdentityApp.Web.ViewModels
{
    public class SignInViewModel
    {
        public SignInViewModel()
        {
        }

        public SignInViewModel(string email, string password)
        {
            Email = email;
            Password = password;
        }

        [Required(ErrorMessage = "Email alanı boş bırakılamaz.")]
        [EmailAddress(ErrorMessage = "Email formatı yanlıştır.")]
        [Display(Name = "Email :")]
        public string Email { get; set; } = null!;
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Parola alanı boş bırakılamaz.")]
        [Display(Name = "Şifre :")]
        public string Password { get; set; } = null!;
        [Display(Name = "Beni Hatırla!")]
        public bool Rememberme { get; set; }
    }
}
