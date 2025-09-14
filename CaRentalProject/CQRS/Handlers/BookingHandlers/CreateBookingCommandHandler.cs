using CaRentalProject.Context;
using CaRentalProject.CQRS.Commands.BookingCommands;
using CaRentalProject.Entities;

namespace CaRentalProject.CQRS.Handlers.BookingHandlers
{
    public class CreateBookingCommandHandler
    {
        private readonly CaRentalContext _context;

        public CreateBookingCommandHandler(CaRentalContext context)
        {
            _context = context;
        }

        public async Task Handle(CreateBookingCommand command)
        {
            _context.Bookings.Add(new Booking
            {
                DropOffAirport = command.DropOffAirport,
                PickUpAirport = command.PickUpAirport,
                CarId = command.CarId,
                DropOffDate = command.DropOffDate,
                PickUpDate = command.PickUpDate,
            });
            await _context.SaveChangesAsync();
        }
    }
}
