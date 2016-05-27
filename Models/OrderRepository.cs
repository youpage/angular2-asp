using System.Linq;
using System.Collections.Generic;

namespace angular2_asp.Models
{
    public class OrderRepository : IApiRepository<Order>
    {
        private readonly ApiContext _dbContext; 
        public OrderRepository(ApiContext dbContext){
            _dbContext = dbContext;
        }
        public Order Add(Order item)
        {
            using(_dbContext){
                _dbContext.Orders.Add(item);

                if (_dbContext.SaveChanges() > 0)
                {
                    return item;
                }
                return null;
           }
        }

        public Order Find(string key)
        {
            return _dbContext.Orders.FirstOrDefault(c => c.OrderID.ToString() == key);
        }
        
        public IEnumerable<Order> FindByCustomer(string key)
        {
            return _dbContext.Orders.Where(c => c.CustomerID == key).AsEnumerable();
        }

        public IEnumerable<Order> GetAll()
        {
            return _dbContext.Orders.AsEnumerable();
        }

        public bool Remove(string key)
        {
            using(_dbContext){
                var item = Find(key);            
                if (item != null)
                {
                    _dbContext.Orders.Remove(item);
                    return _dbContext.SaveChanges() > 0;
                }
                return false;
            }
        }

        public void Update(Order item)
        {
            using(_dbContext){
                var _item = Find(item.OrderID.ToString());
                if(_item != null){
                    _item = item;             
                    _dbContext.SaveChanges();
                }
            }
        }
    }
}