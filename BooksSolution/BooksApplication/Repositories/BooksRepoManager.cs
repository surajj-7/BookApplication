using BooksApplication.Models;
using System.Linq;
namespace BooksApplication.Repositories
{
    public class BooksRepoManager : IBooksRepoManager
    {
        CollectionContext _context = new CollectionContext();

        public List<Book> GetAllBooks()
        {
            return _context.books.ToList();
        }

        public Book GetBookById(int id)
        {
            return _context.books.Find(id);
        }


        public void AddBook(Book book)
        {

            _context.books.Add(book);
            _context.SaveChanges();
        }

        public void DeleteBook(int id)
        {
            Book b = _context.books.Find(id);
            if (b != null)
            {
                _context.books.Remove(b);
                _context.SaveChanges();
            }
        }

        public void UpdateBook(Book book)
        {

            _context.Update(book);
            _context.SaveChanges();
        }

        public List<Book> SortBooks()
        { 
            return _context.books.OrderBy(x => x.Title).ToList();
        }

        public bool Login(string username, int password)
        {
            var book= _context.books.FirstOrDefault(s=>username == "Admin" && password == 1234);
            if (book != null)
            {
                return true;
            }
            return false;
        }
    }
}
