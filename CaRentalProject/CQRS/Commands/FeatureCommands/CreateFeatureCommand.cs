namespace CaRentalProject.CQRS.Commands.FeatureCommands
{
    public class CreateFeatureCommand
    {
        
        public string Title { get; set; }
        public string Description { get; set; }
        public string IconUrl { get; set; }
    }
}
