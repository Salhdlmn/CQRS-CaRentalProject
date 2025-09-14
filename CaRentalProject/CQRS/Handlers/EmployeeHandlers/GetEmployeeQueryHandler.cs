using CaRentalProject.Context;
using CaRentalProject.CQRS.Results.EmployeeResults;
using Microsoft.EntityFrameworkCore;

namespace CaRentalProject.CQRS.Handlers.EmployeeHandlers
{
    public class GetEmployeeQueryHandler
    {
        private readonly CaRentalContext _context;

        public GetEmployeeQueryHandler(CaRentalContext context)
        {
            _context = context;
        }

        public async Task<List<GetEmployeeQueryResult>> Handle()
        {
            var values = await _context.Employees.AsNoTracking().ToListAsync();

            return values.Select(x => new GetEmployeeQueryResult
            {
                EmployeeId = x.EmployeeId,
                ImageUrl = x.ImageUrl,
                NameSurname = x.NameSurname,
                Profession = x.Profession
            }).ToList();
        }
    }
}
