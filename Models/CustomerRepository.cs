using System.Linq;
using System.Collections.Generic;
using System.Collections.Concurrent;
using Microsoft.Extensions.Logging;

namespace angular2_asp.Models
{
    public class CustomerRepository : IApiRepository<Customer>
    {
        static ConcurrentDictionary<string, Customer> _customer =
              new ConcurrentDictionary<string, Customer>();

        private readonly ApiContext _dbContext;
        private readonly ILogger logger;
        public CustomerRepository(ApiContext dbContext, ILogger<CustomerRepository> logger)
        {
            _dbContext = dbContext;
            this.logger = logger;
        }
            
        public Customer Add(Customer item)
        {
            using (_dbContext)
            {
                _dbContext.Customers.Add(item);

                if (_dbContext.SaveChanges() > 0)
                {
                    return item;
                }
                return null;
            }
        }

        public Customer Find(string key)
        {
            return _dbContext.Customers.FirstOrDefault(c => c.CustomerID == key);
        }

        public IEnumerable<Customer> GetAll()
        {
            return _dbContext.Customers.AsEnumerable();
        }

        public bool Remove(string key)
        {
            using (_dbContext)
            {
                var item = Find(key);
                if (item != null)
                {
                    _dbContext.Customers.Remove(item);
                    return _dbContext.SaveChanges() > 0;
                }
                return false;
            }
        }

        public Customer Update(Customer item)
        {
            using (_dbContext)
            {
                var _item = Find(item.CustomerID);
                if (_item != null)
                {   
                    _item.DeepCopy(item);
                    _dbContext.Customers.Update(_item);                    
                    //overhead to see how the custom logger works :P
                    var x = _dbContext.SaveChanges();
                    this.logger.LogInformation("context = " + x.ToString());
                    //if (_dbContext.SaveChanges() > 0) //simple version     
                    if (x > 0)
                    {
                        return _item;
                    }
                    return null;
                }
                return null;
            }
        }
    }
}