using System.Linq;
using System.Collections.Generic;
using System.Collections.Concurrent;

namespace angular2_asp.Models
{
    public class CustomerRepository : IApiRepository<Customer>
    {
        static ConcurrentDictionary<string, Customer> _customer =
			  new ConcurrentDictionary<string, Customer>();
              
        private readonly ApiContext _dbContext;      
        public CustomerRepository(ApiContext dbContext){
            _dbContext = dbContext;
        }
        public Customer Add(Customer item)
        {
           using(_dbContext){
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
            using(_dbContext){
                var item = Find(key);            
                if (item != null)
                {
                    _dbContext.Customers.Remove(item);
                    return _dbContext.SaveChanges() > 0;
                }
                return false;
            }
        }

        public void Update(Customer item)
        {   
            using(_dbContext){
                var _item = Find(item.CustomerID);
                if(_item != null){
                    _item = item;             
                    _dbContext.SaveChanges();
                }
            }
        }
    }
}