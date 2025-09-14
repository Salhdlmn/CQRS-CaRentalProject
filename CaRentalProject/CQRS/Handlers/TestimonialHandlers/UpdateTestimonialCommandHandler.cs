using CaRentalProject.Context;
using CaRentalProject.CQRS.Commands.TestimonialCommands;

namespace CaRentalProject.CQRS.Handlers.TestimonialHandlers
{
    public class UpdateTestimonialCommandHandler
    {
        private readonly CaRentalContext _context;

        public UpdateTestimonialCommandHandler(CaRentalContext context)
        {
            _context = context;
        }

        public async Task Handle(UpdateTestimonialCommand command)
        {
            var value = await _context.Testimonials.FindAsync(command.TestimonialId);

            value.NameSurname = command.NameSurname;
            value.Comment = command.Comment;
            value.Star = command.Star;
            value.Profession = command.Profession;
            value.ImageUrl = command.ImageUrl;

            await _context.SaveChangesAsync();
        }
    }
}
