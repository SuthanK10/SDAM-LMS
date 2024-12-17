using System;

public class BorrowRecord
{
    public int RecordID { get; private set; }
    public Book Book { get; private set; }
    public Member Member { get; private set; }
    public DateTime BorrowDate { get; private set; }
    public DateTime DueDate { get; private set; }
    public DateTime? ReturnDate { get; private set; }

    public BorrowRecord(int recordID, Book book, Member member)
    {
        RecordID = recordID;
        Book = book;
        Member = member;
        BorrowDate = DateTime.Now;
        DueDate = BorrowDate.AddDays(14);
        book.UpdateAvailability(false);
    }

    public void MarkAsReturned()
    {
        ReturnDate = DateTime.Now;
        Book.UpdateAvailability(true);
    }

    public double CalculateFine()
    {
        if (ReturnDate.HasValue && ReturnDate > DueDate)
        {
            return (ReturnDate.Value - DueDate).Days * 1.0; // $1 per day fine
        }
        return 0;
    }
}
