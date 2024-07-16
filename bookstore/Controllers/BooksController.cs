
using Microsoft.AspNetCore.Mvc;
using bookstore.models;
using Microsoft.EntityFrameworkCore;

namespace bookstore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController: ControllerBase
    {

        private readonly BookStoreContext _context;

        public BooksController(BookStoreContext context)
        {
            _context = context;
        }

        [HttpGet]
        //public async Task<ActionResult<IEnumerable<Books>>> GetBook() antigo

        public async Task<ActionResult<Categoria>> GetBook()
        {
            var livros = await _context.Books.ToListAsync();


            Categoria categorias = new Categoria();

            categorias.LiteraturaEstrangeira = GetLivrosPorCategoria(livros, "Literatura Estrangeira");
            categorias.LiteraturaNacional = GetLivrosPorCategoria(livros, "Literatura Nacional");
            categorias.LiteraturaInfatoJuv = GetLivrosPorCategoria(livros, "Literatura Infato-Juvenil");
            categorias.Infantil = GetLivrosPorCategoria(livros, "Infantil");
            categorias.Religioso = GetLivrosPorCategoria(livros, "Religioso");
            categorias.Politica = GetLivrosPorCategoria(livros, "Politica");
            categorias.Filosofia = GetLivrosPorCategoria(livros, "Filosofia");
            categorias.Economia = GetLivrosPorCategoria(livros, "Economia");

            return categorias;

        }

        private List<LivroDTO> GetLivrosPorCategoria(List<Books> livros, string categoria)
        {
            return livros
                 .Where(b => b.Categoria.Equals(categoria, StringComparison.OrdinalIgnoreCase))
                  .Select(b => new LivroDTO
                  {
                    ID = b.ID,
                    Titulo = b.Titulo,
                    Autor = b.Autor,
                    Editora = b.Editora,
                    Preco = b.Preco,
                    Sinopse = b.Sinopse,
<<<<<<< HEAD
                    Capa = new CoverBook
                    {
                        ImagemNome = b.Capa.ImagemNome,
                        ImagemTipo = b.Capa.ImagemTipo,
                        ImagemTamanho = b.Capa.ImagemTamanho,
                        Base64 = b.Capa.Base64
                    },
=======
                    Capa = b.Capa,
>>>>>>> a84e7b30727f784cac4959528ad35dc87342afda
                    Quantidade = b.Quantidade
                }).ToList();
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
