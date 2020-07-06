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

        public BookController(BookRepository bookRepository)
        {
            _bookRepository = bookRepository;
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
        public IActionResult AddNewBook(bool isSuccess = false, int bookId = 0)
        {
              var model = new BookModel()
             {
                //     Language = "2"
                 
             };

             //Implement by  Linq
            //  ViewBag.Language = GetLanguage().Select(x => new SelectListItem(){
            //      Text = x.Text,
            //      Value = x.Id.ToString()
            //  }).ToList();

        

            //  ViewBag.Language = new List<SelectListItem>()
            // {
            //     new SelectListItem(){Text = "Hindi", Value = "1", Group = group1 },
            //     new SelectListItem(){Text = "English", Value = "2", Group = group1 },
            //     new SelectListItem(){Text = "Dutch", Value = "3", Group = group2},
            //     new SelectListItem(){Text = "Tamil", Value = "4", Group = group2 },
            //     new SelectListItem(){Text = "Urdu", Value = "5" , Group = group3},
            //     new SelectListItem(){Text = "Chinese", Value = "6", Group = group3 },
            // };
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

            ViewBag.Language = new SelectList(GetLanguage(), "Id", "Text");
            // ModelState.AddModelError("", "This is my custom error message");
            // ModelState.AddModelError("", "This is my second custom error message");
            return View();
        }


        private List<LanguageModel> GetLanguage()
        {
            return new List<LanguageModel>()
            {
                new LanguageModel(){ Id = 1, Text = "Hindi"},
                new LanguageModel(){ Id = 2, Text = "English"},
                new LanguageModel(){ Id = 3, Text = "Dutch"},
            };
        }
    }
}