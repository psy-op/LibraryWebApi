using LMS.BL.DI;
using LMS.Interface;
using Microsoft.EntityFrameworkCore;
using Testing.LMS.DAL.EF;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddControllers();
builder.Services.AddControllersWithViews();
builder.Services.AddSession();

builder.Services.AddDbContext<EFContext>(options =>
    options.UseSqlServer(@"Data Source=AHMEDPC\MSSQLSERVER02;Initial Catalog=Testing;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"));
builder.Services.AddTransient<IBookManager, Book>();
builder.Services.AddTransient<IUserManager, User>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
