namespace PatikaLibrary.Models
{
    public class User
    {
        public User()   //User kullanılmaya başlandığı anda bunu oluşturu ve kayıt tarihi tanımlanır
        {
            JoınDate = DateTime.Now;
        }
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string Email  { get; set; }
        public string Password { get; set; }

        public string PhoneNumber { get; set; }
        public DateTime JoınDate { get; set; }
    }
}
