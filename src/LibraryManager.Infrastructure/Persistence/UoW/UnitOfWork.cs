using LibraryManager.Infrastructure.Context;
using LibraryManager.Infrastructure.Repositories.Interfaces;

namespace LibraryManager.Infrastructure.Persistence.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LibraryContext _context;
        public IBookRepository Books { get; }

        public UnitOfWork(
            LibraryContext context,
            IBookRepository books)
        {
            _context = context;
            Books = books;
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }
    }
}