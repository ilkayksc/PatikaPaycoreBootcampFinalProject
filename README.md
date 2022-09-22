# Patika Paycore .Net/.Net Core Bootcamp Bitirme Projesi

Üye Olma,Üye Girişi Yapma,Ürün,Kategori ve Sipariş  Yönetimi gibi modülleri içeren bir .Net Core Web API uygulamasıdır.


## Kullanılan Teknoloji ve Kütüphaneler


<ul>
    <li>JWT Bearer</li>
    <li>AutoMapper</li>
    <li>Npgsql</li>
    <li>BackgrounWorkers</li>
    <li>NHibernate & Fluent NHibernate</li>
</ul>

## Uygulamanın Çalıştırılması
Uygulamanın çalıştırılabilmesi için yukarıda belirtilen teknoloji ve kütüphanelerin projeye dahil edilmesi gerekmektedir.
Gerekli kütüphaneler eklendikten sonra AppSettings.json dosyası içerisinde aşağıda belirtilen alanlardaki bilgilerin girilmesi gerekmektedir.
Bilgileri girdikten sonra uygulamayı çalıştırabilirsiniz.

###### Veri Tabanı Baglantı Ayarları
```json
"AllowedHosts": "*",
    "ConnectionStrings": { 
    "PostgreSqlConnection": "User ID = '';Password = '';Server='' ;Port='' ;Database = '';Integrated Security= true;Pooling= true;" 
  }
```
###### JWT Ayarları
```json
"JwtConfig": {
  
    "Secret": "",
    "Issuer": "",
    "Audience": "",
    "AccessTokenExpiration": 
 
  }
```

###### Smtp Ayarları
```json
"SmtpConnectionString": {
    "UserName": "", 
    "Password": "",
    "Host": "",
    "Port": 
  }
```

## API Kullanımı
### Account

Sisteme giriş yapabilmek için ilk önce kaydı oluşturmanız gerekmektedir.

#### Register
| Parametre | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `Name`      | `string` | **Zorunlu**. Vehicle Id |
| `Surname`      | `string` | **Zorunlu**. Vehicle Id |
| `Email`      | `string` | **Zorunlu**. Email (patika@patika.com formatında geçerli bir e-mail olmak zorundadır.) |
| `Password`      | `string` | **Zorunlu**. Şifre (8-20 karakter arası olmak zorundadır.) |
| `DateOfBirth`      | `datetime` | Doğum Tarihi |
| `PhoneNumber`      | `string` |  Telefon Numarası(+90 555 555 55 55 formatında geçerli bir numara olmalıdır.)|

#### Login

Kullanıcı kaydı oluşturduktan sonra kullanıcı adı ve şifrenizle giriş yapmanız ve cevap olarak dönülen token ile authorize olmanız gerekmektedir. 


| Parametre | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `Email`      | `string` | **Zorunlu**. Email (patika@patika.com formatında geçerli bir e-mail olmak zorundadır.) |
| `Password`      | `string` | **Zorunlu**. Şifre (8-20 karakter arası olmak zorundadır.) |

### Ürün

Buradan Ürün Ekleme,Tüm Ürünleri Listeleme ve Teklif Yapılabilir Ürünleri Listeleme İşlemleri Yapılabilir.

| Parametre | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `ProductName`      | `string` | **Zorunlu**. Ürün Adı  |
| `ProductDescription`      | `string` | **Zorunlu**. Ürün Açıklaması |
| `CategoryId`      | `long` | **Zorunlu**. Ürün Kategorisi |
| `Color`      | `long` | **Zorunlu**. Ürünün Rengi |
| `Price`      | `double` | **Zorunlu**. Ürün Fiyatı |
| `Brand`      | `string` | **Zorunlu**. Ürün Markası |
| `IsOfferable`      | `Bool` | **Zorunlu**. Teklif Edilebilir? (True,False) |
| `IsSold`      | `Bool` | **Zorunlu**. Ürün Satılabilir mi? (True,False)) |
| `ProductOwner`      | `long` | **Zorunlu**. Ürünün Satıcısı |

Listeleme işlemlerinde herhangi bir girdiye ihtiyaç yoktur.

### Teklif

Buradan Yeni Teklif Oluşturma,Kullanıcının Yaptığı Teklifleri Listeleme,Kullanıcının Sahibi Olduğu Ürünlere Yapılan Teklifleri Listeleme,Teklifi Onaylama/Reddetme İşlemleri Yapılabilir.

| Parametre | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `ProductId`      | `long` | **Zorunlu**. Ürün Kodu  |
| `Customer`      | `long` | **Zorunlu**. Teklif Yapan |
| `Price`      | `double` | **Zorunlu**. Ürün Fiyatı |
| `IsAccept`      | `Bool` | **Zorunlu**. Teklif Kabul Edildi mi? (True,False) |

Listeleme işlemlerinde herhangi bir girdiye ihtiyaç yoktur.

### Satınalma

Buradan Kabul Edilen Teklifleri Listeleyebilir,Direkt Satınalma İşlemleri Yapılabilir.

| Parametre | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `ProductId`      | `long` | **Zorunlu**. Ürün Kodu  |
| `Customer`      | `long` | **Zorunlu**. Teklif Yapan |
| `Price`      | `double` | **Zorunlu**. Ürün Fiyatı |
| `ProductOwner`      | `long` | **Zorunlu**. Ürünün Satıcısı |

Listeleme işlemlerinde herhangi bir girdiye ihtiyaç yoktur.

### Renk

Buradan Renk Ekleme,Silme,Listeleme ve Güncelleme İşlemleri Yapılabilir. 

| Parametre | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `ColorName`      | `string` | **Zorunlu**. Renk Adı|
| `ColorCode`      | `string` | **Zorunlu**. Renk Kodu (RGB,HEX vb.) |


Listeleme işlemlerinde herhangi bir girdiye ihtiyaç yoktur.

### Marka

Buradan Marka Ekleme,Silme,Listeleme ve Güncelleme İşlemleri Yapılabilir. 

| Parametre | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `BrandName`      | `string` | **Zorunlu**. Marka Adı|
| `BrandShortName`      | `string` | **Zorunlu**. Marka Kısa Adı |


Listeleme işlemlerinde herhangi bir girdiye ihtiyaç yoktur.

### Kategori

Buradan Kategori Ekleme,Silme,Listeleme ve Güncelleme İşlemleri Yapılabilir.Bu işlemleri yapabilmek için CategoryName ve Category Description bilgilerini girmeniz gerekmektedir.

| Parametre | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `CategoryName`      | `string` | **Zorunlu**. Kategori Adı|
| `CategoryDescription`      | `string` | **Zorunlu**. Kategori Açıklaması |

Listeleme işlemlerinde herhangi bir girdiye ihtiyaç yoktur.
