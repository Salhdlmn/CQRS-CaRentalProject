namespace CaRentalProject.CQRS.Commands.MessageCommands
{
    public class RemoveMessageCommand
    {
        public int Id { get; set; }

        public RemoveMessageCommand(int id)
        {
            Id = id;
        }
    }
}
