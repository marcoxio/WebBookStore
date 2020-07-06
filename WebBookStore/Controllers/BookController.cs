using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebBookStore.Models;
using WebBookStore.Repository;

namespace WebBookStore.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepository _bookRepository = null;
        private readonly LanguageRepository _languageRepository = null;

        public BookController(BookRepository bookRepository,LanguageRepository languageRepository)
        {
            _bookRepository = bookRepository;
            _languageRepository=languageRepository;
        }

        public async Task<IActionResult> GetAllBooks()
        {
            var data = await _bookRepository.GetAllBooks();
            return View(data);
        }

        [HttpGet("{id}")]
        [Route("book-details/{id}", Name = "bookDetailsRoute")]
        public async Task<IActionResult> GetBook(int id)
        {
            var data = await _bookRepository.GetBookById(id);
            return View(data);
        }

        [HttpGet]
        public List<BookModel> SearchBooks(string bookName, string authorName)
        {
            // return $"Boom with name = {bookName} & Author = {authorName}";
            return _bookRepository.SearchBook(bookName, authorName);
        }

        [HttpGet]
        public async Task<IActionResult> AddNewBook(bool isSuccess = false, int bookId = 0)
        {
              var model = new BookModel();

             ViewBag.Language = new SelectList(await _languageRepository.GetLanguages(),"Id","Name");

      
            ViewBag.IsSuccess = isSuccess;
            ViewBag.BookId = bookId;
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> AddNewBook(BookModel bookModel)
        {
            if (ModelState.IsValid)
            {
                int id = await _bookRepository.AddNewBook(bookModel);
                if (id > 0)
                {
                    return RedirectToAction(nameof(AddNewBook), new { isSuccess = true, bookId = id });
                }
            }
             ViewBag.Language = new SelectList(await _languageRepository.GetLanguages(),"Id","Name");


            return View();
        }


    }
}