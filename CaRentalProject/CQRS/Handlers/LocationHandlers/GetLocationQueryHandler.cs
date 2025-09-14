using CaRentalProject.Context;
using CaRentalProject.CQRS.Results.LocationResults;
using Microsoft.EntityFrameworkCore;

namespace CaRentalProject.CQRS.Handlers.LocationHandlers
{
    public class GetLocationQueryHandler
    {
        private readonly CaRentalContext _context;

        public GetLocationQueryHandler(CaRentalContext context)
        {
            _context = context;
        }

        public async Task<List<GetLocationQueryResult>> Handle()
        {
            var values = await _context.Locations.AsNoTracking().ToListAsync();

            return values.Select(x => new GetLocationQueryResult
            {
                LocationId = x.LocationId,
                AirportCode = x.AirportCode,
                AirportId = x.AirportId,
                AirportName = x.AirportName,
                AreaCode = x.AreaCode,
                City = x.City,
                Country = x.Country,
                Latitude = x.Latitude,
                Longitude = x.Longitude
            }).ToList();
        }
    }
}
