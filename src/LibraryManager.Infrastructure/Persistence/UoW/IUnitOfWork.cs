using LibraryManager.Infrastructure.Repositories.Interfaces;

namespace LibraryManager.Infrastructure.Persistence.UoW
{
    public interface IUnitOfWork
    {
        public IBookRepository Books { get; }
        int Complete();
    }
}