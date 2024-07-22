using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]s")]
    public class AuthorController : ControllerBase
    {
       private static List<Author> AuthorList = new List<Author>
        {
            new Author { Id = 1, FirstName = "F. Scott", LastName = "Fitzgerald", Genre = "Fiction", Country = "USA" },
            new Author { Id = 2, FirstName = "William", LastName = "Thackeray", Genre = "Fiction", Country = "UK" },
            new Author { Id = 3, FirstName = "J.D.", LastName = "Salinger", Genre = "Fiction", Country = "USA" },
            new Author { Id = 4, FirstName = "John", LastName = "Steinbeck", Genre = "Fiction", Country = "USA" },
            new Author { Id = 5, FirstName = "Ernest", LastName = "Hemingway", Genre = "Fiction", Country = "USA" }
        };

        [HttpGet]
        public List<Author> GetAuthors()
        {
            var authorList = AuthorList.OrderBy(x => x.Id).ToList<Author>();
            return authorList;
        }

        [HttpGet("{id}")]
        public Author GetById(int id)
        {
            var author = AuthorList.Where(x => x.Id == id).SingleOrDefault();
            return author;
        }

        [HttpPost]
        public IActionResult AddAuthor([FromBody] Author newAuthor)
        {
            var author = AuthorList.SingleOrDefault(x => x.FirstName == newAuthor.FirstName && x.LastName == newAuthor.LastName);
            if (author is not null)
            {
                return BadRequest("Author already exists");
            }
            AuthorList.Add(newAuthor);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAuthor(int id, [FromBody] Author updatedAuthor)
        {
            var author = AuthorList.SingleOrDefault(x => x.Id == id);
            if (author is null)
            {
                return NotFound();
            }
            author.FirstName = updatedAuthor.FirstName != default ? updatedAuthor.FirstName : author.FirstName;
            author.LastName = updatedAuthor.LastName != default ? updatedAuthor.LastName : author.LastName;
            author.Genre = updatedAuthor.Genre != default ? updatedAuthor.Genre : author.Genre;
            author.Country = updatedAuthor.Country != default ? updatedAuthor.Country : author.Country;
            return Ok();
        }
    }
}