using CaRentalProject.Context;
using CaRentalProject.CQRS.Results.FeatureResults;
using Microsoft.EntityFrameworkCore;

namespace CaRentalProject.CQRS.Handlers.FeatureHandlers
{
    public class GetFeatureQueryHandler
    {
        private readonly CaRentalContext _context;

        public GetFeatureQueryHandler(CaRentalContext context)
        {
            _context = context;
        }

        public async Task<List<GetFeatureQueryResult>> Handle()
        {
            var values = await _context.Features.ToListAsync();

            return values.Select(x => new GetFeatureQueryResult {
                FeatureId = x.FeatureId,
                Description = x.Description,
                Title = x.Title,
                IconUrl = x.IconUrl,
            }).ToList();
        }
    }
}
