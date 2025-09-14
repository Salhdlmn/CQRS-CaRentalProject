using CaRentalProject.Context;
using CaRentalProject.CQRS.Queries.AboutQueries;
using CaRentalProject.CQRS.Results.AboutResults;
using Microsoft.EntityFrameworkCore;

namespace CaRentalProject.CQRS.Handlers.AboutHandlers
{
    public class GetAboutByIdQueryHandler
    {
        private readonly CaRentalContext _context;

        public GetAboutByIdQueryHandler(CaRentalContext context)
        {
            _context = context;
        }

        public async Task<GetAboutByIdQueryResult>Handle(GetAboutByIdQuery query)
        {
            var value = await _context.Abouts.AsNoTracking().FirstOrDefaultAsync(x => x.AboutId == query.Id);

            return new GetAboutByIdQueryResult
            {
                AboutId = value.AboutId,
                Description = value.Description,
                Vision = value.Vision,
                Mision = value.Mision
            };
        }
    }
}
