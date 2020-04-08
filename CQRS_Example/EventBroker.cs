namespace CQRS_Example
{
    using CQRS_Example.Commands;
    using CQRS_Example.Events;
    using CQRS_Example.Queries;
    using System;
    using System.Collections.Generic;

    public class EventBroker
    {
        // All events that happened
        public IList<Event> Events = new List<Event>();

        // Commands
        public event EventHandler<Command> Commands;

        // Query
        public event EventHandler<Query> Queries;

        public T Query<T>(Query q)
        {
            Queries?.Invoke(this, q);

            return (T) q.Result;
        }

        public void Command(Command c)
        {
            Commands?.Invoke(this, c);
        }
    }
}
