using CaRentalProject.Context;
using CaRentalProject.CQRS.Commands.MessageCommands;

namespace CaRentalProject.CQRS.Handlers.MessageHandlers
{
    public class RemoveMessageCommandHandler
    {
        private readonly CaRentalContext _context;

        public RemoveMessageCommandHandler(CaRentalContext context)
        {
            _context = context;
        }

        public async Task Handle(RemoveMessageCommand command)
        {
            var value = await _context.Messages.FindAsync(command.Id);

            _context.Messages.Remove(value);

            await _context.SaveChangesAsync();
        }

    }
}
