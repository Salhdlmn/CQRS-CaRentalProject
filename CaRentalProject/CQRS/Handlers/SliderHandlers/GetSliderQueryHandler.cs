using CaRentalProject.Context;
using CaRentalProject.CQRS.Results.SliderResults;
using Microsoft.EntityFrameworkCore;

namespace CaRentalProject.CQRS.Handlers.SliderHandlers
{
    public class GetSliderQueryHandler
    {
        private readonly CaRentalContext _context;

        public GetSliderQueryHandler(CaRentalContext context)
        {
            _context = context;
        }

        public async Task<List<GetSliderQueryResult>> Handle()
        {
            var values = await _context.Sliders.AsNoTracking().ToListAsync();

            return values.Select(x => new GetSliderQueryResult
            {
                SliderId = x.SliderId,
                Title = x.Title,
                ImageUrl = x.ImageUrl,
                SubTitle = x.SubTitle,
                CarouselClass = x.CarouselClass

            }).ToList();
        }
    }
}
