using LibraryManager.Core.Entities;
using LibraryManager.Infrastructure.Context;
using LibraryManager.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibraryManager.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryContext _context;

        public BookRepository(LibraryContext context)
        {
            _context = context;           
        }
        
        public Guid AddBook(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();

            return book.Id;
        }

        public void RemoveBook(Guid id)
        {
            _context.Books
                .Where(b => b.Id == id)
                .ExecuteDelete();
        }

        public Book? GetById(Guid id)
        {
            return _context.Books.SingleOrDefault(b => b.Id == id);
        }
        public IEnumerable<Book> Search(string query)
        {
            IQueryable<Book> books = _context.Books;

            if(!string.IsNullOrWhiteSpace(query)){
                books = books.Where(b => b.Title.Contains(query) || b.Author.Contains(query));
            }

            return books;
        }

        public IEnumerable<Book> GetBorrowedBooksByUser(string userId)
        {
            var userLoans = _context.Books.Where(l => l.BorrowedBy == userId);
            return userLoans;
        }

        public void UpdateBook(Book book)
        {
            List<Book> _books = new();
            var index = _books.FindIndex(b => b.Id == book.Id);
            if (index != -1) _books[index] = book;
        }
    }
}