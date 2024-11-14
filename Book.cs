class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public DateTime FirstPublished { get; set; }

    public string BookId { get; set; }

    public bool IsLent { get; set; }

    public Book(string title, string author, DateTime firstPublished, string bookId, bool isLent = false)
    {
        Title = title;
        Author = author;
        FirstPublished = firstPublished;
        BookId = bookId;
        IsLent = isLent;
    }
}


