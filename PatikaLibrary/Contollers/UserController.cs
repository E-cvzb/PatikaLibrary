using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using PatikaLibrary.Models;
using PatikaLibrary.ViewModels.UserViewModel;
using System.Security.Claims;

namespace PatikaLibrary.Contollers
{
    public class UserController : Controller
    {
        private readonly IDataProtector _dataProtector;//Şifreyi gizlemek için robotun ismini tanımlıyoruz 

        public List<User> _user = new List<User>() 
        {
            new User {UserId=1,Email=".",FullName=".",Password=".",PhoneNumber="."},// Id değerini sıralı şekilde atamak için 1 değerine karşılık gelen kullanıcı oluşturuyoruz
        };

        public UserController (IDataProtectionProvider dataProtectionProvider)
        {
            _dataProtector = dataProtectionProvider.CreateProtector("security");//Robotu tanımlıyoruz ve ne için çalışacağını tanımlıyoruz 
            
        }
        [HttpGet]//Kayıt ekranına yönelendiriliyoruz
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SignUp(SignUpViewModel formData)
        {
            if (!ModelState.IsValid)//Şartları kontrol ediyoruz
            {
                return View(formData);
            }
            var user =  _user.FirstOrDefault(x=> x.Email.ToLower() == formData.Email.ToLower());//Daha önce mail adresi kullanılmışmı sorgulamak için değişken tanımlıyoruz

            if(user is not null)//Eğerboş değer dönmez ise kullanıcıya hata mesajı gönderiyoruz 
            {
                ViewBag.Error = "Kullanıcı mevcut";
                return View(formData);
            }
            var newUser = new User()//Yeni kullanıcının bilgilerini aktarıyoruz
            {
                Email = formData.Email,
                FullName = formData.FullName,
                Password = _dataProtector.Protect(formData.Password),
                PhoneNumber = formData.PhoneNumber,
                JoınDate = DateTime.Now,
                UserId=_user.Max(x => x.UserId)+1,
                
            };
            _user.Add(newUser);// Yeni kullanıcıyı listeye ekliyoruz

        return RedirectToAction("BookList","Book"); //Kullanıcıyı book controller in BookList action a gönderiyoruz
        }
        [HttpGet]
        public IActionResult SignIn()//Giriş ekranına yönlendiriyoruz
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn (SignInViewModel formData)
        {
            var user = _user.FirstOrDefault(x=> x.Email.ToLower() == formData.Email.ToLower());//Email adresi listemizde var mı kotrol ediyoruz
            if (user is  null)
            {
                ViewBag.Error = "Kullanıcı adı veya şifre hatalı";//Eğer email adresi kayıtlı değil ise hata veriyoruz
                return View(formData);
            }
            var rawPassword = _user.FirstOrDefault(x=> x.Password==formData.Password);//Kullanıcının şifresini kotrol ediyoruz
                if (user is null)
                {
                var claims = new List<Claim>();//Çerezlerin tutulacağı dosyayı oluşturuyoruz
                claims.Add(new("email", user.Email));//Çerez dosyasına ekleme yapıyoruz
                claims.Add(new("ıd", user.UserId.ToString()));
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties
                {
                    AllowRefresh = true,//Ekranı tekrar yenilemeye izin veriyor musun
                    ExpiresUtc = new DateTimeOffset(DateTime.Now.AddHours(5)) //Arka planda ne kadar süre açık kalacağı 
                };

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);//Oturum açma işlemi

                }
                else
                {
                ViewBag.Error = "Kullanıcı adı veya şifre hatalı";
                return View(formData);//Eğer şifere listede yok ise hata veriyoruz
                }

        return View(); 
        }
    }
}
