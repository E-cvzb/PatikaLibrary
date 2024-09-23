using System.ComponentModel.DataAnnotations;

namespace PatikaLibrary.ViewModels.BookViewModel
{
    public class BookCreateViewModel
    {
        [Required(ErrorMessage = "Bu alanı doldurmak zorudasınız ")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Bu alanı doldurmak zorudasınız ")]
        public string Author { get; set; }
        [Required(ErrorMessage = "Bu alanı doldurmak zorudasınız ")]
        public string? Genre { get; set; }
        [Required(ErrorMessage = "Bu alanı doldurmak zorudasınız ")]
        public int CopiesAvailable { get; set; }
        [Required(ErrorMessage = "Bu alanı doldurmak zorudasınız ")]
        public DateTime PublishTime { get; set; }

    }
}
