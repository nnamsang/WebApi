using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.SymbolStore;
using System.Net.WebSockets;
using System.Text;
using WebApi.Data.EF;
using WebApi.Data.Models;
using WebApi.Repository;

var builder = WebApplication.CreateBuilder(args);
// Đọc chuỗi kết nối từ cấu hình ứng dụng.
var configuration = new ConfigurationBuilder()
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json")
    .Build();

//cấu hình kết nối database
var connectionString = builder.Configuration.GetConnectionString("MyDbContext");
builder.Services.AddDbContext<QuanLyVatTuContext>(options =>
    options.UseSqlServer(connectionString));


builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IVatTuRepositoty, VatTuRepository>();
builder.Services.AddScoped<IPhieuDeNghiVatTuRepotirory, PhieuDeNghiVatTuRepository>();
//<<<<<<< Updated upstream
builder.Services.AddScoped<IChucVuRepository, ChucVuRepository>();
builder.Services.AddScoped<IKhoRepository, KhoRepository>();

//=======
builder.Services.AddScoped<IChiTietPhieuRepo, ChiTietPhieuRepo>();
builder.Services.AddScoped<IPhieuTrinhMuaRepo, PhieuTrinhMuaRepo>();
//>>>>>>> Stashed changes

//cấu hình root
builder.WebHost.UseWebRoot("wwwroot");

//map appsetting
var SecretKey = builder.Configuration["JWT:SecretKey"];
var SecretKeyBytes = Encoding.UTF8.GetBytes(SecretKey);




//cau hinh authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(
        opt =>
        {
            opt.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,

                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(SecretKeyBytes),

                ClockSkew = TimeSpan.Zero
            };
        });


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication();





var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<QuanLyVatTuContext>();
    dbContext.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(options =>
{
    options.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
});

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
