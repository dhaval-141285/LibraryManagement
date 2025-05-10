using LibraryManager.Core.Entities;

namespace LibraryManager.Application.Services.Interfaces
{
    public interface IBookService
    {
        //int Create(CreateBookViewModel book);
        //GetBookViewModel GetById(int id);
        //IEnumerable<GetBookViewModel> GetAll(string query);
        //int Delete(int id);

        void AddBook(Book book);
        void RemoveBook(Guid id);
        IEnumerable<Book> Search(string query);
        void BorrowBook(Guid id, string username);
        void ReturnBook(Guid id);
        IEnumerable<Book> GetBorrowedBooks(string userId);

    }
}