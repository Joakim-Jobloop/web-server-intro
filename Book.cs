class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public DateTime FirstPublished { get; set; }

    public Guid BookId { get; set; }

    public bool IsLent { get; set; }

    public Guid LentTo {get; set; }

    public Book(string title, string author, DateTime firstPublished)
    {
        Title = title;
        Author = author;
        FirstPublished = firstPublished;
        BookId = Guid.NewGuid();
        IsLent = false;
        LentTo = Guid.Empty;
    }
}


