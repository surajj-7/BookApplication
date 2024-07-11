using BooksApplication.Models;
using BooksApplication.Repositories;

namespace BooksApplication.Services
{
    public class BookService:IBookService
    {
        public IBooksRepoManager _books;

        public BookService(IBooksRepoManager books)
        {
            _books = books;
        }
        
        public void AddBook(Book book)=>_books.AddBook(book);

        public void DeleteBook(int id) => _books.DeleteBook(id);
        

        public List<Book> GetAllBooks()=>_books.GetAllBooks();
        
        public Book GetBookById(int id)=>_books.GetBookById(id);

        public void UpdateBook(Book book)=>_books.UpdateBook(book);

        public List<Book>SortBooks() => _books.SortBooks();

        public bool Login(string username, int password)=>_books.Login(username, password);
        
    }
}
