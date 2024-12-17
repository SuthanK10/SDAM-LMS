using System;

public class Reservation
{
    public int ReservationID { get; private set; }
    public Book Book { get; private set; }
    public Member Member { get; private set; }
    public DateTime ReservationDate { get; private set; }

    public Reservation(int reservationID, Book book, Member member)
    {
        ReservationID = reservationID;
        Book = book;
        Member = member;
        ReservationDate = DateTime.Now;
    }

    public void ConfirmReservation()
    {
        Console.WriteLine($"Reservation {ReservationID} confirmed for '{Book.Title}' by {Member.Name}.");
    }
}


