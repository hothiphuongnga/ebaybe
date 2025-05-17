using System.Text;
using ebaybe.Data;
using ebaybe.Repositories;
using ebaybe.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Cấu hình DbContext
// nếu code first thì dùng AddDbContext
// nếu database first thì dùng AddDbContextPool, tương dự cho cả dự án 
builder.Services.AddDbContext<DemoApiDbContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// DI
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<IAuthService, AuthService>();


// Controller
builder.Services.AddControllers();



builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!))
        };
    });

builder.Services.AddAuthorization();
var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthentication(); // nếu dùng JWT ⚠️ Phải trước UseAuthorization
app.UseAuthorization();
app.MapControllers();// nếu bạn dùng [ApiController]
app.Run();