var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

Library library = new Library();

Book cookWithGandalf = new Book("You Shall Not Fast: A Cookbook", "Gandalf the Grey", new DateTime(3019, 3, 25));
Book catGuide = new Book("How to Knock Over Everything", "Whiskers the Cat", new DateTime(2023, 1, 1));
Book elfPsychology = new Book("Am I Overthinking This?", "An Elf on the Shelf", new DateTime(2020, 12, 1));
Book programmerLife = new Book("Infinite Loops and Caffeine", "Anonymous Programmer", new DateTime(2024, 5, 7));
Book gymRegret = new Book("Never Leg Day", "Skip Legman", new DateTime(2022, 4, 12));
Book procrastinator = new Book("I'll Finish This Book Tomorrow", "Pro Crastinator", new DateTime(2025, 6, 30));
Book catSecrets = new Book("The Art of the Perfect Nap", "Garfield", new DateTime(1978, 6, 19));
Book sarcasmGuide = new Book("Oh, Really?", "Dr. Sarcasm", new DateTime(2018, 9, 15));
Book alienMemoirs = new Book("Earthlings: A Field Guide", "Zorg of Planet X", new DateTime(2050, 11, 11));
Book timeTravel = new Book("Oops, Wrong Century", "Time Traveler X", new DateTime(1805, 3, 14));
library.AddNewBook(cookWithGandalf);
library.AddNewBook(catGuide);
library.AddNewBook(catSecrets);
library.AddNewBook(elfPsychology);
library.AddNewBook(programmerLife);
library.AddNewBook(gymRegret);
library.AddNewBook(procrastinator);
library.AddNewBook(sarcasmGuide);
library.AddNewBook(alienMemoirs);
library.AddNewBook(timeTravel);

app.MapGet("/book", () =>
{
    return library.ListAllBooks();
});

app.MapGet("/book/available", () =>
{
    return library.ListAvailableBooks();
});

app.MapGet("/book/unavailable", () =>
{
    return library.ListUnavailableBooks();
});

app.MapPost("/book/borrow", (BorrowRequest request) => {
    Book? book = library.LendBook(request.Title);

    if (book == null)
    {
        return Results.NotFound();
    }
    else{
        Console.WriteLine("Book borrowed: " + book.Title);
        return Results.Ok(book);
    }
});

app.MapPost("/book/return", (ReturnRequest request) => {
    Book? book = library.ReturnBookBuyId(request.BookId);

    if (book == null)
    {
        return Results.NotFound();
    }
    else{
        Console.WriteLine("Book returned: " + book.Title);
        return Results.Ok(book);
    }
});




app.Run();
