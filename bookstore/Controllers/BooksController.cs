using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using bookstore.Data;
using bookstore.models;
using System.IO;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

namespace bookstore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookstoreDbContext _context;
        private readonly DynamoDBService _dynamoDBService;
        private readonly IDynamoDBContext _dynamoDBContext;

        public BooksController(
            BookstoreDbContext context,
            IAmazonDynamoDB dynamoDBClient,
            DynamoDBService dynamoDBService)
        {
            _context = context;
            _dynamoDBService = dynamoDBService;
            _dynamoDBContext = new DynamoDBContext(dynamoDBClient);
        }

        [HttpGet]
        [ProducesResponseType(typeof(Categoria), 200)]
        public async Task<ActionResult<Categoria>> GetBooks()
        {
            var allBooks = await GetAllBooksAsync();
            Categoria categorias = BuildCategoria(allBooks);
            return Ok(categorias);
        }

        [HttpPost]
        [ProducesResponseType(typeof(books), 201)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        public async Task<ActionResult<books>> PostBook([FromForm] books book, IFormFile file)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Obtém o próximo ID
            int nextBookId = await _dynamoDBService.GetNextBookId();
            book.BookID = nextBookId;

            // Processa o arquivo de capa
            if (file != null && file.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await file.CopyToAsync(memoryStream);
                    book.Capa = new BookCover
                    {
                        Base64 = Convert.ToBase64String(memoryStream.ToArray()),
                        NomeArquivo = file.FileName,
                        TamanhoArquivo = file.Length,
                        TipoArquivo = file.ContentType
                    };
                }
            }

            try
            {
                await _dynamoDBContext.SaveAsync(book);
                return CreatedAtAction(nameof(GetBookById), new { id = book.BookID }, book);
            }
            catch (Exception ex)
            {
                // Log do erro para monitoramento
                return BadRequest($"Erro ao inserir o livro: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(books), 200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<books>> GetBookById(int id)
        {
            var book = await _dynamoDBContext.LoadAsync<books>(id);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> PutBook(int id, [FromBody] books book)
        {
            if (id != book.BookID)
            {
                return BadRequest("ID do livro na URL não corresponde ao ID do livro no corpo da requisição.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Entry(book).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> DeleteBook(int id)
        {
            var book = await _context.Books.FindAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BookExists(int id)
        {
            return _context.Books.Any(e => e.BookID == id);
        }

        private async Task<List<books>> GetAllBooksAsync()
        {
            return await _dynamoDBContext.ScanAsync<books>(new List<ScanCondition>()).GetRemainingAsync();
        }

        private static Categoria BuildCategoria(List<books> allBooks)
        {
            return new Categoria
            {
                LiteraturaEstrangeira = GetBooksByCategoria(allBooks, "Literatura Estrangeira"),
                LiteraturaNacional = GetBooksByCategoria(allBooks, "Literatura Nacional"),
                Politica = GetBooksByCategoria(allBooks, "Politica"),
                Filosofia = GetBooksByCategoria(allBooks, "Filosofia"),
                Economia = GetBooksByCategoria(allBooks, "Economia")
            };
        }

        private static List<books> GetBooksByCategoria(List<books> allBooks, string categoria)
        {
            return allBooks.Where(b => b.Categoria == categoria).ToList();
        }
    }
}
