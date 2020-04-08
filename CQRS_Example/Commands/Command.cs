namespace CQRS_Example.Commands
{
    public class Command
    {
        public bool RegisterEvent;

        public Command(bool registerEvent = true)
        {
            RegisterEvent = registerEvent;
        }
    }
}
