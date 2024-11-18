class Library
{
    // Data fields
    private List<Book> books;
    private List<Customer> customers;
    private List<Admin> admins;

    // Configuration
    public Library()
    {
        books = new List<Book>();
        customers = new List<Customer>();
        admins = new List<Admin>();
    }


    // Admin Methods:
    public void AddNewAdmin(Admin newAdmin)
    {
        admins.Add(newAdmin);
    }

    // Customer Methods:
    public void AddNewCustomer(Customer newCustomer)
    {
        customers.Add(newCustomer);
    }

    public Customer? GetCustomerById(Guid id)
    {
        return customers.FirstOrDefault(customer => customer.CustomerId == id);
    }

    public List<Customer> ListAllCustomer()
    {
        return customers;
    }


    // Book Methods:
    public void AddNewBook(Book newBook)
    {
        books.Add(newBook);
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

    public Book? LendBook(Customer customer, string title)
    {
        Book? book = books.Find((book) =>
        book.Title.Contains(title, StringComparison.OrdinalIgnoreCase) && !book.IsLent);



        if (book != null)
        {
            book.IsLent = true;
            book.LentTo = customer.CustomerId;
            customer.Books.Add(book);
            return book;
        }
        return null;
    }


    public Book? ReturnBookBuyId(Guid id)
    {
        Book? book = books.Find((book) =>
        book.BookId == id && book.IsLent);

        if (book != null)
        {
            book.IsLent = false;
            book.LentTo = Guid.Empty;
            return book;
        }
        else
        {
            return null;
        }

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