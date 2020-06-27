using Microsoft.AspNetCore.Mvc;

namespace WebBookStore.Controllers
{
    public class BookController : Controller
    {
        public string GetAllBooks()
        {
            return "All Books";
        }

        public string GetBook(int id)
        {
            return $"book with id = {id}";
        }

        public string SearchBooks(string bookName,string authorName)
        {
            return $"Boom with name = {bookName} & Author = {authorName}";
        }
    }
}