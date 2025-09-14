using CaRentalProject.Context;
using CaRentalProject.CQRS.Commands.CarCommands;
using CaRentalProject.CQRS.Queries.CarQueries;

namespace CaRentalProject.CQRS.Handlers.CarHandlers
{
    public class RemoveCarCommandHandler
    {
        private readonly CaRentalContext _context;

        public RemoveCarCommandHandler(CaRentalContext context)
        {
            _context = context;
        }

        public async  Task Handle(RemoveCarCommand command)
        {
            var value = await _context.Cars.FindAsync (command.Id);

            _context.Cars.Remove (value);

            await _context.SaveChangesAsync ();


        }
    }
}
