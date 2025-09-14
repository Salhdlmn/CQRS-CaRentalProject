using CaRentalProject.Context;
using CaRentalProject.CQRS.Commands.CarCommands;
using CaRentalProject.Entities;

namespace CaRentalProject.CQRS.Handlers.CarHandlers
{
    public class CreateCarCommandHandler
    {
        private readonly CaRentalContext _context;

        public CreateCarCommandHandler(CaRentalContext context)
        {
            _context = context;
        }

        public async Task Handle(CreateCarCommand command)
        {
            _context.Cars.Add(new Car
            {
                Brand = command.Brand,
                Gear = command.Gear,
                ImageUrl = command.ImageUrl,
                Km = command.Km,
                Model = command.Model,
                Petrol = command.Petrol,
                PriceByDay = command.PriceByDay,
                Review = command.Review,
                Seat = command.Seat,
                Transmission = command.Transmission,
                Year = command.Year,

            });

            await _context.SaveChangesAsync();
        }
    }
}
