using CaRentalProject.Context;
using CaRentalProject.CQRS.Results.ServiceResults;
using Microsoft.EntityFrameworkCore;

namespace CaRentalProject.CQRS.Handlers.ServiceHandlers
{
    public class GetServiceQueryHandler
    {
        private readonly CaRentalContext _context;

        public GetServiceQueryHandler(CaRentalContext context)
        {
            _context = context;
        }

        public async Task<List<GetServiceQueryResult>> Handle()
        {
            var values = await _context.Services.AsNoTracking().ToListAsync();

            return values.Select(x=>new GetServiceQueryResult
            {
                Description = x.Description,
               IconUrl = x.IconUrl,
               ServiceId = x.ServiceId,
               Title    = x.Title,
            }).ToList();
            
        }
    }
}
