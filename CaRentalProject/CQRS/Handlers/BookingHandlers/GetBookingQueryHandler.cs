using CaRentalProject.Context;
using CaRentalProject.CQRS.Results.BookingResults;
using Microsoft.EntityFrameworkCore;

namespace CaRentalProject.CQRS.Handlers.BookingHandlers
{
    public class GetBookingQueryHandler
    {
        private readonly CaRentalContext _context;

        public GetBookingQueryHandler(CaRentalContext context)
        {
            _context = context;
        }

        public async Task<List<GetBookingQueryResult>> Handle()
        {
            var values = await _context.Bookings.Include(x => x.Car).AsNoTracking().ToListAsync();
            return values.Select(x=>new GetBookingQueryResult
            {
                BookingId = x.BookingId,
                CarBrand=x.Car.Brand,
                CarId=x.CarId,
                CarModel=x.Car.Model,
                DropOffAirport=x.DropOffAirport,
                DropOffDate=x.DropOffDate,
               PickUpAirport = x.PickUpAirport,
               PickUpDate=x.PickUpDate
            }).ToList();
        }
    }
}
