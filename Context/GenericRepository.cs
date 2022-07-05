using System.Collections.Generic;

namespace Context
{
    public class GenericRepository<T> : IGenericRepository<T>
    {
        public bool CreateEntity(T entity)
        {
            throw new System.NotImplementedException();
        }

        public List<T> GetEntity()
        {
            throw new System.NotImplementedException();
        }

        public bool DeleteEntityById(uint id)
        {
            throw new System.NotImplementedException();
        }

        public bool EditEntity(T entity)
        {
            throw new System.NotImplementedException();
        }
    }
}