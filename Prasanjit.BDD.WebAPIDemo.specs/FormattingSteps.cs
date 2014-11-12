using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.WebHost;
using Prasanjit.BDD.WebAPIDemo.App_Start;
using Prasanjit.BDD.WebAPIDemo.Models;
using TechTalk.SpecFlow;
using NUnit.Framework;
using Newtonsoft.Json;
using System.Xml.Serialization;
using System.IO;

namespace Prasanjit.BDD.WebAPIDemo.specs
{   
    [Binding]
    public class FormattingSteps
    {
        private const string Url = "http://localhost:12345/api/products/";
        private string _format = null;
        private HttpResponseMessage _response;

        [Given(@"I provide format (.*)")]
        public void GivenIProvideFormat(string format)
        {
            _format = format;
        }

        [When(@"When I request for all products")]
        public void WhenIRequestproductsData()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, Url);
            var server = new VirtualServer(WebApiConfig.Register,
                Convert.ToBoolean(ConfigurationManager.AppSettings["UseSelfHosting"]));
            request.Headers.Accept.Clear();
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(
                _format == "JSON" ? "application/json" : "application/xml"));
            _response = server.Send(request);
        }

        [Then(@"I get back (.+) content type")]
        public void ThenIGetBackContentType(string contentType)
        {
            Assert.AreEqual(contentType, _response.Content.Headers.ContentType.MediaType);
        }

        [Then(@"content is a set of products")]
        public void ThenContentIsASetOfProducts()
        {
            var content = _response.Content.ReadAsStringAsync().Result;
            if (_response.Content.Headers.ContentType.MediaType == "application/json")
            {
                var products = JsonConvert.DeserializeObject<ProductsDTO>(content);
            }
            else if (_response.Content.Headers.ContentType.MediaType == "application/xml")
            {
                var products = _response.Content.ReadAsAsync<ProductsDTO>();                           
            }

        }

        [When(@"When an error is returned")]
        public void WhenWhenAnErrorIsReturned()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, Url + "NonExist");
            var server = new VirtualServer(WebApiConfig.Register,
                Convert.ToBoolean(ConfigurationManager.AppSettings["UseSelfHosting"]));
            request.Headers.Accept.Clear();
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(
                _format == "JSON" ? "application/json" : "application/xml"));
            _response = server.Send(request);
        }

        [Then(@"message content contains error information")]
        public void ThenMessageContentContainsErrorInformation()
        {
            var error = _response.Content.ReadAsStringAsync().Result;
            //Assert.AreEqual("No Http resource", error);            
        }
    }
}
