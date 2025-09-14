namespace CaRentalProject.CQRS.Queries.FeatureQueries
{
    public class GetFeatureByIdQuery
    {
        public int FeatureId { get; set; }

        public GetFeatureByIdQuery(int featureId)
        {
            FeatureId = featureId;
        }
    }
}
