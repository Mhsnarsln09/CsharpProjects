using Microsoft.AspNetCore.Mvc;
using WebApi.DBOperations;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]s")]
    public class AuthorController : ControllerBase
    {
        private readonly BookStoreDbContext _context;

        public AuthorController(BookStoreDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<Author> GetAuthors()
        {
            var authorList = _context.Authors.OrderBy(x => x.Id).ToList<Author>();
            return authorList;
        }

        [HttpGet("{id}")]
        public Author GetById(int id)
        {
            var author = _context.Authors.Where(x => x.Id == id).SingleOrDefault();
            return author;
        }

        [HttpPost]
        public IActionResult AddAuthor([FromBody] Author newAuthor)
        {
            var author = _context.Authors.SingleOrDefault(x => x.FirstName == newAuthor.FirstName && x.LastName == newAuthor.LastName);
            if (author is not null)
            {
                return BadRequest("Author already exists");
            }
            _context.Authors.Add(newAuthor);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAuthor(int id, [FromBody] Author updatedAuthor)
        {
            var author = _context.Authors.SingleOrDefault(x => x.Id == id);
            if (author is null)
            {
                return NotFound();
            }
            author.FirstName = updatedAuthor.FirstName != default ? updatedAuthor.FirstName : author.FirstName;
            author.LastName = updatedAuthor.LastName != default ? updatedAuthor.LastName : author.LastName;
            author.Genre = updatedAuthor.Genre != default ? updatedAuthor.Genre : author.Genre;
            author.Country = updatedAuthor.Country != default ? updatedAuthor.Country : author.Country;
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAuthor(int id)
        {
            var author = _context.Authors.SingleOrDefault(x => x.Id == id);
            if (author is null)
            {
                return NotFound();
            }
            _context.Authors.Remove(author);
            _context.SaveChanges();
            return Ok();
        }
    }
}