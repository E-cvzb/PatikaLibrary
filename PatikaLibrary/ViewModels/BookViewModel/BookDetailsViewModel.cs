using System.Transactions;

namespace PatikaLibrary.ViewModels.BookViewModel
{
    public class BookDetailsViewModel
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string? Genre { get; set; }
        public int CopiesAvailable { get; set; }
        public DateTime PublishTime { get; set; }
        public int id { get; set; }
        public int AuthorId { get; set; }
    }
}
