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
using System.Configuration;
using System.Net.Http.Headers;

namespace Prasanjit.BDD.WebAPIDemo.specs
{
    [Binding]
    public class ProductsAPISteps
    {
        private const string Url = "http://localhost:12345/api/products/";
        private string _format = "application/json";
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
            var request = new HttpRequestMessage(HttpMethod.Post, Url);
            var server = new VirtualServer(WebApiConfig.Register,
                Convert.ToBoolean(ConfigurationManager.AppSettings["UseSelfHosting"]));
            var postData = StepHelpers.SetPostData<ProductTestModel>(_productTestModel);
            HttpContent content = new FormUrlEncodedContent(postData);
            request.Content = content;
            _responseContent = server.Send(request);            
        }

        [When(@"the client gets the product by header location")]
        public void WhenTheClientGetsTheProductByHeaderLocation()
        {
            var request = new HttpRequestMessage(HttpMethod.Post, Url);
            var server = new VirtualServer(WebApiConfig.Register,
                Convert.ToBoolean(ConfigurationManager.AppSettings["UseSelfHosting"]));

            _responseContent = server.Send(request);
            _productSaved = JsonConvert.DeserializeObject<Product>(_responseContent.Content.ReadAsStringAsync().Result);           
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
            
        }
             
        [When(@"all products are retrieved")]
        public void WhenAllProductsAreRetrieved()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, Url);
            var server = new VirtualServer(WebApiConfig.Register,
                Convert.ToBoolean(ConfigurationManager.AppSettings["UseSelfHosting"]));
            request.Headers.Accept.Clear();
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(
                _format));
            _responseContent = server.Send(request);
        }

        [Then(@"a '(.*)' status should be returned")]
        public void ThenAStatusShouldBeReturned(string statusCode)
        {
            Assert.AreEqual(statusCode, _responseContent.StatusCode.ToString());
        }

        [Then(@"all products are returned")]
        public void ThenAllProductsAreReturned()
        {
            _allProducts = JsonConvert.DeserializeObject<ProductsDTO>(_responseContent.Content.ReadAsStringAsync().Result);
            Assert.Greater(_allProducts.NumberOfProducts,0);
        }

        [Given(@"an existing product id '(.*)'")]
        public void GivenAnExistingProductId(int id)
        {
            _existingProductId = id;
        }  

        [When(@"it is retrieved")]
        public void WhenItIsRetrieved()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, Url + _existingProductId);
            var server = new VirtualServer(WebApiConfig.Register,
                Convert.ToBoolean(ConfigurationManager.AppSettings["UseSelfHosting"]));
            request.Headers.Accept.Clear();
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(
                _format));
            _responseContent = server.Send(request);
        }

        [Then(@"a '(.*)' is returned")]
        public void ThenAIsReturned(string statusCode)
        {
            Assert.AreEqual(statusCode, _responseContent.StatusCode.ToString());
        }

        [Then(@"it is returned")]
        public void ThenItIsReturned()
        {
            var _product = JsonConvert.DeserializeObject<Product>(_responseContent.Content.ReadAsStringAsync().Result);
            Assert.AreEqual(_product.Id, _existingProductId);
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
            var request = new HttpRequestMessage(HttpMethod.Put, Url);
            var server = new VirtualServer(WebApiConfig.Register,
                Convert.ToBoolean(ConfigurationManager.AppSettings["UseSelfHosting"]));

            var postData = StepHelpers.SetPostData<ProductTestModel>(_productTestModel);
            HttpContent content = new FormUrlEncodedContent(postData);
            request.Content = content;
            _responseContent = server.Send(request);           
        }

        [Then(@"the product should be updated")]
        public void ThenTheProductShouldBeUpdated()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, Url + _existingProductId);
            var server = new VirtualServer(WebApiConfig.Register,
                Convert.ToBoolean(ConfigurationManager.AppSettings["UseSelfHosting"]));            
            _productSaved = JsonConvert.DeserializeObject<Product>(_responseContent.Content.ReadAsStringAsync().Result);           
            Assert.AreEqual(_productSaved.Price, 3.75);
        }

        [When(@"a DELETE request is made")]
        public void WhenADELETERequestIsMade()
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, Url + _existingProductId);
            var server = new VirtualServer(WebApiConfig.Register,
                Convert.ToBoolean(ConfigurationManager.AppSettings["UseSelfHosting"]));

            var postData = StepHelpers.SetPostData<ProductTestModel>(_productTestModel);
            HttpContent content = new FormUrlEncodedContent(postData);
            request.Content = content;
            _responseContent = server.Send(request);                      
        }                      
        
        

        [Then(@"the product should be removed")]
        public void ThenTheProductShouldBeRemoved()
        {
            Assert.AreEqual(HttpStatusCode.NoContent.ToString(), _responseContent.StatusCode.ToString());
        }
    }
}
