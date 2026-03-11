namespace Domain
{
    public class Flight
    {
        public int RemainingNumberOfSeats { get; set; }

        public Flight(int seatCapacity)
        {
            RemainingNumberOfSeats = seatCapacity;
        }

        public object? Book(string email, int seatAmount)
        {
            if (seatAmount > RemainingNumberOfSeats)
            {
                return new OverBookingError();
            }
            RemainingNumberOfSeats -= seatAmount;
            return null;
        }
    }

    public class OverBookingError
    {

    }
}
