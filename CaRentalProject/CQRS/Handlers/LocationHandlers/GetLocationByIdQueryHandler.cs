using CaRentalProject.Context;
using CaRentalProject.CQRS.Queries.LocationQueries;
using CaRentalProject.CQRS.Results.LocationResults;
using Microsoft.EntityFrameworkCore;

namespace CaRentalProject.CQRS.Handlers.LocationHandlers
{
    public class GetLocationByIdQueryHandler
    {
        private readonly CaRentalContext _context;

        public GetLocationByIdQueryHandler(CaRentalContext context)
        {
            _context = context;
        }

        public async Task<GetLocationByIdQueryResult> Handle(GetLocationByIdQuery query)
        {
            var value = await _context.Locations.AsNoTracking().FirstOrDefaultAsync(x => x.LocationId == query.Id);

            return new GetLocationByIdQueryResult
            {
                LocationId = value.LocationId,
                Longitude = value.Longitude,
                Latitude = value.Latitude,
                Country = value.Country,
                City = value.City,
                AreaCode = value.AreaCode,
                AirportName = value.AirportName,
                AirportId = value.AirportId,
                AirportCode = value.AirportCode
            };
        }
    }
}
