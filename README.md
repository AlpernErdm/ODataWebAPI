
# 🧊 OData Query Parameters & Filters

Bu proje, **ASP.NET Core** ile OData destekli RESTful API uygulamasıdır. Aşağıda, OData ile desteklenen sorgu parametreleri ve örnek filtreleme ifadeleri yer almaktadır.

---

## 🛠 Genel Query Parametreleri

| Parametre            | Açıklama                              | Örnek Kullanım                  |
|----------------------|----------------------------------------|---------------------------------|
| `$count=true`        | Toplam kayıt sayısını döndürür         | `?$count=true`                  |
| `$top=10`            | En fazla 10 kayıt getirir              | `?$top=10`                      |
| `$skip=20`           | İlk 20 kaydı atlar                     | `?$skip=20`                     |
| `$select=Name`       | Sadece belirtilen alanları getirir     | `?$select=Name,Price`           |
| `$orderby=Name`      | Belirli bir alana göre sıralar         | `?$orderby=Name desc`           |
| `$expand=Category`   | İlgili tabloyu dahil eder (JOIN)       | `?$expand=Category`             |

---

## 🔎 Filtreleme (Filter) Örnekleri

### 🔗 Karşılaştırma Operatörleri

```
$filter=Name eq 'Domates'
$filter=Price ne 50
$filter=Quantity gt 100
$filter=Quantity ge 100
$filter=Quantity lt 50
$filter=Quantity le 50
```

---

### 🧠 Metin İşlemleri (String Functions)

```
$filter=startswith(Name, 'Dom')
$filter=endswith(Name, 'tes')
$filter=contains(Name, 'oma')
$filter=tolower(Name) eq 'domates'
$filter=toupper(Name) eq 'DOMATES'
$filter=trim(Name) eq 'Domates'
$filter=concat(Name, ' Fresh') eq 'Domates Fresh'
$filter=contains(tolower(Name), 'dom')
```

---

### ➗ Matematiksel Operatörler

```
$filter=Price add Quantity eq 150
$filter=Price sub 10 eq 40
$filter=Price mul 2 eq 100
$filter=Price div 2 eq 25
$filter=Price mod 3 eq 0
```

---

### 🔄 Mantıksal Operatörler

```
$filter=(Price gt 50) and (Quantity lt 200)
$filter=(Price lt 50) or (Quantity gt 300)
$filter=not (Price eq 50)
```

---

### 📅 Tarih/Zaman İşlemleri

```
$filter=OrderDate eq 2024-01-01T00:00:00Z
$filter=OrderDate ge 2024-01-01T00:00:00Z
$filter=OrderDate le 2024-12-31T23:59:59Z
$filter=year(OrderDate) eq 2024
$filter=month(OrderDate) eq 12
$filter=day(OrderDate) eq 29
$filter=hour(OrderDate) eq 14
$filter=minute(OrderDate) eq 30
$filter=second(OrderDate) eq 15
```

---

### 🔢 Diğer

```
$filter=Name eq null
$filter=Name ne null
$filter=Name in ('Domates', 'Biber', 'Patlıcan')
$filter=length(Name) eq 7
$filter=indexof(Name, 'oma') eq 1
$filter=substring(Name, 1, 3) eq 'oma'
```
