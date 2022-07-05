using System.Collections.Generic;

namespace Context
{
    public interface IGenericRepository<T>
    {
        public List<T> GetEntity();
        public bool CreateEntity(T entity);
        public bool EditEntity(T entity);
        public bool DeleteEntityById(int id);
    }
}