# Ebay_BE

# 🛒 Web API Demo Bán Hàng - ASP.NET Core

Dự án này là hệ thống Web API phục vụ cho ứng dụng bán hàng, được xây dựng bằng .NET 8/9 với mô hình chuẩn `Service - Repository`, sử dụng Entity Framework Core (Code First hoặc Database First), JWT Authentication và chuẩn hóa response bằng `ResponseEntity`.

---

## 🚀 Công nghệ sử dụng

- **.NET 9**
- **ASP.NET Core Web API**
- **Entity Framework Core** (Code First + Database First hỗ trợ)
- **SQL Server**
- **JWT Authentication**
- **System.Text.Json** (chuẩn JSON serialization)
- **Dependency Injection** & Middleware
- **RESTful API**

---


## ▶️ Hướng dẫn chạy dự án
### ✅ 1. Cài đặt
```cs
dotnet restore
```
```cs
dotnet build
```
### ✅ 2. Cấu hình chuỗi kết nối
Trong appsettings.json:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=DemoApiDb;User Id=sa;Password=yourpassword;"
}
```
✅ 3. Migrate DB (nếu dùng Code First)
```bash
dotnet ef database update
```
✅ 4. Chạy ứng dụng
```bash
dotnet run
```


