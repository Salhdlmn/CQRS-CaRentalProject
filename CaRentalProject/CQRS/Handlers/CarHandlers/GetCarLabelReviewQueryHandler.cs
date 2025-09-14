using CaRentalProject.Context;
using CaRentalProject.CQRS.Results.CarResults;

namespace CaRentalProject.CQRS.Handlers.CarHandlers
{
    public class GetCarLabelReviewQueryHandler
    {
        private readonly CaRentalContext _context;

        public GetCarLabelReviewQueryHandler(CaRentalContext context)
        {
            _context = context;
        }

        public List<GetCarLabelReviewQueryResult> Handle()
        {
            var result = _context.Cars
                .GroupBy(c => c.Brand)
                .Select(g => new GetCarLabelReviewQueryResult
                {
                    Brand = g.Key,
                    AvgReview = Math.Round(g.Average(x => (double)x.Review), 2)
                })
                .OrderBy(x => x.Brand)
                .ToList();

            return result;
        }
    }
}
