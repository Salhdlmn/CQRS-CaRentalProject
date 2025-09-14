using CaRentalProject.Context;
using CaRentalProject.CQRS.Commands.FeatureCommands;
using CaRentalProject.Entities;

namespace CaRentalProject.CQRS.Handlers.FeatureHandlers
{
    public class CreateFeatureCommandHandler
    {
        private readonly CaRentalContext _context;

        public CreateFeatureCommandHandler(CaRentalContext context)
        {
            _context = context;
        }

        public async Task Handle(CreateFeatureCommand command)
        {
            _context.Features.Add(new Feature
            {
                Description = command.Description,
                IconUrl = command.IconUrl,
                Title = command.Title,
            });

            await _context.SaveChangesAsync();
        }
    }
}
