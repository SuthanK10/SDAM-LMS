using System;
using System.Collections.Generic;

public class Library
{
    private List<Book> Books = new List<Book>();
    private List<Member> Members = new List<Member>();
    private List<BorrowRecord> BorrowRecords = new List<BorrowRecord>();
    private List<Reservation> Reservations = new List<Reservation>();

    public void AddBook(Book book)
    {
        Books.Add(book);
        Console.WriteLine($"Book '{book.Title}' added successfully.");
    }

    public void RegisterMember(Member member)
    {
        Members.Add(member);
        Console.WriteLine($"Member '{member.Name}' registered successfully.");
    }

    public void IssueBook(Member member, Book book)
    {
        if (book.CheckAvailability())
        {
            var record = new BorrowRecord(BorrowRecords.Count + 1, book, member);
            BorrowRecords.Add(record);
            Console.WriteLine($"Book '{book.Title}' issued to {member.Name}.");
        }
        else
        {
            Console.WriteLine("Book is not available for borrowing.");
        }
    }

    public void ReturnBook(Member member, Book book)
    {
        foreach (var record in BorrowRecords)
        {
            if (record.Book == book && record.Member == member && record.ReturnDate == null)
            {
                record.MarkAsReturned();
                Console.WriteLine($"Book '{book.Title}' returned by {member.Name}.");
                return;
            }
        }
        Console.WriteLine("No matching borrow record found.");
    }

    public void ReserveBook(Member member, Book book)
    {
        if (!book.CheckAvailability())
        {
            Reservations.Add(new Reservation(Reservations.Count + 1, book, member));
            Console.WriteLine($"Book '{book.Title}' reserved by {member.Name}.");
        }
        else
        {
            Console.WriteLine("Book is available. No need to reserve.");
        }
    }
}
