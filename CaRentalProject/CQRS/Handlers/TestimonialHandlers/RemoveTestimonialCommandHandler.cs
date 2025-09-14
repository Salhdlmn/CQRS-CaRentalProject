using CaRentalProject.Context;
using CaRentalProject.CQRS.Commands.TestimonialCommands;
using CaRentalProject.Entities;

namespace CaRentalProject.CQRS.Handlers.TestimonialHandlers
{
    public class RemoveTestimonialCommandHandler
    {
        private readonly CaRentalContext _context;

        public RemoveTestimonialCommandHandler(CaRentalContext context)
        {
            _context = context;
        }

        public async Task Handle(RemoveTestimonialCommand command)
        {
            var value = await _context.Testimonials.FindAsync(command.Id);

            _context.Testimonials.Remove(value);

            await _context.SaveChangesAsync();
        }
    }
}
