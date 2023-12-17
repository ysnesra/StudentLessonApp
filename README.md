# ⚡Öğrenci Ders Yönetimi Projesi ⚡

Öğrencilerin sisteme giriş yaparak ders seçtikleri ve seçtikleri dersleri görüntüledikleri bir uygulamadır.

Uygulama da; DDD(Domain Dream Development) Tekniği ile Onion Architecture mimarisi kullanılmıştır. CQRS tasarımı ile MediatR kütüphanesini kullandığım .NET 8 MVC Core projesidir.

Veritabanı olarak PostgreSQL ve ORM Toollarından EF Core , tasarım yaklaşımı olarak da CodeFirst kullanılmıştır.

Verileri hızlı bir şekilde depolamak ve erişmek için Redis cache aracı kullanılmıştır.

Proje Docker ortamında Distributed olarak oluşturulmuştur.


Veritabanı işlemlerini soyutlama ve modülerleştirme için Repository Design Pattern tasarım deseni ve Bağımlılıkları yönetmek için Dependency Injection yapısı kullanılmıştır.

Repository Pattern ile birlikte Dependency Injection kullanmak, bağımlılıkların yönetimini kolaylaştırır ve kodun daha esnek hale gelmesini sağlar.

AutoMapper kütüphanesi kullanılarak farklı veri modeli arasında dönüşüm performanslı hale getirildi.


*****
*-İlk olarak Öğrenci uygulamaya Register butonuyla kayıt olmalıdır.

  Register ve Login olurken girilen değerlerin geçerli olup olmadığını kontrol etmek için FluentValidation kütüphanesi kullanılmıştır.

*-Üye olduktan sonra Login ekranında  Username ve Password bilgilerini girerek sisteme giriş yapabilir.Login olurken bilgileri Cookie de tutulur.

*-Login olduktan sonra Öğrenci; Profile butonunu görüntüleyebilir ve Proffile sayfasına geçiş yapabilir.

Profile sayfasında;
-   _MyInformation butonu ile kendi kişisel bilgilerini görebilir._
-   _MyCourses butonu ile seçtiği ders listesini görebilir._
-   _AllCourses butonu ile tüm ders listesinden istediği dersleri seçerek kaydedebilir._



*****


 _Anasayfa:_ 

![1HomePage](https://github.com/ysnesra/StudentLessonApp/assets/104023688/bf244d66-62b4-4b76-818c-2d23575b1de0)

*****

 _Register-Login İşlemleri:_ 

|![2Register](https://github.com/ysnesra/StudentLessonApp/assets/104023688/c249207d-ba73-4a4a-9dcb-fb277185b130)  |![23Login](https://github.com/ysnesra/StudentLessonApp/assets/104023688/d24e81f4-597d-4fe2-8c9d-691630ff625b) |
|--|--|
|  |  |

*****

 _Authorize olduktan sonra Öğrencinin Profile Sayfası:_ 

![3StudentPanel](https://github.com/ysnesra/StudentLessonApp/assets/104023688/c59bf5ba-78fe-407e-b809-4c8cc5258ef0)

*****

 _My Information:_ _Öğrencinin Kişisel Bilgilerini görüntülendiği Sayfa_ 
 
 ![4MyInformation](https://github.com/ysnesra/StudentLessonApp/assets/104023688/ba3b1426-b957-444a-a4c5-4723bed6058a)

*****

 _All Courses:_ _Tüm Deslerin görüntülendiği Sayfa_ 

![kaydet](https://github.com/ysnesra/StudentLessonApp/assets/104023688/dd1149f4-ae07-4a47-b3f6-e0ea649f5509)

*****

Öğrenci Dersleri seçtikten sonra "My Lesson" sayfasına yönlendirilir.Seçtiği tüm dersleri görebilir.

![12myLesson](https://github.com/ysnesra/StudentLessonApp/assets/104023688/05413ef1-9032-46f0-a32e-2d994be2c619)



Seçtiği dersler eklenince ekran görüntüsü :
![13Mylessonartı](https://github.com/ysnesra/StudentLessonApp/assets/104023688/cb5daea3-e9b7-4927-bd40-917e0d8b37a8)



*****
_Docker üzerinden oluşturuduğum Redis localhost'da 6380 portunda çalışıyor:_

|![7Docker](https://github.com/ysnesra/StudentLessonApp/assets/104023688/02c8eca6-17fa-496f-b82b-5014d95920f8)  |![6Redis](https://github.com/ysnesra/StudentLessonApp/assets/104023688/290e49bf-f2f5-469e-9dfa-912a0633ad94) |
|--|--|
|  |  |


Ders listesi redisden geliyor:
Cachede varsa cacheden gelir. Yoksa önce cachelenir sonra verileri cacheden getirir.

![Ekran görüntüsü 2023-12-10 214620](https://github.com/ysnesra/StudentLessonApp/assets/104023688/e2790298-9b0b-418f-851c-d2e71ffe2c50)
