# Unlocked Plan Variable Does Change Value

-> id = 1bd0726f-c489-40f8-a04b-c88be5a2f7e7
-> lifecycle = Acceptance
-> max-retries = 0
-> last-updated = 2017-11-12T23:12:24.7478597Z
-> tags = 

[PlanVariable]
|> UnlockedPlanVariable startValue=123.45
|> ChangeTheValue value=234.56
|> TheValueShouldBe value=234.56
~~~
