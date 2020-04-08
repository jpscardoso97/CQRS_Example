using CQRS_Example.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CQRS_Example.Events
{
    public class ProductDescriptionChangedEvent : Event
    {
        public Product Target;
        public string OldDescription, NewDescription;

        public ProductDescriptionChangedEvent(Product target, string oldDescription, string newDescription)
        {
            Target = target;
            OldDescription = oldDescription;
            NewDescription = newDescription;
        }

        public override string ToString()
        {
            return $"Product description changed from {OldDescription} to {NewDescription}";
        }
    }
}
