using Microsoft.AspNetCore.Mvc;
using angular2_asp.Models;

namespace angular2_asp.Controllers
{
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        public CustomerRepository Customers { get; set; }
        public CustomerController(CustomerRepository customers){
           Customers = customers;
        }
    
        [HttpGet]        
        public IActionResult GetAll()
        {            
            return new ObjectResult(Customers.GetAll());
        }
        
        [HttpGet("{id}", Name = "GetCustomer")]
        public IActionResult GetById(string id)
        {
            var item = Customers.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }
        
        // PUT api/customer
        [HttpPut]
        public IActionResult Update([FromBody]Customer customer)
        {
            var item = Customers.Update(customer); 
            return new ObjectResult(item);            
        }
    
    }
}