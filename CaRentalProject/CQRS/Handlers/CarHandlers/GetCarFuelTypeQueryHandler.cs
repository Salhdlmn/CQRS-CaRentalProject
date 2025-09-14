using CaRentalProject.Context;
using CaRentalProject.CQRS.Results.CarResults;

namespace CaRentalProject.CQRS.Handlers.CarHandlers
{
    public class GetCarFuelTypeQueryHandler
    {
        private readonly CaRentalContext _context;

        public GetCarFuelTypeQueryHandler(CaRentalContext context)
        {
            _context = context;
        }

        public List<GetCarFuelTypeQueryResult> Handle()
        {
            var result = _context.Cars
                .GroupBy(c => c.Petrol)
                .Select(g => new GetCarFuelTypeQueryResult
                {
                    FuelType = g.Key,
                    Count = g.Count()
                })
                .OrderBy(x => x.FuelType)
                .ToList();
            return result;
        }
    }
}
