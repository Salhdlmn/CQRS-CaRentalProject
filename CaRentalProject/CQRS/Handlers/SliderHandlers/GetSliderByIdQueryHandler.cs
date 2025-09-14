using CaRentalProject.Context;
using CaRentalProject.CQRS.Queries.SliderQueries;
using CaRentalProject.CQRS.Results.SliderResults;
using Microsoft.EntityFrameworkCore;

namespace CaRentalProject.CQRS.Handlers.SliderHandlers
{
    public class GetSliderByIdQueryHandler
    {
        private readonly CaRentalContext _context;

        public GetSliderByIdQueryHandler(CaRentalContext context)
        {
            _context = context;
        }


        public async Task<GetSliderByIdQueryResult> Handle(GetSliderByIdQuery query)
        {
            var value = await _context.Sliders.AsNoTracking().FirstOrDefaultAsync(x => x.SliderId == query.Id);

            return new GetSliderByIdQueryResult
            {
                SliderId = value.SliderId,
                Title = value.Title,
                SubTitle = value.SubTitle,
                ImageUrl = value.ImageUrl,
                CarouselClass = value.CarouselClass
            };
        }
    }
}
