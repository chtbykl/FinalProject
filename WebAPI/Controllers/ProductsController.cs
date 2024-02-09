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
        [HttpGet]
        public IActionResult Get()
        {
            // dependency chain -- bağımlılık zinciri-- biz product service o da ef productdal'a bağımlı halde şuan, oyüzden bu kodu refactor edicez..
            
            var result = _productService.GetAll();

            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);


        }
    }
}
