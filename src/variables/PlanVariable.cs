namespace variables
{
    using System;

    public class PlanVariable
    {
        private decimal value;
        private bool locked;
        private string name;

        public PlanVariable(string name, decimal currentValue, bool locked)
        {
            (this.name, value, this.locked) = (name, currentValue, locked);
        }

        public decimal Value => value;
        public bool Locked => locked;
        public string Name => name;

        public PlanVariable Lock()
        {
            return new PlanVariable(this.name, this.value, true);
        }

        public PlanVariable Unlock()
        {
            return new PlanVariable(this.name, this.value, false);
        }

        public PlanVariable Update(decimal newValue)
        {
            if (this.Locked)
            {
                return this;
            }

            return new PlanVariable(this.name, newValue, this.locked);
        }
    }
}
