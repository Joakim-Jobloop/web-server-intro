class Person
{
    // Data fields
    private List<Book> books;

    public string Fullname;
    public int Age;
    public string CustomerId;

    // Configuration
    public Person(string fullname, int age, string customerId) 
    {
        Fullname = fullname;
        Age = age;
        CustomerId = customerId;
        books = new List<Book>();
    }

    // Methods
    public void PersonBorrowBook(Book borrowedBook)
    {
        books.Add(borrowedBook);
    }
    
    public List<Book> ListBorrowedBooks()
    {
        return books;
    }
    public Book? PersonBorrowedBooks(string title)
    {
        Book? book = books.Find((book)=> {
        return book.Title.Any() ? true : false;
        });
        return book;
    }

    public void PersonReturnBook(Book returnedBook)
    {
        books.Remove(returnedBook);

    }
}