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
    options.UseSqlServer(@"Data Source=.;Initial Catalog=master;Integrated Security=True"));
builder.Services.AddTransient<IBookManager, BookSqlManager>();
builder.Services.AddTransient<IUserManager, UserSqlManager>();

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
