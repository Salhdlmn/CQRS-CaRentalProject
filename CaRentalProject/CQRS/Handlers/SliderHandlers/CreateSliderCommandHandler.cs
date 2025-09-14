using CaRentalProject.Context;
using CaRentalProject.CQRS.Commands.SliderCommands;
using CaRentalProject.Entities;

namespace CaRentalProject.CQRS.Handlers.SliderHandlers
{
    public class CreateSliderCommandHandler
    {
        private readonly CaRentalContext _context;

        public CreateSliderCommandHandler(CaRentalContext context)
        {
            _context = context;
        }

        public async Task Handle(CreateSliderCommand command)
        {
            _context.Sliders.Add(new Slider
            {
                SubTitle = command.Title,
                Title = command.Title,
                ImageUrl = command.ImageUrl,
                CarouselClass = command.CarouselClass
            });

            await _context.SaveChangesAsync();
        }
    }
}
