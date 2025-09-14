using CaRentalProject.Context;
using CaRentalProject.CQRS.Commands.CarCommands;

namespace CaRentalProject.CQRS.Handlers.CarHandlers
{
    public class UpdateCarCommandHandler
    {
        private readonly CaRentalContext _context;

        public UpdateCarCommandHandler(CaRentalContext context)
        {
            _context = context;
        }

        public async Task Handle(UpdateCarCommand command)
        {
            var value = await _context.Cars.FindAsync(command.CarId);

            value.Brand = command.Brand;
            value.Review = command.Review;
            value.Year = command.Year;
            value.Transmission = command.Transmission;
            value.Gear = command.Gear;
            value.Model = command.Model;
            value.Petrol = command.Petrol;
            value.ImageUrl = command.ImageUrl;
            value.Km = command.Km;
            value.PriceByDay = command.PriceByDay;
            value.Seat = command.Seat;

            await _context.SaveChangesAsync();
        }
    }
}
