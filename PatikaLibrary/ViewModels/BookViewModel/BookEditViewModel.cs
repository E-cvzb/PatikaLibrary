namespace PatikaLibrary.ViewModels.BookViewModel
{
    public class BookEditViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string ISBN { get; set; }
        public int CopiesAvailable { get; set; }
        public DateTime PublishTime { get; set; }
        public int AuthorId { get; set; }
    }
}
