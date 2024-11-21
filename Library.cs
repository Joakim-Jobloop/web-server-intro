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
        if (admins.Any(admin => admin.UserName == newAdmin.UserName))
        {
            throw new ArgumentException("An admin with this username already exists.");
        }

        admins.Add(newAdmin);
    }

    public List<Admin> ListAllAdmins()
    {
        return admins;
    }

    public Admin? ValidateAdminCredentials(string username, string password)
    {
        return admins.FirstOrDefault(admin => admin.UserName == username && admin.Password == password);
    }

    // Customer Methods:
    public void AddNewCustomer(Customer newCustomer)
    {
        customers.Add(newCustomer);
    }

    public Customer? ValidateCustomerCredentials(string username, string password)
    {
        return customers.FirstOrDefault(customer => customer.UserName == username && customer.Password == password);
    }

    public Customer? GetCustomerById(Guid id)
    {
        return customers.FirstOrDefault(customer => customer.Id == id);
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

        if (book == null)
        {
            return null;
        }
        book.IsLent = true;
        book.LentTo = customer.Id;
        customer.Books.Add(book);
        return book;

    }


    public Book? ReturnBookById(Guid id)
    {
        Book? book = books.Find((book) =>
        book.BookId == id && book.IsLent);

        if (book != null)
        {
            book.IsLent = false;
            book.LentTo = Guid.Empty;
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