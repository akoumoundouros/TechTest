using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TechTest.Components.Auth;
using TechTest.Data;
using TechTest.Repositories;

namespace TechTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private IProductRepository _productRepo;

        public ProductController(IProductRepository productRepo)
        {
            _productRepo = productRepo;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var products = _productRepo.GetAll();
            return Ok(products);
        }

        [Route("{id}")]
        [HttpGet]
        public IActionResult Get(int id)
        {
            var product = _productRepo.GetById(id);
            return Ok(product);
        }

        [HttpPost]
        public IActionResult Create(int id, string name, string desc, decimal price)
        {
            _productRepo.Create(id, name, desc, price);
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _productRepo.Delete(id);
            return Ok();
        }
    }
}
