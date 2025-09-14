using CaRentalProject.Context;
using CaRentalProject.CQRS.Commands.MessageCommands;
using CaRentalProject.CQRS.Commands.ServiceCommands;
using CaRentalProject.CQRS.Queries.ServiceQueries;

namespace CaRentalProject.CQRS.Handlers.ServiceHandlers
{
    public class RemoveServiceCommandHandler
    {
        private readonly CaRentalContext _context;

        public RemoveServiceCommandHandler(CaRentalContext context)
        {
            _context = context;
        }

        public async Task Handle(RemoveServiceCommand command)
        {
            var value = await _context.Services.FindAsync(command.Id);

            _context.Services.Remove(value);

            await _context.SaveChangesAsync();
        }
    }
}
