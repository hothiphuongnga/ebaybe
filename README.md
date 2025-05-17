# ebaybe

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

## 📂 Cấu trúc thư mục
DemoApiNet9/
│
├── Controllers/
│   └── ProductsController.cs
│
├── DTOs/
│   └── ProductDto.cs
│
├── Models/
│   └── Product.cs
│
├── Repositories/
│   ├── IProductRepository.cs
│   └── ProductRepository.cs
│
├── Services/
│   ├── IProductService.cs
│   └── ProductService.cs
│
├── Data/
│   ├── AppDbContext.cs // dùng cho code first
│
├── Program.cs
└── DemoApiNet9.csproj
## ▶️ Hướng dẫn chạy dự án
### ✅ 1. Cài đặt
`dotnet restore`
`dotnet build`
✅ 2. Cấu hình chuỗi kết nối
Trong appsettings.json:

json
Copy
Edit
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=DemoApiDb;User Id=sa;Password=yourpassword;"
}
✅ 3. Migrate DB (nếu dùng Code First)
bash
Copy
Edit
dotnet ef database update
✅ 4. Chạy ứng dụng
bash
Copy
Edit
dotnet run


