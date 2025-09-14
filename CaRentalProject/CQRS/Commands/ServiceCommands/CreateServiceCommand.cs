namespace CaRentalProject.CQRS.Commands.ServiceCommands
{
    public class CreateServiceCommand
    {   
        public string Title { get; set; }
        public string Description { get; set; }
        public string IconUrl { get; set; }
    }
}
