using CaRentalProject.Context;
using CaRentalProject.CQRS.Commands.ServiceCommands;
using CaRentalProject.Entities;

namespace CaRentalProject.CQRS.Handlers.ServiceHandlers
{
    public class CreateServiceCommandHandler
    {
        private readonly CaRentalContext _context;

        public CreateServiceCommandHandler(CaRentalContext context)
        {
            _context = context;
        }

        public async Task Handle(CreateServiceCommand command)
        {
            _context.Services.Add(new Service
            {
                Description = command.Description,
                IconUrl = command.IconUrl,
                Title = command.Title,
            });
            await _context.SaveChangesAsync();
        }
    }
}
