

var builder = WebApplication.CreateBuilder(args);
var loggedInUsers = new Dictionary<Guid, string>();
var app = builder.Build();

bool IsAuthorized(HttpContext context, string requiredRole)
{
    if (context.Request.Headers.TryGetValue("SessionId", out var sessionIdString) &&
    Guid.TryParse(sessionIdString, out var sessionId) &&
    loggedInUsers.TryGetValue(sessionId, out var role) &&
    role == requiredRole)
    {
        return true;
    }
    return false;
}


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

Admin admin = new Admin("Joakim Villo", "jvillo");
Customer customer = new Customer("Bob Marley", 99, "bmarley");

library.AddNewAdmin(admin);
library.AddNewCustomer(customer);

app.MapPost("/login/admin", (LoginRequest loginRequest) =>
{
    Admin? admin = library.ValidateAdminCredentials(loginRequest.Username, loginRequest.Password);

    if (admin != null)
    {
        var sessionId = Guid.NewGuid();
        loggedInUsers[sessionId] = "Admin";
        return Results.Ok(new { Message = "Successfully logged in as admin", SessionId = sessionId });
    }
    else
    {
        return Results.Unauthorized();
    }
    // bool isLoggedIn = false;
    // Console.WriteLine("***Login to the library database as an admin***");
    // Console.WriteLine("Type in admin username:");
    // string? username = Console.ReadLine();

    // while (isLoggedIn == false)
    // {
    //     if (username == admin.UserName)
    //     {
    //         Console.WriteLine("Type in admin password:");
    //         string? password = Console.ReadLine();

    //         if (password == admin.AdminPassword)
    //         {
    //             isLoggedIn = true;
    //             Console.WriteLine("Successfully logged in as admin!");
    //             Console.WriteLine("You have access to the following:");
    //         }
    //         else
    //         {
    //             Console.WriteLine("Incorrect password");
    //         }
    //     }
    //     else
    //     {
    //         Console.WriteLine("Could not log in as " + username);
    //     }
    // }
});

app.MapGet("/admins", (HttpContext context) =>
{
    if (!IsAuthorized(context, "Admin"))
    {
        return Results.Unauthorized();
    }
    return Results.Ok(library.ListAllAdmins());
});

app.MapPost("/login/customer", (LoginRequest loginRequest) =>
{

    Customer? customer = library.ValidateCustomerCredentials(loginRequest.Username, loginRequest.Password);

    if (customer != null)
    {
        var sessionId = Guid.NewGuid();
        loggedInUsers[sessionId] = "Customer";
        return Results.Ok(new { Message = $"Successfully logged in as {customer.Fullname}", SessionId = sessionId });
    }
    else
    {
        return Results.Unauthorized();
    }

    // Console.WriteLine("***Login to the library database as an admin***");
    // Console.WriteLine("Type in your username:");
    // string? username = Console.ReadLine();


    // if (username == customer.UserName)
    // {
    //     Console.WriteLine("Type in your password:");
    //     string? password = Console.ReadLine();

    //     if (password == customer.CustomerPassword)
    //     {
    //         Console.WriteLine("Successfully logged in as " + customer.Fullname);
    //         Console.WriteLine("You have access to the following:");
    //     }
    //     else
    //     {
    //         Console.WriteLine("Incorrect password");
    //     }
    // }
    // else
    // {
    //     Console.WriteLine("Could not log in as " + username);
    // }
});


app.MapGet("/customers", (HttpContext context) =>
{
    if (!IsAuthorized(context, "Admin"))
    {
        return Results.Unauthorized();
    }
    return Results.Ok(library.ListAllCustomer());
});



app.MapGet("/book", () =>
{
    Console.WriteLine("Viewing all books");
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

app.MapPost("/book/borrow", (BorrowRequest request) =>
{
    Customer? customer = library.GetCustomerById(request.CustomerId);
    if (customer == null) return Results.NotFound("Customer not found");


    Book? book = library.LendBook(customer, request.Title);

    if (book == null)
    {
        return Results.NotFound();
    }
    else
    {
        Console.WriteLine("Book borrowed: " + book.Title);
        return Results.Ok(book);
    }
});

app.MapPost("/book/return", (ReturnRequest request) =>
{
    Book? book = library.ReturnBookById(request.BookId);

    if (book == null)
    {
        return Results.NotFound();
    }
    else
    {
        Console.WriteLine("Book returned: " + book.Title);
        return Results.Ok(book);
    }
});


app.Run();

