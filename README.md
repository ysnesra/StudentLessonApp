# ⚡Öğrenci Ders Yönetim Projesi ⚡

Öğrencilerin sisteme giriş yaparak ders seçtikleri ve seçtikleri dersleri görüntüledikleri bir uygulamadır._ 
Uygulama da; DDD(Domain Dream Development) Tekniği ile Onion Architecture mimarisi kullanılmıştır. CQRS tasarımı ile MediatR kütüphanesini kullandığım .NET 8 MVC Core projesidir._
Veritabanı olarak PostgreSQL ve ORM Toollarından EF Core , tasarım yaklaşımı olarak da CodeFirst kullanılmıştır._
Verileri hızlı bir şekilde depolamak ve erişmek için Redis cache aracı kullanılmıştır._
Proje Docker ortamında Distruburted olarak oluşturulmuştur.

Veritabanı işlemlerini soyutlama ve modülerleştirme için Repository Design Pattern tasarım deseni ve Bağımlılıkları yönetmek için Dependency Injection yapısı kullanılmıştır.
Repository Pattern ile birlikte Dependency Injection kullanmak, bağımlılıkların yönetimini kolaylaştırır ve kodun daha esnek hale gelmesini sağlar.

- İlk olarak Öğrenci uygulamaya Register butonuyla kayıt olmalıdır.
Üye olduktan sonra Login ekranında  Username ve Password bilgilerini girerek sisteme giriş yapabilir.Login olurken bilgileri Cookie de tutulur.

Login olduktan sonra Öğrenci; Profile butonunu görüntüleyebilir ve Proffile sayfasına geçiş yapabilir.
Profile sayfasında;
-   _MyInformation butonu ile kendi kişisel bilgilerini görebilir._
-   _MyCourses butonu ile seçtiği ders listesini görebilir._
-   _AllCourses butonu ile tüm ders listesinden istediği dersleri seçerek kaydedebilir._


