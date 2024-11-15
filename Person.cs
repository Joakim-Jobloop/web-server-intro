class Person
{
    // Data fields
    public List<Book> Books { get; set; }
    public string Fullname { get; set; }
    public int Age { get; set; }
    public Guid CustomerId { get; set; }

    // Configuration
    public Person(string fullname, int age)
    {
        Fullname = fullname;
        Age = age;
        CustomerId = Guid.NewGuid();
        Books = new List<Book>();
    }

    // Methods

    // Methods for library books:
    public List<Book> ListPersonBorrowedBooks()
    {
        return Books;
    }

    public void PersonBorrowBook(Book book)
    {
        Books.Add(book);
    }


    // Methods for person:
    // public Book? PersonBorrowedBooks()
    // {
    //     Book? book = books.Find((book) =>
    //     {
    //         return book.Title.Any() ? true : false;
    //     });
    //     return book;
    // }

    public void PersonReturnBook(Book returnedBook)
    {
        Books.Remove(returnedBook);

    }
}