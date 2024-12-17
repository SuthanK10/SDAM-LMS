using System;
using System.Collections.Generic;

public class Member
{
    public int MemberID { get; private set; }
    public string Name { get; set; }
    public string ContactInfo { get; set; }
    public List<BorrowRecord> BorrowedBooks { get; private set; } = new List<BorrowRecord>();

    public Member(int memberID, string name, string contactInfo)
    {
        MemberID = memberID;
        Name = name;
        ContactInfo = contactInfo;
    }

    public void BorrowBook(Book book)
    {
        BorrowedBooks.Add(new BorrowRecord(BorrowedBooks.Count + 1, book, this));
        Console.WriteLine($"{Name} borrowed '{book.Title}'.");
    }
    public void ReturnBook(Book book)
    {
        var record = BorrowedBooks.Find(r => r.Book == book && r.ReturnDate == null);
        if (record != null)
        {
            record.MarkAsReturned();
            Console.WriteLine($"{Name} returned '{book.Title}'.");
        }
        else
        {
            Console.WriteLine("No record found for this book.");
        }

    }
}
