using Prasanjit.BDD.WebAPIDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Prasanjit.BDD.WebAPIDemo.Controllers
{
    public class ProductsController : ApiController
    {
        //Need to replace with Ninject
        readonly IProductRepository repository = new ProductRepository();

        //Getting error for MVC 5 Ninject extension
        //public ProductsController(IProductRepository rep)
        //{
        //    repository = rep;
        //}

        public HttpResponseMessage GetAllProducts()
        {
            var products = repository.GetAll();
            var productsDto = new ProductsDTO()
            {
                NumberOfProducts = products.Count(),
                Products = products
            };
            return Request.CreateResponse<ProductsDTO>(HttpStatusCode.OK, productsDto);  
        }

        public HttpResponseMessage Get(int id)
        {
            Product item = repository.Get(id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse<Product>(HttpStatusCode.OK, item);           
        }

        public HttpResponseMessage Post(Product item)
        {
            item = repository.Add(item);
            var response = Request.CreateResponse<Product>(HttpStatusCode.Created, item);

            string uri = Url.Link("DefaultApi", new { id = item.Id });
            response.Headers.Location = new Uri(uri);
            return response;
        }

        public HttpResponseMessage Put(int id, Product product)
        {
            product.Id = id;
            if (!repository.Update(product))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            var response = Request.CreateResponse(HttpStatusCode.OK, product);
            string uri = Url.Link("DefaultApi", new { id = id });
            response.Headers.Location = new Uri(uri);
            return response;
        }

        public HttpResponseMessage Delete(int id)
        {
            try
            {
                Product item = repository.Get(id);
                if (item == null)
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }

                repository.Remove(id);
            }
            catch (Exception ex)
            {
                var error = new HttpError("Error deleting product: " + ex.Message) { { "Trace", ex.StackTrace } };
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, error);
            }
            return Request.CreateResponse(HttpStatusCode.NoContent);
            
        }
    }
}
