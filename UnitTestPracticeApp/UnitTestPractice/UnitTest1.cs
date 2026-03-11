using Domain;
using FluentAssertions;

namespace UnitTestPractice
{
    public class UnitTest1
    {
        // TTD Naming Convention : Method_Scenario_ExpectedResult

        [Theory]
        [InlineData(12, 4)]
        [InlineData(30, 28)]
        [InlineData(18, 14)]
        ///<summary>
        /// SeatCapacity > BookedSeats Should return Null
        /// </summary>
        public void Book_WhenBookingDoNotExceedsCapacity_ShouldReturnNull(int seatCapacity, int bookedSeats)
        {
            var flight = new Flight(seatCapacity);
            var pass = flight.Book("adx2@gmail.com", bookedSeats);
            pass.Should().BeNull();
        }

        [Theory]
        [InlineData(5, 6)]
        [InlineData(34, 41)]
        [InlineData(29, 41)]
        ///<summary>
        /// BookedSeats > SeatCapacity Should return OverBookingError
        /// </summary>
        public void Book_WhenBookedSeatsExceedsCapacity_ShouldReturnOverBookingError(int seatCapacity, int bookedSeats)
        {
            // Arrange
            var flight = new Flight(seatCapacity: seatCapacity);

            // Act
            var error = flight.Book("dw", bookedSeats);

            // Assert
            error.Should().BeOfType<OverBookingError>();
        }
    }
}