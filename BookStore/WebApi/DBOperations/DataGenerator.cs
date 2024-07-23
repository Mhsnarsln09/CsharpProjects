using Microsoft.EntityFrameworkCore;

namespace WebApi.DBOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
                // Look for any board games.
                if (context.Books.Any())
                {
                    return;   // Data was already seeded
                }

                context.Books.AddRange(
                    new Book { Title = "The Great Gatsby", GenreId = 1, PageCount = 180, PublishDate = new DateTime(1925, 4, 10) },
                    new Book { Title = "No Name", GenreId = 2, PageCount = 200, PublishDate = new DateTime(1949, 1, 1) },
                    new Book { Title = "The Catcher in the Rye", GenreId = 1, PageCount = 220, PublishDate = new DateTime(1951, 7, 16) },
                    new Book { Title = "The Grapes of Wrath", GenreId = 2, PageCount = 230, PublishDate = new DateTime(1939, 4, 14) },
                    new Book { Title = "The Sun Also Rises", GenreId = 1, PageCount = 240, PublishDate = new DateTime(1926, 10, 22) }
                );

                if (context.Authors.Any())
                {
                    return;   // Data was already seeded
                }

                context.Authors.AddRange(
                    new Author { FirstName = "F. Scott", LastName = "Fitzgerald", Genre = "Fiction", Country = "USA" },
                    new Author { FirstName = "William", LastName = "Thackeray", Genre = "Fiction", Country = "UK" },
                    new Author { FirstName = "J.D.", LastName = "Salinger", Genre = "Fiction", Country = "USA" },
                    new Author { FirstName = "John", LastName = "Steinbeck", Genre = "Fiction", Country = "USA" },
                    new Author { FirstName = "Ernest", LastName = "Hemingway", Genre = "Fiction", Country = "USA" }
                );
                context.SaveChanges();
            }

        }
    }
}