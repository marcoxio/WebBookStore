using System.Collections.Generic;
using System.Linq;
using WebBookStore.Models;

namespace WebBookStore.Repository
{
    public class BookRepository
    {
        public List<BookModel> GetAllBooks()
        {
            return DataSource();
        }

        public BookModel GetBookById(int id)
        {
            return DataSource().Where(x => x.Id == id).FirstOrDefault();
        }

          public List<BookModel> SearchBook(string title,string authorName)
        {
            return DataSource().Where(x => x.Title.Contains(title) || x.Author.Contains(authorName)).ToList();
        }

        private List<BookModel> DataSource()
        {
            return new List<BookModel>()
            {
                new BookModel(){Id =1, Title="MVC", Author="Jhon Doe"},
                new BookModel(){Id =2, Title="C#", Author="Jhon Doe"},
                new BookModel(){Id =3, Title="F#", Author="Jhon Doe"},
                new BookModel(){Id =4, Title="NetCore 3.1", Author="Jhon Doe"},
            };
        }
    }
}