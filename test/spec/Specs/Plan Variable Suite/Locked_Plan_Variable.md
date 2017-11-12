# Locked Plan Variable Does Not Change Value

-> id = b4ecee1b-9444-41ae-b17e-ca2e3178d54b
-> lifecycle = Acceptance
-> max-retries = 0
-> last-updated = 2017-11-12T23:10:25.1326076Z
-> tags = 

[PlanVariable]
|> LockedPlanVariable startValue=123.54
|> ChangeTheValue value=234.56
|> TheValueShouldBe value=123.54
~~~
