using CaRentalProject.Context;
using CaRentalProject.CQRS.Commands.FeatureCommands;

namespace CaRentalProject.CQRS.Handlers.FeatureHandlers
{
    public class UpdateFeatureCommandHandler
    {
        private readonly CaRentalContext _context;

        public UpdateFeatureCommandHandler(CaRentalContext context)
        {
            _context = context;
        }

        public async Task Handle(UpdateFeatureCommand command)
        {
            var value = await _context.Features.FindAsync(command.FeatureId);

            value.Description = command.Description;
            value.Title = command.Title;
            value.IconUrl = command.IconUrl;

            await _context.SaveChangesAsync();

        }
    }
}
