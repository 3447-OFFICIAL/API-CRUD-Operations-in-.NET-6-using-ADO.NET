using assignment_1.Data;
using assignment_1.Models;

var builder = WebApplication.CreateBuilder(args);

//Call connection string
var connectionString = builder.Configuration.GetSection("ConnectionStrings")["BookApi_Db"].ToString();

//Create an instance of the Sqlcrud class with the connection string
SqlCrud sql = new SqlCrud(connectionString);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.MapGet("/", () => "Hello World!!!");

app.MapGet("/api/GetAllBooks", () => sql.GetAllBooks());

app.MapGet("/api/GetBookById/{id}", (int id) => sql.GetBookById(id));

app.MapPost("/api/InsertBook", (BookModel book) => sql.PostNewBook(book));


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
