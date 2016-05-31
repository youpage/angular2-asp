using System.Collections.Generic;

namespace angular2_asp.Models
{
    public interface IApiRepository <T>
    {
        T Add( T item);
        IEnumerable<T> GetAll();
        T Find(string key);
        bool Remove(string key);
        T Update(T item);
    }
}