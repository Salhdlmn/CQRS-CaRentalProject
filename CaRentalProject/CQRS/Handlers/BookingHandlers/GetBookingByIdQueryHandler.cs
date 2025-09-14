using CaRentalProject.Context;
using CaRentalProject.CQRS.Queries.BookingQueries;
using CaRentalProject.CQRS.Results.BookingResults;
using Microsoft.EntityFrameworkCore;

namespace CaRentalProject.CQRS.Handlers.BookingHandlers
{
    public class GetBookingByIdQueryHandler
    {
        private readonly CaRentalContext _context;

        public GetBookingByIdQueryHandler(CaRentalContext context)
        {
            _context = context;
        }

        public async Task<GetBookingByIdQueryResult> Handle(GetBookingByIdQuery query)
        {
            var value = await _context.Bookings.Include(x => x.Car).AsNoTracking().FirstOrDefaultAsync(x => x.BookingId == query.Id);

            return new GetBookingByIdQueryResult
            {
                BookingId = value.BookingId,
                PickUpAirport = value.PickUpAirport,
                DropOffAirport = value.DropOffAirport,
                PickUpDate = value.PickUpDate,
                DropOffDate = value.PickUpDate,
                CarId = value.CarId,
                CarModel = value.Car.Model,
                CarBrand = value.Car.Brand
            };
        }
    }
}
