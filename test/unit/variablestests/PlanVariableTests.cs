namespace variables.tests
{
    using System;
    using System.Collections.Generic;
    using Xunit;

    public class PlanVariableTests
    {
        [Fact]
        public void LockedVariableValueDoesNotChange()
        {
            var variable = new PlanVariable(string.Empty, 100, true, new List<Action>());
            var attempt = variable.Update(200);

            Assert.Same(variable, attempt);
        }

        [Fact]
        public void UnlockedVariableValueDoesChange()
        {
            const decimal newValue = 200;
            var variable = new PlanVariable(string.Empty, 100, false, new List<Action>());
            var attempt = variable.Update(newValue);

            Assert.Equal(newValue, attempt.Value);
            Assert.NotSame(variable, attempt);
        }

        [Fact]
        public void StartWithUnlockAndThenLock()
        {
            const decimal newValue = 200;
            var variable = new PlanVariable(string.Empty, 100, false, new List<Action>());
            var locked = variable.Lock();
            var attempt = locked.Update(newValue);

            Assert.Equal(variable.Value, locked.Value);
            Assert.Same(locked, attempt);
        }

        [Fact]
        public void StartWithLockAndThenUnlock()
        {
            const decimal newValue = 200;
            var variable = new PlanVariable(string.Empty, 100, true, new List<Action>());
            var unlocked = variable.Unlock();
            var attempt = unlocked.Update(newValue);

            Assert.Equal(newValue, attempt.Value);
            Assert.NotSame(unlocked, attempt);
        }

        [Fact]
        public void EventHappensOnChangedValue()
        {
            var variable = new PlanVariable(string.Empty, 100, false, new List<Action>());
            var eventHappened = false;
            variable.Subscripe(() => eventHappened = true);
            variable.Update(200);
            Assert.True(eventHappened);
        }
    }
}
