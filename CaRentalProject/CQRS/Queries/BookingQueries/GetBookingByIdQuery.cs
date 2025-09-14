namespace CaRentalProject.CQRS.Queries.BookingQueries
{
    public class GetBookingByIdQuery
    {
        public GetBookingByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }

  
    }
}
