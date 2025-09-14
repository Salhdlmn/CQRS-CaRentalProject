using CaRentalProject.Context;
using CaRentalProject.CQRS.Results.AboutResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CaRentalProject.CQRS.Handlers.AboutHandlers
{
    public class GetAboutQueryHandler
    {
        private readonly CaRentalContext _context;

        public GetAboutQueryHandler(CaRentalContext context)
        {
            _context = context;
        }

        public async Task<List<GetAboutQueryResult>> Handle()
        {
            var values = await _context.Abouts.AsNoTracking().ToListAsync();

            return  values.Select(x => new GetAboutQueryResult
            {
                AboutId = x.AboutId,
                Description = x.Description,
                Mision = x.Mision,
                Vision = x.Vision
            }).ToList();

        }
    }
}

