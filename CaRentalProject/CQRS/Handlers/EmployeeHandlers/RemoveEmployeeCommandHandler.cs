using CaRentalProject.Context;
using CaRentalProject.CQRS.Commands.EmployeeCommands;

namespace CaRentalProject.CQRS.Handlers.EmployeeHandlers
{
    public class RemoveEmployeeCommandHandler
    {
        private readonly CaRentalContext _context;

        public RemoveEmployeeCommandHandler(CaRentalContext context)
        {
            _context = context;
        }

        public async Task Handle(RemoveEmployeeCommand command)
        {
            var value =await _context.Employees.FindAsync(command.Id);
            _context.Employees.Remove(value);
            await _context.SaveChangesAsync();
        }
    }
}
