namespace variables
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.Linq;

    public class PlanVariable
    {
        private readonly decimal value;
        private readonly bool locked;
        private readonly string name;
        private ImmutableList<Action> subscribers;

        public PlanVariable(string name, decimal currentValue, bool locked, List<Action> subscribers)
        {
            this.subscribers = ImmutableList<Action>.Empty.AddRange(subscribers);
            (this.name, this.value, this.locked) = (name, currentValue, locked);
        }

        public decimal Value => value;
        public bool Locked => locked;
        public string Name => name;

        public PlanVariable Lock()
        {
            return new PlanVariable(this.name, this.value, true, this.subscribers.ToList());
        }

        public PlanVariable Unlock()
        {
            return new PlanVariable(this.name, this.value, false, this.subscribers.ToList());
        }

        public PlanVariable Update(decimal newValue)
        {
            if (this.Locked)
            {
                return this;
            }

            this.subscribers.ForEach(a => a.Invoke());
            return new PlanVariable(this.name, newValue, this.locked, this.subscribers.ToList());
        }
        public void Subscripe(Action action)
        {
            subscribers = subscribers.Add(action);
        }
    }
}
