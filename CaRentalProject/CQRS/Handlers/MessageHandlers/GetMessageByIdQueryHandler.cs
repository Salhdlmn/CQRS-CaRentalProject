using CaRentalProject.Context;
using CaRentalProject.CQRS.Queries.MessageQueries;
using CaRentalProject.CQRS.Results.MessageResults;
using Microsoft.EntityFrameworkCore;

namespace CaRentalProject.CQRS.Handlers.MessageHandlers
{
    public class GetMessageByIdQueryHandler
    {
        private readonly CaRentalContext _context;

        public GetMessageByIdQueryHandler(CaRentalContext context)
        {
            _context = context;
        }

        public async Task<GetMessageByIdQueryResult> Handle(GetMessageByIdQuery query)
        {
            var value = await _context.Messages.AsNoTracking().FirstOrDefaultAsync(x => x.MessageId == query.Id);

            return new GetMessageByIdQueryResult
            {
                MessageId = value.MessageId,
                Name = value.Name,
                Surname = value.Surname,
                Subject = value.Subject,
                MessageDetail = value.MessageDetail,
                Phone = value.Phone,
                Email = value.Email
            };
        }
    }
}
