using CaRentalProject.Context;
using CaRentalProject.CQRS.Commands.FeatureCommands;

namespace CaRentalProject.CQRS.Handlers.FeatureHandlers
{
    public class RemoveFeatureCommandHandler
    {
        private readonly CaRentalContext _context;

        public RemoveFeatureCommandHandler(CaRentalContext context)
        {
            _context = context;
        }

        public async Task Handle(RemoveFeatureCommand command)
        {
            var value = await _context.Features.FindAsync(command.Id);

            _context.Features.Remove(value);

            await _context.SaveChangesAsync();

        }
    }
}
