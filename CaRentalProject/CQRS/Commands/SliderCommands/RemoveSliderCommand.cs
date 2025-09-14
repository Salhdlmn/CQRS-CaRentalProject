namespace CaRentalProject.CQRS.Commands.SliderCommands
{
    public class RemoveSliderCommand
    {
        public int Id { get; set; }

        public RemoveSliderCommand(int id)
        {
            Id = id;
        }
    }
}
