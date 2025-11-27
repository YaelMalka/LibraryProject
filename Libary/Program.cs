using Libary;
using Library.Core.Repositories;
using Library.Core.Services;
using Library.Data.Repositories;
using Library.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IBorrowRepository, BorrowRepository>();
builder.Services.AddScoped<IBorrowService,BorrowService>();

builder.Services.AddScoped <IBookRepository, BookRepository>();
builder.Services.AddScoped <IBookService, BookService>();

builder.Services.AddScoped <ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped <ICustomerService, CustomerService>();  

builder.Services.AddSingleton<DataContext>();

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
