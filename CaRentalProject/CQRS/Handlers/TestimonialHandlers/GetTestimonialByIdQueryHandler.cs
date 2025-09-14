using CaRentalProject.Context;
using CaRentalProject.CQRS.Queries.TestimonialQueries;
using CaRentalProject.CQRS.Results.TestimonialResults;
using Microsoft.EntityFrameworkCore;

namespace CaRentalProject.CQRS.Handlers.TestimonialHandlers
{
    public class GetTestimonialByIdQueryHandler
    {
        private readonly CaRentalContext _context;

        public GetTestimonialByIdQueryHandler(CaRentalContext context)
        {
            _context = context;
        }

        public async Task<GetTestimonialByIdQueryResult> Handle(GetTestimonialByIdQuery query)
        {
            var value = await _context.Testimonials.AsNoTracking().FirstOrDefaultAsync(x => x.TestimonialId == query.Id);

            return new GetTestimonialByIdQueryResult
            {
                TestimonialId = value.TestimonialId,
                NameSurname = value.NameSurname,
                Comment = value.Comment,
                Star = value.Star,
                Profession = value.Profession,
                ImageUrl = value.ImageUrl
            };
        }
    }
}
