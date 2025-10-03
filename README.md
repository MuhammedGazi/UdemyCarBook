<h3 align="center">CarBook</h3>

<p align="center">
  ASP.NET Core 8 ve Soğan Mimarisi ile geliştirilmiş, modern ve kapsamlı araç kiralama platformu.
  <br>
  <br>
  <a href="https://github.com/MuhammedGazi/CarBook/issues/new?assignees=&labels=bug&template=bug_report.md&title=%5BHATA%5D%3A+"><strong>Hata Bildir »</strong></a>
  ·
  <a href="https://github.com/MuhammedGazi/CarBook/issues/new?assignees=&labels=enhancement&template=feature_request.md&title=%5BISTEK%5D%3A+"><strong>Özellik Talep Et »</strong></a>
</p>

<p align="center">
  <img src="https://img.shields.io/badge/.NET-8.0-512BD4?logo=dotnet" alt=".NET 8">
  <img src="https://img.shields.io/badge/Mimari-Soğan-8A2BE2" alt="Onion Architecture">
  <a href="https://github.com/MuhammedGazi/CarBook/issues">
    <img src="https://img.shields.io/github/issues/MuhammedGazi/CarBook" alt="GitHub issues">
  </a>
  <img src="https://img.shields.io/badge/lisans-MIT-green" alt="Lisans">
</p>
🚗 CarBook - Araç Kiralama Platformu
CarBook, modern .NET teknolojileri ve en iyi yazılım mimarisi pratikleri kullanılarak geliştirilmiş, kapsamlı bir araç kiralama projesidir. Bu proje, ASP.NET Core 8'in gücünü Soğan Mimarisi (Onion Architecture) ile birleştirerek ölçeklenebilir, sürdürülebilir ve test edilebilir bir uygulama sunmayı hedefler.

📝 Proje Hakkında
Bu platform, kullanıcıların araçları listeleyebileceği, detaylarını inceleyebileceği ve kiralama işlemleri yapabileceği bir web uygulamasıdır. Aynı zamanda yönetici paneli sayesinde sistemdeki tüm verilerin (araçlar, kullanıcılar, rezervasyonlar vb.) yönetilmesini sağlar. Proje, temiz kod ve tasarım desenlerinin pratik uygulamalarını sergilemek amacıyla geliştirilmiştir.

✨ Öne Çıkan Özellikler
✅ Kullanıcı Yönetimi: Kayıt olma, giriş yapma (JWT ile).

✅ Araç Listeleme: Gelişmiş filtreleme ve arama seçenekleri.

✅ Detaylı Araç Sayfaları: Araç özellikleri, fiyatlandırma ve konum bilgileri.

✅ Rezervasyon Sistemi: Kullanıcıların istedikleri tarih aralığında araç kiralaması.

✅ Yönetici Paneli: Ayrı bir Area içerisinde tam yetkili yönetim.

✅ Anlık Bildirimler: SignalR ile Araç Sayısı gibi bildirimler.

✅ Güvenli API: RESTful prensiplerine uygun, yetkilendirilmiş API endpointleri.

🏗️ Mimari ve Tasarım Desenleri
Proje, bağımlılıkları en aza indirmek ve iş mantığını merkezde tutmak için Soğan Mimarisi (Onion Architecture) üzerine kurulmuştur.

🏛️ Domain Katmanı: Projenin kalbidir. Varlıkları (Entities) ve temel iş kurallarını içerir. Hiçbir katmana bağımlılığı yoktur.

📦 Application Katmanı: İş akışlarını yönetir. Mediator (CQRS) deseni ile komutlar (Commands) ve sorgular (Queries) burada işlenir. Fluent Validation ile gelen isteklerin doğrulaması yapılır.

🖥️ Presentation Katmanı: Kullanıcı ile etkileşime giren katmandır. ASP.NET Core Web API ve ASP.NET Core MVC projelerini içerir.

🛠️ Infrastructure (Altyapı) Katmanı: Veritabanı işlemleri (EF Core, Repository Pattern), dış servis entegrasyonları gibi dışa bağımlı olan tüm işlemleri yürütür.

💻 Kullanılan Teknolojiler
Backend: ASP.NET Core 8

API: ASP.NET Core Web API

UI: ASP.NET Core MVC, Razor Pages, ViewComponents

Mimari: Onion Architecture (Soğan Mimarisi)

Veri Erişimi: Entity Framework Core 8, Repository Design Pattern

İş Mantığı: MediatR Kütüphanesi ile Mediator & CQRS Deseni

Kimlik Doğrulama & Yetkilendirme: JSON Web Token (JWT)

Validasyon: Fluent Validation

Gerçek Zamanlı İletişim: SignalR

Veritabanı İlişkileri: Çoktan-çoğa ilişkiler için Pivot Table (Junction Table) kullanımı

Modülerlik: Areas, ViewComponents
