using CaRentalProject.Context;
using CaRentalProject.CQRS.Results.TestimonialResults;
using Microsoft.EntityFrameworkCore;

namespace CaRentalProject.CQRS.Handlers.TestimonialHandlers
{
    public class GetTestimonialQueryHandler
    {
        private readonly CaRentalContext _context;

        public GetTestimonialQueryHandler(CaRentalContext context)
        {
            _context = context;
        }


        public async Task<List<GetTestimonialQueryResult>> Handle()
        {
            var values = await _context.Testimonials.AsNoTracking().ToListAsync();

            return values.Select(x => new GetTestimonialQueryResult
            {
                TestimonialId = x.TestimonialId,
                NameSurname = x.NameSurname,
                ImageUrl = x.ImageUrl,
                Comment = x.Comment,
                Profession = x.Profession,
                Star = x.Star
            }).ToList();
        }
    }
}
