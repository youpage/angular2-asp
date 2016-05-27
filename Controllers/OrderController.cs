using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using angular2_asp.Models;

namespace angular2_asp.Controllers
{
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        public OrderRepository Orders { get; set; }
        public OrderController(OrderRepository orders){
           Orders = orders;
        }    
        [HttpGet]        
        public IEnumerable<Order> GetAll()
        {
            return Orders.GetAll();
        }        
        [HttpGet("{id}", Name = "GetOrder")]
        public IActionResult GetById(string id)
        {
            var item = Orders.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        } 
        [HttpGet("GetByCustomer/{id}")]
        public IActionResult GetByCustomer(string id)
        {
            var item = Orders.FindByCustomer(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        } 
    
    }
}