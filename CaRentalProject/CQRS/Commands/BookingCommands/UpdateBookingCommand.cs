namespace CaRentalProject.CQRS.Commands.BookingCommands
{
    public class UpdateBookingCommand
    {
        public int BookingId { get; set; }
        public string PickUpAirport { get; set; }
        public string DropOffAirport { get; set; }
        public DateTime PickUpDate { get; set; }
        public DateTime DropOffDate { get; set; }
        public int CarId { get; set; }

    }
}
