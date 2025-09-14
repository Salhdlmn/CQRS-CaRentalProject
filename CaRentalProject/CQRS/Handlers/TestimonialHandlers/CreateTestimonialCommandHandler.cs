using CaRentalProject.Context;
using CaRentalProject.CQRS.Commands.TestimonialCommands;
using CaRentalProject.Entities;

namespace CaRentalProject.CQRS.Handlers.TestimonialHandlers
{
    public class CreateTestimonialCommandHandler
    {
        private readonly CaRentalContext _context;

        public CreateTestimonialCommandHandler(CaRentalContext context)
        {
            _context = context;
        }

        public async Task Handle(CreateTestimonialCommand command)
        {
            _context.Testimonials.Add(new Testimonial
            {
                NameSurname = command.NameSurname,
                ImageUrl = command.ImageUrl,
                Profession = command.Profession,
                Comment = command.Comment,
                Star = command.Star
            });

            await _context.SaveChangesAsync();
        }
    }
}
