using System.Linq;
using System.Collections.Generic;

namespace angular2_asp.Models
{
    public class OrderDetailRepository : IApiRepository<OrderDetail>
    {
        private readonly ApiContext _dbContext; 
        public OrderDetailRepository(ApiContext dbContext){
            _dbContext = dbContext;
        }
        public OrderDetail Add(OrderDetail item)
        {
            using(_dbContext){
                _dbContext.OrderDetails.Add(item);

                if (_dbContext.SaveChanges() > 0)
                {
                    return item;
                }
                return null;
           }
        }

        public OrderDetail Find(string key)
        {
            var item = _dbContext.OrderDetails.FirstOrDefault(c => c.OrderID.ToString() == key);            
            return item;
        }
        public IEnumerable<OrderDetail> FindAll(string key)
        {            
            IEnumerable<OrderDetail> items = _dbContext.OrderDetails
                        .Where(o => o.OrderID.ToString() == key)
                        .Select((o) => new {o, o.Product}).AsEnumerable()
                        .Select(o => new OrderDetail{
                                OrderID = o.o.OrderID,
                                ProductID = o.o.ProductID,
                                Quantity = o.o.Quantity,
                                Discount = o.o.Discount,
                                Product = o.Product });
                 
            return items;
        }

        public IEnumerable<OrderDetail> GetAll()
        {
            return _dbContext.OrderDetails.AsEnumerable();
        }

        public bool Remove(string key)
        {
            using(_dbContext){
                var item = Find(key);            
                if (item != null)
                {
                    _dbContext.OrderDetails.Remove(item);
                    return _dbContext.SaveChanges() > 0;
                }
                return false;
            }
        }

        public void Update(OrderDetail item)
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