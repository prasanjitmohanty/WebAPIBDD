using NUnit.Framework;
using Prasanjit.BDD.WebAPIDemo.Models;
using Prasanjit.BDD.WebAPIDemo.specs.Helpers;
using Prasanjit.BDD.WebAPIDemo.specs.Models;
using System;
using System.Net.Http;
using TechTalk.SpecFlow;
using Newtonsoft.Json;
using TechTalk.SpecFlow.Assist;
using System.Net;

namespace Prasanjit.BDD.WebAPIDemo.specs
{
    [Binding]
    public class ProductsAPISteps
    {
        private ProductTestModel _productTestModel = new ProductTestModel();
        private HttpResponseMessage _responseContent;
        private Product _productSaved;
        int _existingProductId = 0;
        private ProductsDTO _allProducts = new ProductsDTO();

        [Given(@"the following product inputs")]
        public void GivenTheFollowingProductInputs(Table table)
        {
            // First initialize back in case of resuse in the same run.            
            _productTestModel.Name = "";
            _productTestModel.Category = "";
            _productTestModel.Price = 0;
            table.FillInstance<ProductTestModel>(_productTestModel);
        }

        [When(@"the client posts the inputs to the website")]
        public void WhenTheClientPostsTheInputsToTheWebsite()
        {
            var client = StepHelpers.SetupHttpClient();

            var postData = StepHelpers.SetPostData<ProductTestModel>(_productTestModel);
            HttpContent content = new FormUrlEncodedContent(postData);

            _responseContent = client.PostAsync("http://localhost:52143/api/products", content).Result;
            client.Dispose();
        }

        [When(@"the client gets the product by header location")]
        public void WhenTheClientGetsTheProductByHeaderLocation()
        {
            var client = StepHelpers.SetupHttpClient();
            _responseContent = client.GetAsync(_responseContent.Headers.Location).Result;
            _productSaved = JsonConvert.DeserializeObject<Product>(_responseContent.Content.ReadAsStringAsync().Result);
            client.Dispose();
        }

        [Then(@"a '(.*)' status is returned")]
        public void ThenAStatusIsReturned(string statusCode)
        {
            Assert.AreEqual(statusCode, _responseContent.StatusCode.ToString());
        }

        [Then(@"the saved product matches the inputs")]
        public void ThenTheSavedProductMatchesTheInputs()
        {
            Assert.AreEqual(_productSaved.Name, _productTestModel.Name);
            Assert.AreEqual(_productSaved.Category, _productTestModel.Category);
            Assert.AreEqual(_productSaved.Price, _productTestModel.Price);
        }

       [Given(@"existing products")]
        public void GivenExistingProducts()
        {
            ScenarioContext.Current.Pending();
        }
             
        [When(@"all products are retrieved")]
        public void WhenAllProductsAreRetrieved()
        {
            var client = StepHelpers.SetupHttpClient();            

            _responseContent = client.GetAsync("http://localhost:52143/api/products").Result;
            _allProducts = JsonConvert.DeserializeObject<ProductsDTO>(_responseContent.Content.ReadAsStringAsync().Result);
            client.Dispose();
        }

        [Then(@"a '(.*)' status should be returned")]
        public void ThenAStatusShouldBeReturned(string statusCode)
        {
            Assert.AreEqual(statusCode, _responseContent.StatusCode.ToString());
        }

        [Then(@"all products are returned")]
        public void ThenAllProductsAreReturned()
        {
            Assert.Greater(0, _allProducts.NumberOfProducts);
        }

        [Given(@"an existing product id '(.*)'")]
        public void GivenAnExistingProductId(int id)
        {
            _existingProductId = id;
        }  

        [When(@"it is retrieved")]
        public void WhenItIsRetrieved()
        {
            var client = StepHelpers.SetupHttpClient();

            _responseContent = client.GetAsync("http://localhost:52143/api/products/"+_existingProductId).Result;
            client.Dispose();
        }

        [Then(@"a '(.*)' is returned")]
        public void ThenAIsReturned(string statusCode)
        {
            Assert.AreEqual(statusCode, _responseContent.StatusCode.ToString());
        }

        [Then(@"it is returned")]
        public void ThenItIsReturned()
        {
            var client = StepHelpers.SetupHttpClient();
            _responseContent = client.GetAsync("http://localhost:52143/api/products/" + _existingProductId).Result;
            _productSaved = JsonConvert.DeserializeObject<Product>(_responseContent.Content.ReadAsStringAsync().Result);
            client.Dispose();
        }

        [Then(@"it should have an id")]
        public void ThenItShouldHaveAnId()
        {
            Assert.GreaterOrEqual(_productSaved.Id, 1);
        }

        [Then(@"it should have a title")]
        public void ThenItShouldHaveATitle()
        {
            Assert.IsNotNull(_productSaved.Name);
        }

        [Then(@"it should have a catagory")]
        public void ThenItShouldHaveACatagory()
        {
            Assert.IsNotNull(_productSaved.Category);
        }

        [Then(@"it should have a price")]
        public void ThenItShouldHaveAPrice()
        {
            Assert.GreaterOrEqual(_productSaved.Price,0);
        }                

        [When(@"a PUT request is made")]
        public void WhenAPUTRequestIsMade()
        {
            var client = StepHelpers.SetupHttpClient();

            var postData = StepHelpers.SetPostData<ProductTestModel>(_productTestModel);
            HttpContent content = new FormUrlEncodedContent(postData);

            _responseContent = client.PutAsync("http://localhost:52143/api/products", content).Result;
            client.Dispose();
        }

        [Then(@"the product should be updated")]
        public void ThenTheProductShouldBeUpdated()
        {
            var client = StepHelpers.SetupHttpClient();
            _responseContent = client.GetAsync("http://localhost:52143/api/products/" + _existingProductId).Result;
            _productSaved = JsonConvert.DeserializeObject<Product>(_responseContent.Content.ReadAsStringAsync().Result);
            client.Dispose();
            Assert.AreEqual(_productSaved.Price, 3.75);
        }

        [When(@"a DELETE request is made")]
        public void WhenADELETERequestIsMade()
        {
            var client = StepHelpers.SetupHttpClient();
           
            _responseContent = client.DeleteAsync("http://localhost:52143/api/products/"+ _existingProductId).Result;
            client.Dispose();
        }                      
        
        

        [Then(@"the product should be removed")]
        public void ThenTheProductShouldBeRemoved()
        {
            Assert.AreEqual(HttpStatusCode.NoContent.ToString(), _responseContent.StatusCode.ToString());
        }
    }
}
