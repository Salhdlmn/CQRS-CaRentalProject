using CaRentalProject.Context;
using CaRentalProject.CQRS.Commands.EmployeeCommands;

namespace CaRentalProject.CQRS.Handlers.EmployeeHandlers
{
    public class UpdateEmployeeCommandHandler
    {
        private readonly CaRentalContext _context;

        public UpdateEmployeeCommandHandler(CaRentalContext context)
        {
            _context = context;
        }

        public async Task Handle(UpdateEmployeeCommand command)
        {
            var value = await _context.Employees.FindAsync(command.EmployeeId);
            value.NameSurname = command.NameSurname;
            value.Profession = command.Profession;
            value.ImageUrl = command.ImageUrl;

            await _context.SaveChangesAsync();
        }
    }
}
