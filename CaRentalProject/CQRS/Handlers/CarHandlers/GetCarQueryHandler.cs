using CaRentalProject.Context;
using CaRentalProject.CQRS.Results.CarResults;
using Microsoft.EntityFrameworkCore;

namespace CaRentalProject.CQRS.Handlers.CarHandlers
{
    public class GetCarQueryHandler
    {
        private readonly CaRentalContext _context;

        public GetCarQueryHandler(CaRentalContext context)
        {
            _context = context;
        }

        public async Task<List<GetCarQueryResult>> Handle()
        {
            var values = await _context.Cars.AsNoTracking().ToListAsync();

            return values.Select(x => new GetCarQueryResult
            {
                CarId = x.CarId,
                Brand = x.Brand,
                Gear = x.Gear,
                ImageUrl = x.ImageUrl,
                Km = x.Km,
                Model = x.Model,
                Petrol = x.Petrol,
                PriceByDay = x.PriceByDay,
                Review = x.Review,
                Seat = x.Seat,
                Transmission = x.Transmission,
                Year = x.Year
            }).ToList();
        }
    }
}
