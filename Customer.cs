
class Customer
{
    // Data fields
    public List<Book> Books { get; set; }
    public string Fullname { get; set; }
    public int Age { get; set; }
    public Guid CustomerId { get; set; }
    public string CustomerPassword { get; set; }
    public bool IsAdmin { get; set; }

private static string CreateRandomPassword(int length = 15)
{
    // Define what character that can be used in the password:
    string validChars = "ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*?_-";
    // simplify the syntax of new Random():
    Random random = new Random();

    // Define chars that is of type characters in an array, set it to be a new array of characters with length of the parameter length
    char[] chars = new char[length];
    // run a standard for loop that runs with the parameter length:
    for (int i = 0; i < length; i++)
    {
        // for each looping it will add a random character to the array:
        chars[i] = validChars[random.Next(0, validChars.Length)];
    }
    // return the array as a string
    return new string(chars);
}

    // Configuration
    public Customer(string fullname, int age)
    {
        Fullname = fullname;
        Age = age;
        CustomerId = Guid.NewGuid();
        Books = new List<Book>();
        CustomerPassword = CreateRandomPassword();
        IsAdmin = false;
    }

    // Methods

    // Methods for library books:
    // public List<Book> ListBorrowedBooks()
    // {
    //     return Books;
    // }

    // public void BorrowBook(Book book)
    // {
    //     Books.Add(book);
    // }


    // public Book? LendBook(string title)
    // {
    //     Book? book = Books.Find((book) =>
    //     book.Title.Contains(title, StringComparison.OrdinalIgnoreCase) && !book.IsLent);

    //     if (book != null)
    //     {
    //         book.IsLent = true;
    //         return book;
    //     }
    //     return null;
    // }


    // public Book? ReturnBookBuyId(Guid id)
    // {
    //     Book? book = Books.Find((book) =>
    //     book.BookId == id && book.IsLent);

    //     if (book != null)
    //     {
    //         book.IsLent = false;
    //         book.LentTo = Guid.Empty;
    //         return book;
    //     }
    //     else
    //     {
    //         return null;
    //     }

    // }

    // public void PersonReturnBook(Book returnedBook)
    // {
    //     Books.Remove(returnedBook);

    // }
}