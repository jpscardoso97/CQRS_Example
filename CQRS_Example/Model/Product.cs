namespace CQRS_Example.Model
{
    using CQRS_Example.Commands;
    using CQRS_Example.Queries;
    using System;

    public class Product
    {
        private readonly int _id;
        private string _description;

        public Product(int id, string desc)
        {
            _id = id;
            _description = desc;

            // Subscribing for these events
            Program.EventBroker.Commands += BrokerOnCommands;
            Program.EventBroker.Queries += BrokerOnQueries;
        }

        private void BrokerOnQueries(object sender, Query q)
        {
            var descriptionQuery = q as ProductDescriptionQuery;
            if (descriptionQuery?.Target == this)
            {
                descriptionQuery.Result = _description;
            }
        }

        private void BrokerOnCommands(object sender, Command c)
        {
            var descriptionChangeCommand = c as ChangeProductDescriptionCommand;
            if(descriptionChangeCommand?.Target == this)
            {
                this._description = descriptionChangeCommand.Description;
            }
        }


        public override string ToString()
        {
            return $"Id={_id}; Description={_description}";
        }
    }
}
