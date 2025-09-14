using CaRentalProject.Context;
using CaRentalProject.CQRS.Queries.CarQueries;
using CaRentalProject.CQRS.Results.CarResults;
using Microsoft.EntityFrameworkCore;

namespace CaRentalProject.CQRS.Handlers.CarHandlers
{
    public class GetCarByIdQueryHandler
    {
        private readonly CaRentalContext _context;

        public GetCarByIdQueryHandler(CaRentalContext context)
        {
            _context = context;
        }

        public async Task<GetCarByIdQueryResult>Handle(GetCarByIdQuery query)
        {
            var value = await _context.Cars.AsNoTracking().FirstOrDefaultAsync(x => x.CarId == query.Id);

            return new GetCarByIdQueryResult
            {
                CarId = value.CarId,
                Year = value.Year,
                Transmission = value.Transmission,
                Seat = value.Seat,
                Review = value.Review,
                PriceByDay = value.PriceByDay,
                Petrol = value.Petrol,
                Model = value.Model,
                Km = value.Km,
                ImageUrl = value.ImageUrl,
                Gear = value.Gear,
                Brand = value.Brand
            };
        }
    }
}
