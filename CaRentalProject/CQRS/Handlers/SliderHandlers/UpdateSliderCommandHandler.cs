using CaRentalProject.Context;
using CaRentalProject.CQRS.Commands.SliderCommands;

namespace CaRentalProject.CQRS.Handlers.SliderHandlers
{
    public class UpdateSliderCommandHandler
    {
        private readonly CaRentalContext _context;

        public UpdateSliderCommandHandler(CaRentalContext context)
        {
            _context = context;
        }

        public async Task Handle(UpdateSliderCommand command)
        {
            var value = await _context.Sliders.FindAsync(command.SliderId);

            value.SubTitle = command.SubTitle;
            value.Title = command.Title;
            value.ImageUrl = command.ImageUrl;
            value.CarouselClass = command.CarouselClass;

            await _context.SaveChangesAsync();
        }
    }
}
