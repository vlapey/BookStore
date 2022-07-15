using System.Collections.Generic;
using Models;

namespace Context
{
    public interface IGenericRepository<T> where T : class, IEntity
    {
        public List<T> GetItems();
        public T GetItemById(int id);
        public bool CreateItem(T item);
        public bool EditItem(T item);
        public bool DeleteItem(int id);
    }
}