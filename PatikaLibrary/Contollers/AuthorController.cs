using Microsoft.AspNetCore.Mvc;
using PatikaLibrary.Models;
using PatikaLibrary.ViewModels.Author;

namespace PatikaLibrary.Contollers
{
    public class AuthorController : Controller
    {

        public List<Book> books = new List<Book>() // Bir kitap listesi oluşturuyoruz
        {
            new Book{Id=2,AuthorId=3,Title="Nutuk",Genre="Tarih",CopiesAvailable=5,},
            new Book{Id=3,AuthorId=5,Title="Son Ada",Genre="Hikaye",}
        };
        public List<Author> _author = new List<Author>()//Bir yazar listesi oluşturuyoruz
        {
            new Author{ Id=1, FirstName="Mustafa Kemal",LastName="Atatürk"},
            new Author{ Id=2,FirstName="Zülfü",LastName="Livaneli"}
        };
        public IActionResult AuthorList()
        {
            var authorList = _author.Where(x => x.IsDelete == false)// soft dete işemi için tanımladığımız ıs delete değişkeni false ise listeleme işlemine dahil ediyoruz 
           .Select(x => new AuthorListViewModel
           //AuthorListiewModelinde ki değişkenleri yakalamış olduğumuz x değeri ile tanımlayarak bir liste olşturuyoruz
            {
             FirstName = x.FirstName,
             LastName = x.LastName,
             Id = x.Id

            }).ToList();


            return View(authorList);//Viewdeki tabloyu authorList ile dolduruyoruz 

        }
        public IActionResult Details(int id)// Formdan seçtiğimiz yazarın detaylarına gitmek için id tanımlıyoruz
        {
            var view = _author.Find(x => x.Id == id);// formdan seçilen id ile listede eşleşen id bulunuyor

                var viewModel = new AuthorDetailsViewModel//İd ile eşleşen değerler AuthorDetailsViewModeldei değerler ile tekrardan tanımlanır 
                {
                    Id = view.Id,
                    FirstName = view.FirstName,
                    LastName = view.LastName,
                    DateOfBirth = view.DateOfBirth,

                };
                return View(viewModel);//Details view içi viewModel ile doldurulur
            
        }
        [HttpGet]
        public IActionResult Edit()//Edit viewvini açmak için httpget kullanıyoruz
        {
            ViewBag.Book = books;

            return View();
        }
        [HttpPost]//Edit formunundan gönderilecek değerler için HttoPost kullanıyoruz 
        public IActionResult Edit(int id)
        {
            var view = _author.Find(x=>x.Id==id);//Formda değişiklik yapılacak id bulunuyor

            var viewModel = new AuthorEditViewModel// Yapılan değişikler viewModel ile form doldurularak tanımlanıyor
            {
                Id=view.Id,
                FirstName=view.FirstName,
                LastName=view.LastName,
                DateOrBirth=view.DateOfBirth

            };

            return View(viewModel);
        }

        [HttpGet]//Yazar oluşturma sayfasına gitmek için HttpGet oluşturuluyor
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]//Formda doldurulan değerlerin atanması için HttpPost olarak tanımlıyoruz 
        public IActionResult Create(AuthorCreateViewModel formData) 
        {
            if (ModelState.IsValid) //AuthorCreateViewModeldeki şartları sağlayıp sağlamadığını kotrol ediyoruz
            {
                return View(formData);//Eğer sağlamıyor ise formu dolu olarak tekrar göderiyoruz 
            }
            int maxid = _author.Max(x => x.Id);// Yeni tanımlanacak yazarın idsi için listedeki max id bulunuyor 

            var authoradd = new Author//Yeni oluşan yazar için formdan gelen formData ile yeni yazar oluşturuluyor
            {
                FirstName = formData.FistName,
                LastName = formData.LastName,
                DateOfBirth = formData.DateOfBirth,
                Id = maxid + 1
            };
            _author.Add(authoradd);//Listeye yeni yazar ekleniyor

            return RedirectToAction("AuthorList");// AuthorListe ekranına gönderiyoruz 
        }

        public IActionResult Delete(int id)//Soft delete işlemi yapılıyor 
        {
          var viewmodel = _author.Find(x => x.Id==id);//Silinecek veriyi buluyoruz
            viewmodel.IsDelete = true;
            //Silem işelmi için tanımladığımız ısdelete değişkeninş true yaparak listeden çıkmasını sağlıyoruz 
            //Bu sayede silmiş olduğumuz veriye tekrar ulaşmak istersek ulaşabiliriz

            return View("AuthorList");
        }

    }
}
