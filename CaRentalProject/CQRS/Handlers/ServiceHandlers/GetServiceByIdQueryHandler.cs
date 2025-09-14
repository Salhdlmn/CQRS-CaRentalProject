using CaRentalProject.Context;
using CaRentalProject.CQRS.Queries.ServiceQueries;
using CaRentalProject.CQRS.Results.ServiceResults;
using Microsoft.EntityFrameworkCore;

namespace CaRentalProject.CQRS.Handlers.ServiceHandlers
{
    public class GetServiceByIdQueryHandler
    {
        private readonly CaRentalContext _context;

        public GetServiceByIdQueryHandler(CaRentalContext context)
        {
            _context = context;
        }

        public async Task<GetServiceByIdQueryResult> Handle(GetServiceByIdQuery query)
        {
            var value = await _context.Services.AsNoTracking().FirstOrDefaultAsync(x=>x.ServiceId==query.Id);
            return new GetServiceByIdQueryResult
            {
                ServiceId = value.ServiceId,
                Description = value.Description,
                IconUrl = value.IconUrl,
                Title = value.Title,

            };
        }
    }
}
