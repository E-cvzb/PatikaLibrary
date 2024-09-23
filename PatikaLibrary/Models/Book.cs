namespace PatikaLibrary.Models
{
    public class Book:Author
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int  AuthorId { get; set; }
        public string Genre { get; set; }
        public DateTime PublishTime { get; set; }
        public string? ISBN { get; set; }
        public int CopiesAvailable{ get; set; }
        public bool IsDelete { get; set; }
    }
}
