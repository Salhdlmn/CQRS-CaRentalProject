using CaRentalProject.Context;
using CaRentalProject.CQRS.Commands.LocationCommands;

namespace CaRentalProject.CQRS.Handlers.LocationHandlers
{
    public class UpdateLocationCommandHandler
    {
        private readonly CaRentalContext _context;

        public UpdateLocationCommandHandler(CaRentalContext context)
        {
            _context = context;
        }

        public async Task Handle(UpdateLocationCommand command)
        {
            var value = await _context.Locations.FindAsync(command.LocationId);

            value.AirportId = command.AirportId;
            value.AirportName = command.AirportName;
            value.Longitude = command.Longitude;
            value.Latitude = command.Latitude;
            value.AirportCode = command.AirportCode;
            value.AreaCode = command.AreaCode;
            value.City = command.City;
            value.Country = command.Country;
            await _context.SaveChangesAsync();
        }
    }
}
