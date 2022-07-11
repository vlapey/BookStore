using Models;

namespace Context
{
    public interface IAuthorRepository : IGenericRepository<Author>
    {
        public int GetAuthorIdByName(string name);
    }
}