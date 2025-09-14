using CaRentalProject.Context;
using CaRentalProject.CQRS.Commands.AboutCommands;
using CaRentalProject.CQRS.Queries.AboutQueries;

namespace CaRentalProject.CQRS.Handlers.AboutHandlers
{
    public class RemoveAboutCommandHandler

    {
        private readonly CaRentalContext _context;

        public RemoveAboutCommandHandler(CaRentalContext context)
        {
            _context = context;
        }

        public async Task Handle(RemoveAboutCommand command)
        {
            var value = await _context.Abouts.FindAsync(command.Id);
            _context.Abouts.Remove(value);
            await _context.SaveChangesAsync();
        }
    }
}
