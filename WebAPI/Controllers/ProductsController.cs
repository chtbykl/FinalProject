using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController] // c#--> ATTRIBUTE, java--> ANNOTATİON
    public class ProductsController : ControllerBase
    {
        //naming convention

        private IProductService _productService;
        //Loosely coupled -- gevşek bağlılık
        //IoC container
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            // dependency chain -- bağımlılık zinciri-- biz product service o da ef productdal'a bağımlı halde şuan, oyüzden bu kodu refactor edicez..
            
            var result = _productService.GetAll();

            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);


        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int id) 
        {
            var result = _productService.GetById(id);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpPost("add")]
        public IActionResult Add(Product product)
        {
            var result = _productService.add(product);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
