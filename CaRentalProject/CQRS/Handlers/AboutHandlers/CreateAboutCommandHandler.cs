using CaRentalProject.Context;
using CaRentalProject.CQRS.Commands.AboutCommands;
using CaRentalProject.Entities;

namespace CaRentalProject.CQRS.Handlers.AboutHandlers
{
    public class CreateAboutCommandHandler
    {
        private readonly CaRentalContext _context;

        public CreateAboutCommandHandler(CaRentalContext context)
        {
            _context = context;
        }

        public async Task Handle(CreateAboutCommand command)
        {
            _context.Abouts.Add(new About
            {
                Description = command.Description,
                Mision = command.Mision,
                Vision = command.Vision
            });
            await _context.SaveChangesAsync();
        }

    }
}
