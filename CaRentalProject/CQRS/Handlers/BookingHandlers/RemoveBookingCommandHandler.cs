using CaRentalProject.Context;
using CaRentalProject.CQRS.Commands.BookingCommands;

namespace CaRentalProject.CQRS.Handlers.BookingHandlers
{
    public class RemoveBookingCommandHandler
    {
        private readonly CaRentalContext _context;

        public RemoveBookingCommandHandler(CaRentalContext context)
        {
            _context = context;
        }

        public async Task Handle(RemoveBookingCommand command)
        {
            var value = await _context.Bookings.FindAsync(command.Id);
            _context.Bookings.Remove(value);
            await _context.SaveChangesAsync(); 
        }
    }
}
