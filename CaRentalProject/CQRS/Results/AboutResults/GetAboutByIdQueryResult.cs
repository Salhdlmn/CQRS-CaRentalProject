namespace CaRentalProject.CQRS.Results.AboutResults
{
    public class GetAboutByIdQueryResult
    {
        public int AboutId { get; set; }
        public string Description { get; set; }
        public string Vision { get; set; }
        public string Mision { get; set; }
    }
}
