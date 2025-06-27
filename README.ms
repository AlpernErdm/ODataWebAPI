# 🌐 OData Query Parameters & Filters

Bu proje, ASP.NET Core ile OData destekli RESTful API uygulamasıdır. Aşağıda, OData ile desteklenen sorgu parametreleri ve örnek filtreleme ifadeleri yer almaktadır.

---

## 🔧 Genel Query Parametreleri

| Parametre         | Açıklama                              | Örnek Kullanım                    |
|-------------------|----------------------------------------|----------------------------------|
| `$count=true`     | Toplam kayıt sayısını döndürür         | `?$count=true`                  |
| `$top=10`         | En fazla 10 kayıt getirir              | `?$top=10`                      |
| `$skip=20`        | İlk 20 kaydı atlar                     | `?$skip=20`                     |
| `$select=Name`    | Yalnızca belirtilen alanları getirir   | `?$select=Name,Price`           |
| `$orderby=Name`   | Belirli bir alana göre sıralama yapar  | `?$orderby=Name desc`           |
| `$expand=Category`| İlgili tabloyu dahil eder (JOIN)       | `?$expand=Category`             |

---

## 🔎 Filtreleme (Filter) Örnekleri

### 📌 Karşılaştırma Operatörleri

```http
$filter=Name eq 'Domates'
$filter=Price ne 50
$filter=Quantity gt 100
$filter=Quantity ge 100
$filter=Quantity lt 50
$filter=Quantity le 50
