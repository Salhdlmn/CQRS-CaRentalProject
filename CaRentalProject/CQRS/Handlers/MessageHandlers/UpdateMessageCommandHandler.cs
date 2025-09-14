using CaRentalProject.Context;
using CaRentalProject.CQRS.Commands.MessageCommands;

namespace CaRentalProject.CQRS.Handlers.MessageHandlers
{
    public class UpdateMessageCommandHandler
    {
        private readonly CaRentalContext _context;

        public UpdateMessageCommandHandler(CaRentalContext context)
        {
            _context = context;
        }


        public async Task Handle(UpdateMessageCommand command)
        {
            var value = await _context.Messages.FindAsync(command.MessageId);

            value.Surname = command.Surname;
            value.Name = command.Name;
            value.Phone = command.Phone;
            value.Email = command.Email;
            value.MessageDetail = command.MessageDetail;
            value.Subject = command.Subject;

            await _context.SaveChangesAsync();
        }
    }
}
