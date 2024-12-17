using System;

public class Book
{
    public int BookID { get; private set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string ISBN { get; set; }
    public bool Availability { get; private set; }

    public Book(int bookID, string title, string author, string isbn)
    {
        BookID = bookID;
        Title = title;
        Author = author;
        ISBN = isbn;
        Availability = true;
    }

    public bool CheckAvailability()
    {
        return Availability;
    }

    public void UpdateAvailability(bool status)
    {
        Availability = status;
    }
}
