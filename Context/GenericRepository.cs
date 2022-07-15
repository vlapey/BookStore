using System.Collections.Generic;
using System.Linq;
using Models;

namespace Context
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class, IEntity
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
            var updatingEntity = _dataBase.Set<T>().FirstOrDefault(t => t.Id == item.Id);

            if (updatingEntity is null)
            {
                return false;
            }
            
            var result = _dataBase.Set<T>().Update(item) != null;
            _dataBase.SaveChanges();
            return result;
        }

        public bool DeleteItemById(int id)
        {
            var deletingEntity = _dataBase.Set<T>().FirstOrDefault(t => t.Id == id);

            if (deletingEntity is null)
            {
                return false;
            }
            
            _dataBase.Set<T>().Remove(deletingEntity);
            var savedAmount = _dataBase.SaveChanges();

            return savedAmount > 0;
        }
    }
}