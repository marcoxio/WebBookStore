using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebBookStore.Models;
using WebBookStore.Repository;

namespace WebBookStore.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepository _bookRepository = null;

        public BookController(BookRepository bookRepository)
        {
            _bookRepository= bookRepository;
        }

        public IActionResult GetAllBooks()
        {
            var data = _bookRepository.GetAllBooks();
            return View(data);
        }
        
        [HttpGet("{id}")]
        [Route("book-details/{id}", Name ="bookDetailsRoute")]
        public IActionResult GetBook(int id)
        {
            var data = _bookRepository.GetBookById(id);
            return View(data);
        }

        [HttpGet]
        public List<BookModel> SearchBooks(string bookName,string authorName)
        {
            // return $"Boom with name = {bookName} & Author = {authorName}";
            return _bookRepository.SearchBook(bookName, authorName);
        }

        [HttpGet]
         public IActionResult AddNewBook(bool isSuccess = false, int bookId = 0)
        {
            ViewBag.IsSuccess = isSuccess;
            ViewBag.BookId = bookId;
            return View();
        }


        [HttpPost]
        public IActionResult AddNewBook(BookModel bookModel)
        {
            int id =_bookRepository.AddNewBook(bookModel);
            if (id > 0)
            {
                return RedirectToAction(nameof(AddNewBook), new { isSuccess = true, bookId = id });
            }
            return View();
        }
    }
}