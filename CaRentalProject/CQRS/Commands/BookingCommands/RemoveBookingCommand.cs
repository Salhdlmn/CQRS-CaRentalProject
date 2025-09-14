namespace CaRentalProject.CQRS.Commands.BookingCommands
{
    public class RemoveBookingCommand
    {
        public int Id { get; set; }

        public RemoveBookingCommand(int id)
        {
            Id = id;
        }
    }
}
