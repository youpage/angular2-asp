using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using angular2_asp.Models;

namespace angular2_asp.Controllers
{
    [Route("api/[controller]")]
    public class OrderDetailController : Controller
    {
        public OrderDetailRepository OrderDetails { get; set; }        
        public OrderDetailController(OrderDetailRepository details){
           OrderDetails = details;
        }
    
        [HttpGet]        
        public IEnumerable<OrderDetail> GetAll()
        {
            return OrderDetails.GetAll();
        }
        
        [HttpGet("{id}", Name = "GetDetail")]
        public IActionResult GetById(string id)
        {
            var item = OrderDetails.FindAll(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        } 
    
    }
}