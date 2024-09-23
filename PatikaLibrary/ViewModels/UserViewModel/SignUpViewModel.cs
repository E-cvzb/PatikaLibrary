using System.ComponentModel.DataAnnotations;

namespace PatikaLibrary.ViewModels.UserViewModel
{
    public class SignUpViewModel
    {
        public int Id { get; set; }
        public string  Email { get; set; }
        public string Password { get; set; }
        [Compare(nameof(Password))]//İki şifreninde aynı olup olmadığına bakar
        public string PasswordConfirm { get; set; }
        public string  FullName { get; set; }
        public string  PhoneNumber { get; set; }
        public DateTime JoinDate { get; set; }
    }
}
