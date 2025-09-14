using CaRentalProject.Context;
using CaRentalProject.CQRS.Results.MessageResults;
using Microsoft.EntityFrameworkCore;

namespace CaRentalProject.CQRS.Handlers.MessageHandlers
{
    public class GetMessageQueryHandler
    {
        private readonly CaRentalContext _context;

        public GetMessageQueryHandler(CaRentalContext context)
        {
            _context = context;
        }

        public async Task<List<GetMessageQueryResult>> Handle()
        {
            var values = await _context.Messages.AsNoTracking().ToListAsync();

            return values.Select(x => new GetMessageQueryResult
            {
                MessageId = x.MessageId,
                Email = x.Email,
                MessageDetail = x.MessageDetail,
                Name = x.Name,
                Phone = x.Phone,
                Subject = x.Subject,
                Surname = x.Surname
            }).ToList();
        }
    }
}
