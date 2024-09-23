## Patika Library
### Bu proje, Patika+ eğitimlerinde 9. hafta projesi olarak hazırlanmıştır. Projenin amacı, şimdiye kadar öğrendiğimiz C#, LINQ ve MVC bilgilerini değerlendirmektir.
### Proje hazırlanırken MVC kullanılmıştır.
#### Projedeki Controllers:
#### 1) HomeController: Anasayfa ve hakkında kısmı için hazırlanmıştır.
#### 2) BookController: Bu controller'da kitap ekleme, detay gösterme, düzenleme, listeleme ve silme işlemleri yapılmaktadır. Ekleme işlemi için BookCreateViewModel oluşturulmuştur. Detaylar için BookDetailsViewModel kullanılmıştır. Düzenlemek için BookEditViewModel oluşturulmuştur. Listeleme işlemi için BookListViewModel kullanılmıştır. Formdan elde edilen veriler LINQ ile liste içerisinden elde edilmiştir.
#### Yeni kullanıcı eklenirken ID oluşturmak için max ID bulunmuş ve tanımlanmıştır.
#### 3) AuthorController: Bu controller'da yazar ekleme, detay gösterme, listeleme, düzenleme ve silme işlemleri yapılmaktadır. Ekleme işlemi için AuthorCreateViewModel oluşturulmuştur. Detayların listelenmesi için AuthorDetailsViewModel oluşturulmuştur. Düzenlemek için AuthorEditViewModel kullanılmıştır. Listeleme işlemi için AuthorListViewModel oluşturulmuştur.
#### Silme işlemleri yapılırken soft delete uygulanmıştır. IsDelete değişkeni, silinme durumunda true olarak ayarlanmıştır.
#### 4) UserController: Bu controller'da kullanıcı kayıt olma ve giriş yapma işlemleri bulunmaktadır. Kayıt işlemi için SignUpViewModel oluşturulmuştur. Giriş işlemi için SignInViewModel oluşturulmuştur.
#### Kullanıcının şifresinin daha güvenli bir şekilde saklanması için IDataProtector kullanılmıştır.
#### Oturum açıldığında, Claims listesi ve Cookies tanımlanarak çerezler oluşturulmuştur.
#### Projedeki Models:
#### Author, User ve Book modellerinde değişkenler tanımlanmıştır.
#### User modelinde, kayıt tarihini kullanıcı oluşturulduğunda tutmak için constructor oluşturulmuştur.
#### Projedeki Views:
#### Projede ortak kullanılan navbar ve footer, partial tipinde oluşturulmuş ve layout'a yerleştirilerek projenin iskeleti oluşturulmuştur.
