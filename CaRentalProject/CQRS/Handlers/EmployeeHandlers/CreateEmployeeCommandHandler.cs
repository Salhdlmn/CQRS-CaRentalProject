using CaRentalProject.Context;
using CaRentalProject.CQRS.Commands.EmployeeCommands;
using CaRentalProject.Entities;

namespace CaRentalProject.CQRS.Handlers.EmployeeHandlers
{
    public class CreateEmployeeCommandHandler
    {
        private readonly CaRentalContext _context;

        public CreateEmployeeCommandHandler(CaRentalContext context)
        {
            _context = context;
        }

        public async Task Handle(CreateEmployeeCommand command)
        {
            _context.Employees.Add(new Employee
            {
                ImageUrl = command.ImageUrl,
                Profession=command.Profession,
                NameSurname=command.NameSurname,

            });

            await _context.SaveChangesAsync();
        }
    }
}
