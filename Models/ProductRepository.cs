using System.Linq;
using System.Collections.Generic;

namespace angular2_asp.Models
{
    public class ProductRepository : IApiRepository<Product>
    {
        private readonly ApiContext _dbContext;
        public ProductRepository(ApiContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Product Add(Product item)
        {
            using (_dbContext)
            {
                _dbContext.Products.Add(item);

                if (_dbContext.SaveChanges() > 0)
                {
                    return item;
                }
                return null;
            }
        }

        public Product Find(string key)
        {
            return _dbContext.Products.FirstOrDefault(c => c.ProductID.ToString() == key);
        }

        public IEnumerable<Product> GetAll()
        {
            return _dbContext.Products.AsEnumerable();
        }

        public bool Remove(string key)
        {
            using (_dbContext)
            {
                var item = Find(key);
                if (item != null)
                {
                    _dbContext.Products.Remove(item);
                    return _dbContext.SaveChanges() > 0;
                }
                return false;
            }
        }

        public Product Update(Product item)
        {
            using (_dbContext)
            {
                var _item = Find(item.ProductID.ToString());
                if (_item != null)
                {
                    _item = item;
                    if (_dbContext.SaveChanges() > 0)
                    {
                        return item;
                    }
                    return null;
                }
                return null;
            }
        }
    }
}