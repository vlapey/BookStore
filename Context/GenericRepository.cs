using System.Collections.Generic;
using System.Linq;

namespace Context
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private MsSqlContext _dataBase;

        public GenericRepository()
        {
            _dataBase = new MsSqlContext();
        }
        
        public List<T> GetItems()
        {
            return _dataBase.Set<T>().ToList();
        }

        public T GetItemById(int id)
        {
            return _dataBase.Set<T>().Find(id);
        }
        
        public bool CreateItem(T item)
        {
            var result = _dataBase.Set<T>().Add(item) != null;
            _dataBase.SaveChanges();
            return result;
        }
        
        public bool EditItem(T item)
        {
            var result = _dataBase.Set<T>().Update(item) != null;
            _dataBase.SaveChanges();
            return result;
        }

        public bool DeleteItemById(T item)
        {
            var result = _dataBase.Set<T>().Remove(item) != null;
            _dataBase.SaveChanges();
            return result;
        }
    }
}