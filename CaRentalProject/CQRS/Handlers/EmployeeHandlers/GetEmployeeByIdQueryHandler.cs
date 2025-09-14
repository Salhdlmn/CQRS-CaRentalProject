using CaRentalProject.Context;
using CaRentalProject.CQRS.Queries.EmployeeQueries;
using CaRentalProject.CQRS.Results.EmployeeResults;
using Microsoft.EntityFrameworkCore;

namespace CaRentalProject.CQRS.Handlers.EmployeeHandlers
{
    public class GetEmployeeByIdQueryHandler
    {
        private readonly CaRentalContext _context;

        public GetEmployeeByIdQueryHandler(CaRentalContext context)
        {
            _context = context;
        }

        public async Task<GetEmployeeByIdQueryResult> Handle(GetEmployeeByIdQuery query)
        {
            var value = await _context.Employees.AsNoTracking().FirstOrDefaultAsync(x => x.EmployeeId == query.Id);

            return new GetEmployeeByIdQueryResult
            {
                EmployeeId = value.EmployeeId,
                NameSurname = value.NameSurname,
                Profession = value.Profession,
                ImageUrl = value.ImageUrl
            };
        }
    }
}
