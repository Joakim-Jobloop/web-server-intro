class Library
{
    // Data fields
    private List<Book> books;
    private List<Person> people;

    // Configuration
    public Library()
    {
        books = new List<Book>();
        people = new List<Person>();
    }

    // Methods, things we can do with the object
    public void AddNewBook(Book newBook)
    {
        books.Add(newBook);
    }

    public void AddNewPerson(Person newPerson)
    {
        people.Add(newPerson);
    }

    public List<Person> ListAllPeople()
    {
        return people;
    }

    public List<Book> ListAllBooks()
    {
        return books;
    }

    public List<Book> ListAvailableBooks()
    {
        return books.Where(book => !book.IsLent).ToList();
    }

      public List<Book> ListUnavailableBooks()
    {
        return books.Where(book => book.IsLent).ToList();
    }

    public Book? LendBook(string title)
    {
        Book? book = books.Find((book) =>
        book.Title.Contains(title, StringComparison.OrdinalIgnoreCase) && !book.IsLent);

        if (book != null)
        {
            book.IsLent = true;
            return book;
        }
        return null;
    }


public Book? ReturnBookBuyId(Guid id)
    {
        Book? book = books.Find((book) =>
        book.BookId.Equals(id) && book.IsLent);

        if (book != null)
        {
            book.IsLent = false;
            return book;
        }
        return null;
    }

//    public Book? ReturnBookByName(string title)
//     {
//         Book? book = books.Find((book) =>
//         book.Title.Contains(title, StringComparison.OrdinalIgnoreCase) && book.IsLent);

//         if (book != null)
//         {
//             book.IsLent = false;
//             return book;
//         }
//         return null;
//     }

}