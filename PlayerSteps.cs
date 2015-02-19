using System;
using TechTalk.SpecFlow;

namespace ExamTest...
{
    [Binding]
    public class PlayerSteps
    {
        [Given(@"I have entered (.*) into the calculator")]
public void GivenIHaveEnteredIntoTheCalculator(int p0)
{
    ScenarioContext.Current.Pending();
}

        [When(@"I press add")]
public void WhenIPressAdd()
{
    ScenarioContext.Current.Pending();
}
    }
}
