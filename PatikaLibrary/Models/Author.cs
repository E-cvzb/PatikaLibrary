namespace PatikaLibrary.Models
{
    public class Author
    {
       
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool  IsDelete { get; set; }
       
        public string FullName { get; set; }
        




    }
}
