using System.Collections.Generic;

namespace Context
{
    public interface IGenericRepository<T>
    {
        public bool CreateEntity(T entity);
        public List<T> GetEntity();
        public bool DeleteEntityById(uint id);
        public bool EditEntity(T entity);
    }
}