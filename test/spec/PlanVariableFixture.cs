namespace spec
{
    using StoryTeller;
    using System.Collections.Generic;
    using variables;

    public class PlanVariableFixture : Fixture
    {
        public PlanVariableFixture()
        {
            Title = "Plan Variable Specification";
        }

        private PlanVariable variable;
        private bool eventSubscription = false;


        [FormatAs("Starting with a locked variable with {startValue}")]
        public void LockedPlanVariable(decimal startValue)
        {
            variable = new PlanVariable("spec", startValue, true, new List<System.Action>());
        }

        [FormatAs("Starting with a unlocked variable with {startValue}")]
        public void UnlockedPlanVariable(decimal startValue)
        {
            variable = new PlanVariable("spec", startValue, false, new List<System.Action>());
            variable.Subscripe(() => eventSubscription = true);
        }

        [FormatAs("Change the value {value}")]
        public void ChangeTheValue(decimal value)
        {
            variable = variable.Update(value);
        }

        [FormatAs("The value should be {value}")]
        public decimal TheValueShouldBe()
        {
            return variable.Value;
        }

        public bool AndEventIsRaised()
        {
            return eventSubscription;
        }
    }
}
