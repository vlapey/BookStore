using System.Collections.Generic;
using System.Linq;
using Models;

namespace Context
{
    public class GenericRepository<T> : IGenericRepository<T>
    {
        private MsSqlContext _dataBase;

        public GenericRepository()
        {
            _dataBase = new MsSqlContext();
        }

        public List<T> GetEntity()
        {
            throw new System.NotImplementedException();
        }

        public bool CreateEntity(T entity)
        {
            throw new System.NotImplementedException();
        }

        public bool EditEntity(T entity)
        {
            throw new System.NotImplementedException();
        }

        public bool DeleteEntityById(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}