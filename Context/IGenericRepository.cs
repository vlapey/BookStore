using System.Collections.Generic;
using Models;

namespace Context
{
    public interface IGenericRepository<T> where T : class, IEntity
    {
    public bool CreateItem(T item);
    public List<T> GetItems();
    public bool DeleteItemById(int id);
    public bool EditItem(T item);
    public T GetItemById(int id);
    }
}