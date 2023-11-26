# ⚡Öğrenci Ders Yönetimi Projesi ⚡

Öğrencilerin sisteme giriş yaparak ders seçtikleri ve seçtikleri dersleri görüntüledikleri bir uygulamadır.

Uygulama da; DDD(Domain Dream Development) Tekniği ile Onion Architecture mimarisi kullanılmıştır. CQRS tasarımı ile MediatR kütüphanesini kullandığım .NET 8 MVC Core projesidir.

Veritabanı olarak PostgreSQL ve ORM Toollarından EF Core , tasarım yaklaşımı olarak da CodeFirst kullanılmıştır.

Verileri hızlı bir şekilde depolamak ve erişmek için Redis cache aracı kullanılmıştır.

Proje Docker ortamında Distruburted olarak oluşturulmuştur.


Veritabanı işlemlerini soyutlama ve modülerleştirme için Repository Design Pattern tasarım deseni ve Bağımlılıkları yönetmek için Dependency Injection yapısı kullanılmıştır.

Repository Pattern ile birlikte Dependency Injection kullanmak, bağımlılıkların yönetimini kolaylaştırır ve kodun daha esnek hale gelmesini sağlar.


*-İlk olarak Öğrenci uygulamaya Register butonuyla kayıt olmalıdır.

*-Üye olduktan sonra Login ekranında  Username ve Password bilgilerini girerek sisteme giriş yapabilir.Login olurken bilgileri Cookie de tutulur.

*-Login olduktan sonra Öğrenci; Profile butonunu görüntüleyebilir ve Proffile sayfasına geçiş yapabilir.

Profile sayfasında;
-   _MyInformation butonu ile kendi kişisel bilgilerini görebilir._
-   _MyCourses butonu ile seçtiği ders listesini görebilir._
-   _AllCourses butonu ile tüm ders listesinden istediği dersleri seçerek kaydedebilir._


 _Anasayfa:_ 

![1HomePage](https://github.com/ysnesra/StudentLessonApp/assets/104023688/bf244d66-62b4-4b76-818c-2d23575b1de0)


 _Register-Login İşlemleri:_ 

|![2Register](https://github.com/ysnesra/StudentLessonApp/assets/104023688/c249207d-ba73-4a4a-9dcb-fb277185b130)  |![23Login](https://github.com/ysnesra/StudentLessonApp/assets/104023688/d24e81f4-597d-4fe2-8c9d-691630ff625b) |
|--|--|
|  |  |


 _Authorize olduktan sonra Öğrencinin Profile Sayfası:_ 

![3StudentPanel](https://github.com/ysnesra/StudentLessonApp/assets/104023688/c59bf5ba-78fe-407e-b809-4c8cc5258ef0)


 _My Information:_ _Öğrencinin Kişisel Bilgilerini görüntülendiği Sayfa_ 
 
 ![4MyInformation](https://github.com/ysnesra/StudentLessonApp/assets/104023688/ba3b1426-b957-444a-a4c5-4723bed6058a)

 
 _All Courses:_ _Tüm Deslerin görüntülendiği Sayfa_ 

 ![5AllCourse](https://github.com/ysnesra/StudentLessonApp/assets/104023688/7a369616-4362-4bc6-bb37-43dd8e2932f7)


