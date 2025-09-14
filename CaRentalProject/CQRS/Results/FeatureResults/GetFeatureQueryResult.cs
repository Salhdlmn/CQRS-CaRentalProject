namespace CaRentalProject.CQRS.Results.FeatureResults
{
    public class GetFeatureQueryResult
    {
        public int FeatureId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string IconUrl { get; set; }
    }
}
