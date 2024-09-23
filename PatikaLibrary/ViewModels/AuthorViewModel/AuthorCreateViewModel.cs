using System.ComponentModel.DataAnnotations;

namespace PatikaLibrary.ViewModels.Author
{
    public class AuthorCreateViewModel
    {
        [Required(ErrorMessage ="Bu alanı doldurmak zorundasınız ")]//Boş bırakılırsa hata göndermemizi sağlar
        public string FistName { get; set; }

        [Required(ErrorMessage = "Bu alanı doldurmak zorundasınız ")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Bu alanı doldurmak zorundasınız ")]
        public DateTime DateOfBirth { get; set; }
    }
}
