# TodosAPI

Basit bir Todo yönetim API'si - ASP.NET Core 8 ile geliştirilmiştir.

## Özellikler

- Todo ekleme, listeleme, güncelleme ve silme
- In-memory veritabanı (geliştirme için)
- RESTful API yapısı

## Teknolojiler

- .NET 8
- ASP.NET Core Web API
- Entity Framework Core (In-Memory)
- ASP.NET Identity, JWT 

## API Endpoints

- `GET /api/todos` - Tüm todoları listele
- `GET /api/todos/{id}` - Belirli bir todo'yu getir
- `POST /api/todos` - Yeni todo ekle
- `PUT /api/todos/{id}` - Todo güncelle
- `DELETE /api/todos/{id}` - Todo sil
