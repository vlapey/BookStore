using System.Linq;
using Models;

namespace Context
{
    public class EfAuthorRepository : GenericRepository<Author>, IAuthorRepository
    {
        public EfAuthorRepository(MsSqlContext context) : base(context) {}
        
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