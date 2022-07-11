using System.Linq;
using Models;

namespace Context
{
    public class EfAuthorRepository : GenericRepository<Author>, IAuthorRepository
    {
        private MsSqlContext _dataBase;
        
        public EfAuthorRepository()
        {
            _dataBase = new MsSqlContext();
        }

        public int GetAuthorIdByName(string name)
        {
            var author = _dataBase.Authors.FirstOrDefault(author => author.Name == name);
            if (author == null)
            {
                return 0;
            }   
            return author.Id;
        }
    }
}