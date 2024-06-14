
using Microsoft.AspNetCore.Mvc;
using bookstore.Data;
using bookstore.models;
using Microsoft.EntityFrameworkCore;

namespace bookstore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController: ControllerBase
    {

        private readonly BookstoreDbContext _context;

        public BooksController(BookstoreDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        //public async Task<ActionResult<IEnumerable<Books>>> GetBook() antigo

        public async Task<ActionResult<Categoria>> GetBook()
        {
            var livros = await _context.Books.ToListAsync();


            Categoria categorias = new Categoria();

            categorias.LiteraturaEstrangeira = 
               livros.Where(b => b.Categoria == "Literatura Estrangeira").Select(b =>
               new LivroDTO
               {
                    ID = b.ID,
                    Titulo = b.Titulo,
                    Autor = b.Autor,
                    Editora = b.Editora,
                    Preco = b.Preco,
                    Sinopse = b.Sinopse 
                    }).ToList();
            categorias.LiteraturaNacional = livros
               .Where(b => b.Categoria == "Literatura Nacional")
               .Select(b => new LivroDTO
               {
                   ID = b.ID,
                   Titulo = b.Titulo,
                   Autor = b.Autor,
                   Editora = b.Editora,
                   Preco = b.Preco,
                   Sinopse = b.Sinopse
               }).ToList();
            categorias.Politica = livros.Where(b => b.Categoria == "Politica")
            .Select(b => new LivroDTO
            {
                ID = b.ID,
                Titulo = b.Titulo,
                Autor = b.Autor,
                Editora = b.Editora,
                Preco = b.Preco,
                Sinopse = b.Sinopse
            }).ToList();
            categorias.Filosofia = livros.Where(b => b.Categoria == "Filosofia")
            .Select(b => new LivroDTO
            {
                ID = b.ID,
                Titulo = b.Titulo,
                Autor = b.Autor,
                Editora = b.Editora,
                Preco = b.Preco,
                Sinopse = b.Sinopse
            }).ToList();
            categorias.Economia = livros.Where(b => b.Categoria == "Economia")
            .Select(b => new LivroDTO
            {
                ID = b.ID,
                Titulo = b.Titulo,
                Autor = b.Autor,
                Editora = b.Editora,
                Preco = b.Preco,
                Sinopse = b.Sinopse
            }).ToList();

            return categorias;

        }

        [HttpPost]
        public async Task<ActionResult<Books>> PostBook([FromBody] Books book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _context.Books.Add(book);
                await _context.SaveChangesAsync();

                // Retorna um CreatedAtAction com o ID do livro recém-criado
                return CreatedAtAction(nameof(GetBookId), new { id = book.ID }, book);
            }
            catch (Exception ex)
            {
                // Em caso de erro durante a inserção, retorna um BadRequest com a mensagem de erro
                return BadRequest($"Erro ao inserir o livro: {ex.Message}");
            }
        }


        [HttpGet("{id}")]
        public async Task<ActionResult> GetBookId(int id)
        {
            var book = await _context.Books.FindAsync(id);

            if(book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Books>> PutBook(int id, [FromBody] Books book)
        {
            if (id != book.ID)
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
                if (!BookExist(id))
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

        public async Task<ActionResult> Delete(int id)
        {
            var book = await _context.Books.FindAsync(id);

            if(book == null)
            {
                return NotFound();
            }

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BookExist(int id)
        {
            return _context.Books.Any(e => e.ID == id);
        }






    }
}
