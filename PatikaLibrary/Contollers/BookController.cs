using Microsoft.AspNetCore.Mvc;
using PatikaLibrary.Models;
using PatikaLibrary.ViewModels;
using PatikaLibrary.ViewModels.BookViewModel;

namespace PatikaLibrary.Contollers
{
    public class BookController : Controller
    {

        
        public List<Book> books = new List<Book>()
        {
            new Book{Id=2,AuthorId=3,Title="Nutuk",Genre="Tarih",CopiesAvailable=5},
            new Book{Id=3,AuthorId=5,Title="Son Ada",Genre="Hikaye"}
        };
        public List<Author> _author = new List<Author>()
        {
            new Author{ Id=1, FirstName="Mustafa Kemal",LastName="Atatürk"},
            new Author{ Id=2,FirstName="Zülfü",LastName="Livaneli"}
        };
   
            public IActionResult BookList()
            {
              var bookList= books.Where(x => x.IsDelete == false)// Kitap listelemek için ıs dalete false olanı seçiyoruz
              .Select(x => new BookListViewModel//BookListViewModel den verileri alarak yeni bir liste oluşturuyoruz
              {
               Title = x.Title,
               Genre = x.Genre,
               Id = x.Id,

              }).ToList();

                return View(bookList);// formuberiler ile dolduruyoruz
            }

      

        [HttpGet]
        public IActionResult Details(int id)//Seçilen verinin idsini yakalıyoruz
        {
            var view = books.Find(x => x.Id == id);// Seçilen verilerine ulaşıyoruz

            var viewModel = new BookDetailsViewModel//Verile BookDetailsViewModel den gerlen verile ile eşitliyoruz 
            {
                id = view.Id,
                Genre = view.Genre,
                Title = view.Title,
                CopiesAvailable = view.CopiesAvailable,
                PublishTime = view.PublishTime,
            };

            return View(viewModel);//Formu viewModel ile dolduruyoruz
        }
        
        [HttpPost]
        public IActionResult Create(BookCreateViewModel _book)
        {
            if (!ModelState.IsValid)//ViewModel de istenen durumu sağlıyormu kotrol ediyoruz
            {
                return View(_book);// Eğer sağlamıyor ise formu tekrar dolu olarak kullanıcıya gönderiyoruz
            }

            int maxid = books.Max(x => x.Id);//Max id buluyoruz

            var bookadd = new Book()//Yeni bilgileri tanımlıyoruz
            {
                Id = maxid + 1,
                Title = _book.Title,
                Genre = _book.Genre,
                PublishTime = _book.PublishTime,
                CopiesAvailable = _book.CopiesAvailable,

            };
            books.Add(bookadd);//Yeni kitabı listeye ekliyoruz

            return RedirectToAction("BookList");
        }
        [HttpGet]
        public IActionResult Create()//Create formuna gitmek için kullanıyoruz 
        {
            ViewBag.Author = _author;// Hangi yazara ait olduğunu eklemek için burada tanımlıyoruz
            return View();
        }

        [HttpGet]//Viewe gitmesini sağlıyoruz
        public IActionResult Edit (int id)
        {
            var book = books.Find(x => x.Id == id);//Seçilen idyi yakalıyoruz

             var viewModel = new BookEditViewModel()//id ye ait bilgileri tanımlıyoruz
             {
                 Id=book.Id,
                 Title = book.Title,
                 Genre = book.Genre,
                 PublishTime = book.PublishTime,
                 CopiesAvailable = book.CopiesAvailable,
                 ISBN=book.ISBN,
                 AuthorId=book.AuthorId
                 
             };

            ViewBag.Author=_author;

            return View(viewModel);//Değiştirilecek verileri forma gönderiyoruz
        }
        [HttpPost]
        public IActionResult Edit (BookEditViewModel formData)
        {
            if (!ModelState.IsValid)//İstenen şartlerı sağlıyor mu bakıyoruz
            {
                return View(formData);
            }
            var book = books.Find(x => x.Id == formData.Id);//Değiştirilecek verileri hangi id ye aktaracağımızı buluyoruz ve yeni bilgileri ekliyoruz

            book.Id= formData.Id;
            book.Title= formData.Title;
            book.Genre= formData.Genre;
            book.PublishTime= formData.PublishTime;
            book.ISBN= formData.ISBN;
            book.AuthorId= formData.AuthorId;

            return RedirectToAction("BookList");
        }


        [HttpGet]
        public IActionResult Delete(int Id)
        {
            var view = books.Find(x => x.Id == Id);//Seçilen id yi yakalıyoruz
            view.IsDelete = true;//Yakaladığımız id yi soft delete yaparak is delete değişkenini true yapıyoruz
            return RedirectToAction("Booklist");
        }


    }
}
