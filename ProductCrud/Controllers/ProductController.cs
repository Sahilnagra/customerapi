using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProductCrud.Models;
using ProductCrud.ProductData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductCrud.Controllers
{
    [ApiController]
    
    public class ProductController : ControllerBase
    {
        private IProductData _productData;
      public ProductController(IProductData productData)
        {
            _productData = productData;
        }
        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetProduct()
        {
            return Ok(_productData.GetProduct());
        }
        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult GetProduct(Guid id)
        {
            var product = _productData.GetProduct(id);
            if (product != null)
            {
                return Ok(_productData.GetProduct(id));
            }
            return NotFound($"Product with Id: {id} was not found");

        }
        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult GetProduct(Product product)
        {
             _productData.AddProduct(product);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path +
                "/" + product.Id, product);

        }


        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public IActionResult DeleteProduct(Guid id)
        {
            var product = _productData.GetProduct(id);
            if(product != null)
            {
                _productData.DeleteProduct(product);
                return Ok();
            }
            return NotFound($"Product with Id: {id} was not found");

        }
        [HttpPatch]
        [Route("api/[controller]/{id}")]
        public IActionResult EditProduct(Guid id, Product product)
        {

            var existingproduct = _productData.GetProduct(id);
            if (existingproduct != null)
            {
                product.Id = existingproduct.Id;
                _productData.EditProduct(product);
                
            }
            return Ok(product);
        }




    }
    }

