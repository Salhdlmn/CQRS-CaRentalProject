using CaRentalProject.Context;
using CaRentalProject.CQRS.Commands.BookingCommands;

namespace CaRentalProject.CQRS.Handlers.BookingHandlers
{
    public class UpdateBookingCommandHandler
    {
        private readonly CaRentalContext _context;

        public UpdateBookingCommandHandler(CaRentalContext context)
        {
            _context = context;
        }

        public async Task Handle(UpdateBookingCommand command)
        {
            var value = await _context.Bookings.FindAsync(command.BookingId);

            value.DropOffAirport = command.DropOffAirport;
            value.DropOffDate = command.DropOffDate;
            value.PickUpDate = command.PickUpDate;
            value.PickUpAirport = command.PickUpAirport;
            value.CarId = command.CarId;    

            await _context.SaveChangesAsync();
        }
    }
}
