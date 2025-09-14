using CaRentalProject.Context;
using CaRentalProject.CQRS.Commands.MessageCommands;
using CaRentalProject.Entities;

namespace CaRentalProject.CQRS.Handlers.MessageHandlers
{
    public class CreateMessageCommandHandler
    {
        private readonly CaRentalContext _context;

        public CreateMessageCommandHandler(CaRentalContext context)
        {
            _context = context;
        }

        public async Task Handle(CreateMessageCommand command)
        {
            _context.Messages.Add(new Message
            {
                Email = command.Email,
                MessageDetail = command.MessageDetail,
                Name = command.Name,
                Phone = command.Phone,
                Subject = command.Subject,
                Surname = command.Surname,
            });

            await _context.SaveChangesAsync();  
        }
    }
}
