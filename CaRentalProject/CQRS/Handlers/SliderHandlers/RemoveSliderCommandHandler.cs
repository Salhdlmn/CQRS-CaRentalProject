using CaRentalProject.Context;
using CaRentalProject.CQRS.Commands.SliderCommands;

namespace CaRentalProject.CQRS.Handlers.SliderHandlers
{
    public class RemoveSliderCommandHandler
    {
        private readonly CaRentalContext _context;

        public RemoveSliderCommandHandler(CaRentalContext context)
        {
            _context = context;
        }

        public async Task Handle(RemoveSliderCommand command)
        {
            var value = await _context.Sliders.FindAsync(command.Id);

            _context.Sliders.Remove(value);

            await _context.SaveChangesAsync();
        }

    }
}
