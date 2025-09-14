using CaRentalProject.Context;
using CaRentalProject.CQRS.Queries.FeatureQueries;
using CaRentalProject.CQRS.Results.FeatureResults;
using Microsoft.EntityFrameworkCore;

namespace CaRentalProject.CQRS.Handlers.FeatureHandlers
{
    public class GetFeatureByIdQueryHandler
    {
        private readonly CaRentalContext _context;

        public GetFeatureByIdQueryHandler(CaRentalContext context)
        {
            _context = context;
        }

        public async Task<GetFeatureByIdQueryResult> Handle(GetFeatureByIdQuery query)
        {
            var value= await _context.Features.AsNoTracking().FirstOrDefaultAsync(x=>x.FeatureId==query.FeatureId);

            return new GetFeatureByIdQueryResult
            {
                FeatureId = value.FeatureId,
                Description = value.Description,
                IconUrl = value.IconUrl,
                Title = value.Title
            };
        }
    }
}
