using BooksApplication.Models;
namespace BooksApplication.Services
{
    public interface IBookService
    {
        List<Book> GetAllBooks();
        void AddBook(Book book);
        void DeleteBook(int id);
        void UpdateBook(Book book);
        Book GetBookById(int id);

        List<Book> SortBooks();

        bool Login(string username, int password);
    }
}
