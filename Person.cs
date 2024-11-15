class Person
{
    // Data fields
    private List<Book> books;

    public string Fullname;
    public int Age;
    public Guid CustomerId;

    // Configuration
    public Person(string fullname, int age) 
    {
        Fullname = fullname;
        Age = age;
        CustomerId = Guid.NewGuid();
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