namespace Domain
{
    public class Flight
    {
        public int RemainingNumberOfSeats { get; private set; }

        private readonly List<Passenger> _bookingList = new();

        public IReadOnlyList<Passenger> Bookings => _bookingList;

        public Flight(int seatCapacity)
        {
            RemainingNumberOfSeats = seatCapacity;
        }

        public object? Book(string email, int seatAmount)
        {
            if (seatAmount > RemainingNumberOfSeats)
                return new OverBookingError();

            RemainingNumberOfSeats -= seatAmount;

            _bookingList.Add(new Passenger(email, seatAmount));

            return null;
        }
    }

    public class Passenger
    {
        public string Email { get; }
        public int BookedSeats { get; }

        public Passenger(string email, int bookedSeats)
        {
            Email = email;
            BookedSeats = bookedSeats;
        }
    }

    public class OverBookingError
    {

    }
}
