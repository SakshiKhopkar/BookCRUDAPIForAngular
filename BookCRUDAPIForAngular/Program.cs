using BookCRUDAPIForAngular.Data;
using BookCRUDAPIForAngular.Repositories;
using BookCRUDAPIForAngular.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddCors(options => options.AddDefaultPolicy(builder => builder.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader()));
var ConnectionStrings = builder.Configuration.GetConnectionString("defaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(op => op.UseSqlServer(ConnectionStrings));
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApiDemo", Version = "v1" });
});
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.UseSwagger();
app.UseCors();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApiDemo v1"));
app.Run();
