# 🚙 ASP.NET Core 9.0 & CQRS ile Araç Kiralama Platformu  

Bu repository, **ASP.NET Core 9.0** ve **CQRS mimarisi** ile geliştirilmiş modern bir araç kiralama uygulamasını içerir.  
Projenin amacı yalnızca temel bir demo oluşturmak değil; aynı zamanda **gerçek dünyaya uyarlanabilir, sürdürülebilir ve genişletilebilir** bir altyapı geliştirmektir.  

---

## 📌 Genel Bakış  

- 🔹 **Mimari Yapı** → CQRS prensipleriyle okuma ve yazma operasyonları ayrıştırıldı.  
- 🔹 **Veritabanı** → MS SQL Server üzerinde ilişkisel tablolar tasarlandı.  
- 🔹 **UI Yapısı** → Tekrarlayan bileşenler ViewComponent ile izole edilerek yeniden kullanılabilirlik sağlandı.  
- 🔹 **API Entegrasyonları** → Yakıt fiyatları, havalimanları ve mesafe hesaplama servisleri uygulamaya entegre edildi.  

---

## 🚀 Öne Çıkan Özellikler  

- ⚛️ **ViewComponent Tabanlı UI** → Araç listeleri, maliyet hesaplama ve chatbot alanı bağımsız bileşenler halinde geliştirildi.  
- ⛽ **Yakıt Fiyatları API** → Türkiye’de güncel benzin, motorin ve LPG fiyatları  
- ✈️ **Havalimanı Servisi** → Tüm havalimanlarının dinamik listelenmesi  
- 📏 **Mesafe Hesaplama** → İki havalimanı arasındaki mesafenin otomatik hesaplanması  
- 🤖 **Chatbot Entegrasyonu** → Kullanıcı mesajlarını yanıtlayan basit yapay zekâ destekli bot  
- 🚗 **Araç Öneri Asistanı** → Kullanıcı ihtiyaçlarına göre SUV, sedan, ekonomik gibi kategorilerde araç tavsiyesi  

---

## 🎯 Projenin Amacı  

- 🎯 CQRS mimarisiyle **okunabilir ve sürdürülebilir kod** üretmek  
- 📊 Gerçek API verileri ile **dinamik ve güvenilir** bir uygulama geliştirmek  
- 🧩 **Sektörel uygulamalara uyarlanabilecek** sağlam bir temel oluşturmak  

---

## 🛠 Kullanılan Teknolojiler  

- 💻 **Backend:** ASP.NET Core 9.0  
- 🗂 **Mimari:** CQRS (Command–Query Ayrımı) + Folder Structure  
- 🗄️ **Database:** MS SQL Server  
- 🖼 **UI Yönetimi:** ViewComponent  
- 🎨 **Frontend:** HTML5
