using Entities.Models;

namespace Repositories.Contracts
{
    public interface IBookRespository :IRepositoryBase<Book>
    {

        IQueryable<Book> GetAllBooks(bool trackChanges);
        Book GetOneBooksById(int id, bool trackChanges);
        void CreateOneBook(Book book);
        void UpdateOneBook(Book book);
        void DeleteOneBook(Book book);

    }
}
