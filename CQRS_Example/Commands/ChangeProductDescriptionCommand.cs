namespace CQRS_Example.Commands
{
    using CQRS_Example.Model;
    
    public class ChangeProductDescriptionCommand : Command
    {
        public Product Target;
        public string Description;

        public ChangeProductDescriptionCommand(
            Product target, 
            string description, 
            bool registerEvent = true)
            : base(registerEvent)
        {
            Target = target;
            Description = description;
        }
    }
}
