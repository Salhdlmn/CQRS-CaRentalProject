namespace CaRentalProject.CQRS.Commands.BookingCommands
{
    public class CreateBookingCommand
    {
        public string PickUpAirport { get; set; }
        public string DropOffAirport { get; set; }
        public DateTime PickUpDate { get; set; }
        public DateTime DropOffDate { get; set; }
        public int CarId { get; set; }

    }
}
