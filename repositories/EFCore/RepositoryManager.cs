using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _context;
        private readonly Lazy<IBookRespository> _bookRespository;

        public RepositoryManager(RepositoryContext context)
        {
            _context = context;
            _bookRespository = new Lazy<IBookRespository>(() => new BookRepository(_context));
        }

        public IBookRespository Book =>_bookRespository.Value;

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
