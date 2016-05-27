using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using angular2_asp.Models;

namespace angular2_asp.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        public ProductRepository Products { get; set; }
        public ProductController(ProductRepository prods){
           Products = prods;
        }
    
        [HttpGet]        
        public IEnumerable<Product> GetAll()
        {
            return Products.GetAll();
        }
        
        [HttpGet("{id}", Name = "GetProduct")]
        public IActionResult GetById(string id)
        {
            var item = Products.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        } 
    
    }
}