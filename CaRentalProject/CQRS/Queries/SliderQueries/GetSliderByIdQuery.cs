namespace CaRentalProject.CQRS.Queries.SliderQueries
{
    public class GetSliderByIdQuery
    {
        public int Id { get; set; }

        public GetSliderByIdQuery(int id)
        {
            Id = id;
        }
    }
}
