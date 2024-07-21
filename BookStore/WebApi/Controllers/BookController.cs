using Microsoft.AspNetCore.Mvc;


namespace WepAbi.Controllers
{

    [ApiController]
    [Route("api/[controller]s")]
    public class BookController : ControllerBase
    {
        private static List<Book> BookList = new List<Book>
        {
            new Book { Id = 1, Title = "The Great Gatsby", GenreId = 1, PageCount = 180, PublishDate = new DateTime(1925, 4, 10) },
            new Book { Id = 2, Title = "No Name", GenreId = 2, PageCount = 200, PublishDate = new DateTime(1949, 1, 1) },
            new Book { Id = 3, Title = "The Catcher in the Rye", GenreId = 1, PageCount = 220, PublishDate = new DateTime(1951, 7, 16) },
            new Book { Id = 4, Title = "The Grapes of Wrath", GenreId = 2, PageCount = 230, PublishDate = new DateTime(1939, 4, 14) },
            new Book { Id = 5, Title = "The Sun Also Rises", GenreId = 1, PageCount = 240, PublishDate = new DateTime(1926, 10, 22) }
        };

        [HttpGet]
         public List<Book> GetBooks()
        {
            var bookList = BookList.OrderBy(x => x.Id).ToList<Book>();
            return bookList;
        }

        [HttpGet("{id}")]
        public Book GetById(int id)
        {
            var book = BookList.Where(x => x.Id == id).SingleOrDefault();
            return book;
        }

        [HttpPost]
        public IActionResult AddBook([FromBody] Book newBook)
        {
            var book = BookList.SingleOrDefault(x => x.Title == newBook.Title);
            if (book is not null)
            {
                return BadRequest("Book already exists");
            }
            BookList.Add(newBook);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] Book updatedBook)
        {
            var book = BookList.SingleOrDefault(x => x.Id == id);
            if (book is null)
            {
                return NotFound();
            }
            book.Title = updatedBook.Title != default ? updatedBook.Title : book.Title;
            book.GenreId = updatedBook.GenreId != default ? updatedBook.GenreId : book.GenreId;
            book.PageCount = updatedBook.PageCount  != default ? updatedBook.PageCount : book.PageCount;
            book.PublishDate = updatedBook.PublishDate  != default ? updatedBook.PublishDate : book.PublishDate;
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var book = BookList.SingleOrDefault(x => x.Id == id);
            if (book is null)
            {
                return NotFound();
            }
            BookList.Remove(book);
            return Ok();
        }
    }
}