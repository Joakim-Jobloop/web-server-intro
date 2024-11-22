class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public DateTime PublicationDate { get; set; }

    public Guid BookId { get; set; }

    public bool IsLent { get; set; }

    public Guid LentTo { get; set; }

    public Book(string title, string author, DateTime publicationDate)
    {
        Title = title;
        Author = author;
        PublicationDate = publicationDate;
        BookId = Guid.NewGuid();
        IsLent = false;
        LentTo = Guid.Empty;
    }
}


