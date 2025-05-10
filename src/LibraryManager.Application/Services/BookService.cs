using LibraryManager.Application.Services.Interfaces;
using LibraryManager.Core.Entities;
using LibraryManager.Infrastructure.Repositories.Interfaces;

namespace LibraryManager.Application.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _repository;
        public BookService(IBookRepository repository)
        {
            _repository = repository;
        }

        public void AddBook(Book book) => _repository.AddBook(book);

        public void RemoveBook(Guid id) => _repository.RemoveBook(id);

        public IEnumerable<Book> Search(string query) => _repository.Search(query);

        public void BorrowBook(Guid id, string username)
        {
            var book = _repository.GetById(id);
            if (book == null || !book.IsAvailable)
                throw new InvalidOperationException("Book not available");

            book.IsAvailable = false;
            book.BorrowedBy = username;
            _repository.UpdateBook(book);
        }

        public void ReturnBook(Guid id)
        {
            var book = _repository.GetById(id);
            if (book == null || book.IsAvailable)
                throw new InvalidOperationException("Book is not borrowed");

            book.IsAvailable = true;
            book.BorrowedBy = null;
            _repository.UpdateBook(book);
        }

        public IEnumerable<Book> GetBorrowedBooks(string username) => _repository.GetBorrowedBooksByUser(username);
    }
}