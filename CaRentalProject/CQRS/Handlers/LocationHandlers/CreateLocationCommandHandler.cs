using CaRentalProject.Context;
using CaRentalProject.CQRS.Commands.LocationCommands;
using CaRentalProject.Entities;

namespace CaRentalProject.CQRS.Handlers.LocationHandlers
{
    public class CreateLocationCommandHandler
    {
        private readonly CaRentalContext _context;

        public CreateLocationCommandHandler(CaRentalContext context)
        {
            _context = context;
        }

        public async Task Handle(CreateLocationCommand command)
        {
            _context.Locations.Add(new Location
            {
                AirportCode = command.AirportCode,
                AirportId = command.AirportId,
                AirportName = command.AirportName,
                AreaCode = command.AreaCode,
                City = command.City,
                Country = command.Country,
                Latitude = command.Latitude,
                Longitude = command.Longitude,                
            });
            await _context.SaveChangesAsync();  
        }
    }
}
