using CaRentalProject.Context;
using CaRentalProject.CQRS.Commands.LocationCommands;

namespace CaRentalProject.CQRS.Handlers.LocationHandlers
{
    public class RemoveLocationCommandHandler
    {
        private readonly CaRentalContext _context;

        public RemoveLocationCommandHandler(CaRentalContext context)
        {
            _context = context;
        }

        public async Task Handle(RemoveLocationCommand command)
        {
            var value = await _context.Locations.FindAsync(command.Id);
             
            _context.Locations.Remove(value);

            await _context.SaveChangesAsync();

        }
    }
}
