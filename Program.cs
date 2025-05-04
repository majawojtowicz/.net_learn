using Microsoft.EntityFrameworkCore;
using BookApi.Models;
using BookApi.Data;
using System.Diagnostics.Eventing.Reader;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BooksDbContext>(options =>
    options.UseSqlite("Data Source=books.db"));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<BooksDbContext>();
    db.Database.EnsureCreated();
}

app.MapGet("/api/books", async (BooksDbContext db) => await db.Books.ToListAsync());

app.MapGet("/api/books/{id}", async (int id, BooksDbContext db) =>
{
    var book = await db.Books.FindAsync(id);
    return book is not null ? Results.Ok(book) : Results.NotFound();
});

app.MapPost("/api/books", async (Book book, BooksDbContext db) =>
{
    db.Books.Add(book);
    await db.SaveChangesAsync();
    return Results.Created($"/api/books/{book.Id}",book);

});

app.MapPut("/api/books/{id}", async (int id, Book input, BooksDbContext db) =>
{
    var book = await db.Books.FindAsync(id);
    if (book == null) return Results.NotFound();

    book.Title=input.Title;
    book.Author=input.Author;
    book.PublishedYear=input.PublishedYear;
    book.IsRead=input.IsRead;
    await db.SaveChangesAsync();
    return Results.NoContent();
});

app.MapDelete("/api/books/{id}", async (int id, BooksDbContext db) =>
{
    var book = await db.Books.FindAsync(id);
    if ( book == null ) return Results.NotFound();

    db.Books.Remove(book);
    await db.SaveChangesAsync();
    return Results.NoContent();
});

app.Run();
