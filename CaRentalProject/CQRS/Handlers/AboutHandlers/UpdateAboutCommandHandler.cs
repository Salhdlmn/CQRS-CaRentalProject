using CaRentalProject.Context;
using CaRentalProject.CQRS.Commands.AboutCommands;

namespace CaRentalProject.CQRS.Handlers.AboutHandlers
{
    public class UpdateAboutCommandHandler
    {
        private readonly CaRentalContext _context;

        public UpdateAboutCommandHandler(CaRentalContext context)
        {
            _context = context;
        }

        public async Task Handle(UpdateAboutCommand command)
        {
            var value = await _context.Abouts.FindAsync(command.AboutId);
             value.Description = command.Description;
            value.Vision = command.Vision;  
            value.Mision = command.Mision;  

            await _context.SaveChangesAsync();  
        }
    }
}
