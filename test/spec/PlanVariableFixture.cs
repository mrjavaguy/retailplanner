namespace spec
{
    using StoryTeller;
    using variables;

    public class PlanVariableFixture : Fixture
    {
        public PlanVariableFixture()
        {
            Title = "Plan Variable Specification";
        }

        private PlanVariable variable;

        [FormatAs("Starting with a locked variable with {startValue}")]
        public void LockedPlanVariable(decimal startValue)
        {
            variable = new PlanVariable("spec", startValue, true);
        }

        [FormatAs("Starting with a unlocked variable with {startValue}")]
        public void UnlockedPlanVariable(decimal startValue)
        {
            variable = new PlanVariable("spec", startValue, false);
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
    }
}
