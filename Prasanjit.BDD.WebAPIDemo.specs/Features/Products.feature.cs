﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.9.0.77
//      SpecFlow Generator Version:1.9.0.0
//      Runtime Version:4.0.30319.18444
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Prasanjit.BDD.WebAPIDemo.specs.Features
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Products API")]
    public partial class ProductsAPIFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "Products.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Products API", "    In order to perform CRUD operations on the products\r\n    As a client of the W" +
                    "eb Api\r\n    I want to be able to Create, Update, Delete, and List products", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.TestFixtureTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
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
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Retrieving all Products")]
        [NUnit.Framework.CategoryAttribute("ProductCrud")]
        public virtual void RetrievingAllProducts()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Retrieving all Products", new string[] {
                        "ProductCrud"});
#line 8
 this.ScenarioSetup(scenarioInfo);
#line 9
    testRunner.Given("existing products", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 10
    testRunner.When("all products are retrieved", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 11
    testRunner.Then("a \'200 OK\' status is returned", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 12
    testRunner.Then("all products are returned", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Retrieving a product by id")]
        public virtual void RetrievingAProductById()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Retrieving a product by id", ((string[])(null)));
#line 14
  this.ScenarioSetup(scenarioInfo);
#line 15
    testRunner.Given("an existing product id \'1\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 16
    testRunner.When("it is retrieved", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 17
    testRunner.Then("a \'200 OK\' status is returned", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 18
    testRunner.Then("it is returned", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 19
    testRunner.Then("it should have an id", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 20
    testRunner.Then("it should have a title", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 21
    testRunner.Then("it should have a catagory", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 22
    testRunner.Then("it should have a price", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Create a new product saves posted values.")]
        public virtual void CreateANewProductSavesPostedValues_()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Create a new product saves posted values.", ((string[])(null)));
#line 24
  this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "Field",
                        "Value"});
            table1.AddRow(new string[] {
                        "Name",
                        "Tomato Soup"});
            table1.AddRow(new string[] {
                        "Category",
                        "Groceries"});
            table1.AddRow(new string[] {
                        "Price",
                        "2.75"});
#line 25
      testRunner.Given("the following product inputs", ((string)(null)), table1, "Given ");
#line 31
      testRunner.When("the client posts the inputs to the website", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 32
      testRunner.Then("a \'201 Created\' status should be returned", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 33
      testRunner.When("the client gets the product by header location", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 34
      testRunner.Then("the saved product matches the inputs", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Updating an product")]
        public virtual void UpdatingAnProduct()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Updating an product", ((string[])(null)));
#line 36
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "Field",
                        "Value"});
            table2.AddRow(new string[] {
                        "Name",
                        "Tomato Soup"});
            table2.AddRow(new string[] {
                        "Category",
                        "Groceries"});
            table2.AddRow(new string[] {
                        "Price",
                        "3.75"});
#line 37
    testRunner.Given("the following product inputs", ((string)(null)), table2, "Given ");
#line 42
    testRunner.When("a PUT request is made", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 43
    testRunner.Then("a \'200 OK\' is returned", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 44
    testRunner.Then("the product should be updated", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Deleting an product")]
        public virtual void DeletingAnProduct()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Deleting an product", ((string[])(null)));
#line 46
 this.ScenarioSetup(scenarioInfo);
#line 47
    testRunner.Given("an existing product id \'1\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 48
    testRunner.When("a DELETE request is made", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 49
    testRunner.Then("a \'200 OK\' status is returned", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 50
    testRunner.Then("the product should be removed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
