namespace CaRentalProject.CQRS.Commands.ServiceCommands
{
    public class UpdateServiceCommand
    {
        public int ServiceId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string IconUrl { get; set; }
    }
}
