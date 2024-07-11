using BooksApplication.Services;
using BooksApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace BooksApplication.Controllers
{
    public class BooksController : Controller
    {
        private IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetAllBooks()
        {
            var books = _bookService.GetAllBooks();
            return View(books);
        }
        public IActionResult AddBook(Book book)
        {

            if (ModelState.IsValid)
            {
                _bookService.AddBook(book);
                return RedirectToAction("GetAllBooks");
            }
            return View(book);
        }
        public IActionResult DeleteBook(int id)
        {
            var prod = _bookService.GetBookById(id);
            if (prod == null)
            {
                return NotFound();
            }
            return View(prod);
        }
        [HttpPost, ActionName("DeleteBook")]
        public IActionResult DeleteConfirm(int id)
        {
            _bookService.DeleteBook(id);
            return RedirectToAction("GetAllBooks");
        }

        public IActionResult GetBookById(int id)
        {
            var prod = _bookService.GetBookById(id);
            if (prod == null)
            {
                return NotFound();
            }
            return View(prod);
        }
        public IActionResult SortBooks()
        {
            return View(_bookService.SortBooks());
        }
        public IActionResult Login()
        { 
            return View();
        }
        [HttpPost]
        public IActionResult Login(string username, int password)
        {
            if (_bookService.Login(username, password)==true)
            {
                return RedirectToAction("GetAllBooks");
            }
            return View();
        }
       

        public IActionResult Edit(int id)
        {
            var prod = _bookService.GetBookById(id);
            
            return View(prod);
        }

        [HttpPost]
        public IActionResult Edit(Book book)
        {
            
            _bookService.UpdateBook(book);
                return RedirectToAction("GetAllBooks");
            
        }

    }
}
