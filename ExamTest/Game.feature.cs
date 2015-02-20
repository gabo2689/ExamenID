﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.9.0.77
//      SpecFlow Generator Version:1.9.0.0
//      Runtime Version:4.0.30319.34014
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace ExamTest
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class GameFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "Game.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Game", "", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassCleanupAttribute()]
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestInitializeAttribute()]
        public virtual void TestInitialize()
        {
            if (((TechTalk.SpecFlow.FeatureContext.Current != null) 
                        && (TechTalk.SpecFlow.FeatureContext.Current.FeatureInfo.Title != "Game")))
            {
                ExamTest.GameFeature.FeatureSetup(null);
            }
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCleanupAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("The game starts and the players take their tiles")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Game")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("mytag")]
        public virtual void TheGameStartsAndThePlayersTakeTheirTiles()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("The game starts and the players take their tiles", new string[] {
                        "mytag"});
#line 4
this.ScenarioSetup(scenarioInfo);
#line 5
 testRunner.Given("the players have an empty hand", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 6
 testRunner.When("the game begins and the players takes 7 tiles", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 7
 testRunner.Then("the two players must have 7 tiles each", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("The game starts and Player2 has to start playing because has Higher Double")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Game")]
        public virtual void TheGameStartsAndPlayer2HasToStartPlayingBecauseHasHigherDouble()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("The game starts and Player2 has to start playing because has Higher Double", ((string[])(null)));
#line 9
this.ScenarioSetup(scenarioInfo);
#line 10
 testRunner.Given("a brand new game is about to start", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "Tile Head",
                        "Tile Tail"});
            table1.AddRow(new string[] {
                        "0",
                        "0"});
            table1.AddRow(new string[] {
                        "0",
                        "3"});
            table1.AddRow(new string[] {
                        "0",
                        "4"});
            table1.AddRow(new string[] {
                        "1",
                        "1"});
            table1.AddRow(new string[] {
                        "1",
                        "4"});
            table1.AddRow(new string[] {
                        "6",
                        "5"});
#line 11
 testRunner.When("the player one has the next set of tiles", ((string)(null)), table1, "When ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "Tile Head",
                        "Tile Tail"});
            table2.AddRow(new string[] {
                        "0",
                        "0"});
            table2.AddRow(new string[] {
                        "0",
                        "3"});
            table2.AddRow(new string[] {
                        "0",
                        "4"});
            table2.AddRow(new string[] {
                        "1",
                        "1"});
            table2.AddRow(new string[] {
                        "1",
                        "4"});
            table2.AddRow(new string[] {
                        "6",
                        "6"});
#line 19
 testRunner.And("the player two has the next set of tiles the highest double", ((string)(null)), table2, "And ");
#line 27
 testRunner.Then("the player \"2\" has to start the game", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("The game starts and Player1 has to start playing because has Higher Double")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Game")]
        public virtual void TheGameStartsAndPlayer1HasToStartPlayingBecauseHasHigherDouble()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("The game starts and Player1 has to start playing because has Higher Double", ((string[])(null)));
#line 29
 this.ScenarioSetup(scenarioInfo);
#line 30
 testRunner.Given("a brand new game is about to start", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "Tile Head",
                        "Tile Tail"});
            table3.AddRow(new string[] {
                        "0",
                        "0"});
            table3.AddRow(new string[] {
                        "0",
                        "3"});
            table3.AddRow(new string[] {
                        "3",
                        "3"});
            table3.AddRow(new string[] {
                        "1",
                        "1"});
            table3.AddRow(new string[] {
                        "1",
                        "4"});
            table3.AddRow(new string[] {
                        "6",
                        "5"});
#line 31
 testRunner.When("the player one has the next set of tiles", ((string)(null)), table3, "When ");
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "Tile Head",
                        "Tile Tail"});
            table4.AddRow(new string[] {
                        "0",
                        "1"});
            table4.AddRow(new string[] {
                        "0",
                        "3"});
            table4.AddRow(new string[] {
                        "0",
                        "4"});
            table4.AddRow(new string[] {
                        "1",
                        "1"});
            table4.AddRow(new string[] {
                        "1",
                        "4"});
            table4.AddRow(new string[] {
                        "6",
                        "5"});
#line 39
 testRunner.And("the player two has the next set of tiles the highest double", ((string)(null)), table4, "And ");
#line 47
 testRunner.Then("the player \"1\" has to start the game", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("The game starts and Player1 has to start playing because he has the most heavy Ti" +
            "le(Non doubleHigher)")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Game")]
        public virtual void TheGameStartsAndPlayer1HasToStartPlayingBecauseHeHasTheMostHeavyTileNonDoubleHigher()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("The game starts and Player1 has to start playing because he has the most heavy Ti" +
                    "le(Non doubleHigher)", ((string[])(null)));
#line 49
this.ScenarioSetup(scenarioInfo);
#line 50
 testRunner.Given("a brand new game is about to start", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                        "Tile Head",
                        "Tile Tail"});
            table5.AddRow(new string[] {
                        "0",
                        "0"});
            table5.AddRow(new string[] {
                        "0",
                        "3"});
            table5.AddRow(new string[] {
                        "3",
                        "2"});
            table5.AddRow(new string[] {
                        "1",
                        "5"});
            table5.AddRow(new string[] {
                        "1",
                        "4"});
            table5.AddRow(new string[] {
                        "6",
                        "5"});
#line 51
 testRunner.When("the player one has the next set of tiles", ((string)(null)), table5, "When ");
#line hidden
            TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                        "Tile Head",
                        "Tile Tail"});
            table6.AddRow(new string[] {
                        "0",
                        "1"});
            table6.AddRow(new string[] {
                        "0",
                        "3"});
            table6.AddRow(new string[] {
                        "0",
                        "4"});
            table6.AddRow(new string[] {
                        "1",
                        "3"});
            table6.AddRow(new string[] {
                        "1",
                        "4"});
            table6.AddRow(new string[] {
                        "1",
                        "5"});
#line 59
 testRunner.And("the player two has the next set of tiles", ((string)(null)), table6, "And ");
#line 67
 testRunner.Then("the player \"1\" has to start the game", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("The game starts and Player2 has to start playing because he has the most heavy Ti" +
            "le(Non doubleHigher)")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Game")]
        public virtual void TheGameStartsAndPlayer2HasToStartPlayingBecauseHeHasTheMostHeavyTileNonDoubleHigher()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("The game starts and Player2 has to start playing because he has the most heavy Ti" +
                    "le(Non doubleHigher)", ((string[])(null)));
#line 69
 this.ScenarioSetup(scenarioInfo);
#line 70
 testRunner.Given("a brand new game is about to start", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table7 = new TechTalk.SpecFlow.Table(new string[] {
                        "Tile Head",
                        "Tile Tail"});
            table7.AddRow(new string[] {
                        "0",
                        "0"});
            table7.AddRow(new string[] {
                        "0",
                        "3"});
            table7.AddRow(new string[] {
                        "3",
                        "2"});
            table7.AddRow(new string[] {
                        "1",
                        "0"});
            table7.AddRow(new string[] {
                        "1",
                        "4"});
            table7.AddRow(new string[] {
                        "3",
                        "1"});
#line 71
 testRunner.When("the player one has the next set of tiles", ((string)(null)), table7, "When ");
#line hidden
            TechTalk.SpecFlow.Table table8 = new TechTalk.SpecFlow.Table(new string[] {
                        "Tile Head",
                        "Tile Tail"});
            table8.AddRow(new string[] {
                        "0",
                        "1"});
            table8.AddRow(new string[] {
                        "0",
                        "3"});
            table8.AddRow(new string[] {
                        "0",
                        "4"});
            table8.AddRow(new string[] {
                        "1",
                        "6"});
            table8.AddRow(new string[] {
                        "1",
                        "4"});
            table8.AddRow(new string[] {
                        "1",
                        "5"});
            table8.AddRow(new string[] {
                        "3",
                        "5"});
#line 79
 testRunner.And("the player two has the next set of tiles", ((string)(null)), table8, "And ");
#line 88
 testRunner.Then("the player \"2\" has to start the game", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("When we put a tile, the tile can swap if needed")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Game")]
        public virtual void WhenWePutATileTheTileCanSwapIfNeeded()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("When we put a tile, the tile can swap if needed", ((string[])(null)));
#line 90
this.ScenarioSetup(scenarioInfo);
#line 91
 testRunner.Given("a tile with 3 in head  and 5 in tail", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 92
 testRunner.When("we call swap", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 93
 testRunner.Then("the tile will have 5 in head and 3 in tail", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
