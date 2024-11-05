using Microsoft.AspNetCore.Mvc;

namespace asp_core_less_one.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")] // api/v1/book
    public class BookController : Controller
    {
        private static List<Book> books = new List<Book>
        {
            new Book { Id = 1, Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", Price = 100 },
            new Book { Id = 2, Title = "Don Quixote", Author = "Miguel de Cervantes", Price = 150 },
            new Book { Id = 3, Title = "1984", Author = "George Orwell", Price = 120 }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetBooks()
        {
            return Ok(books);
        }
        [HttpGet("{id}")]
        public ActionResult<Book> GetBookById(int id)
        {
            foreach (Book book in books)
            {
                if (book.Id == id)
                {
                    return Ok(book);
                }
            }
            return Ok("Not found");
        }

        [HttpPost]
        public ActionResult<Book> AddBook(Book book)
        {
            book.Id = books.Count + 1;
            books.Add(book);
            return Ok(book);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteBook(int id)
        {
            foreach (Book book in books)
            {
                if (book.Id == id)
                {
                    books.Remove(book);
                    return Ok("Deleted");
                }
            }
            return Ok("Not found");
        }

        [HttpPut("{id}")]
        public ActionResult UpdateBook(int id, Book book)
        {
            foreach (Book b in books)
            {
                if (b.Id == id)
                {
                    b.Title = book.Title;
                    b.Author = book.Author;
                    b.Price = book.Price;
                    return Ok(b);
                }
            }
            return Ok("Not found");
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
