using CaRentalProject.Context;
using CaRentalProject.CQRS.Commands.ServiceCommands;

namespace CaRentalProject.CQRS.Handlers.ServiceHandlers
{
    public class UpdateServiceCommandHandler
    {
        private readonly CaRentalContext _context;

        public UpdateServiceCommandHandler(CaRentalContext context)
        {
            _context = context;
        }

        public async Task Handle(UpdateServiceCommand command)
        {
            var value =await _context.Services.FindAsync(command.ServiceId);

            value.Description = command.Description;
            value.Title = command.Title;
            value.IconUrl = command.IconUrl;
            await _context.SaveChangesAsync();

        }
    }
}
