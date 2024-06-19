using System.Buffers.Text;
using System.ComponentModel.DataAnnotations;

namespace bookstore.models
{
    public class Books
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "O campo Título é obrigatório.")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "O campo Autor é obrigatório.")]
        public string Autor { get; set; }

        [Required(ErrorMessage = "O campo Editora é obrigatório.")]
        public string Editora { get; set; }

        public string Sinopse { get; set; }

        [Required(ErrorMessage = "O campo Preço é obrigatório.")]
        public decimal Preco { get; set; }

        [Required(ErrorMessage = "O campo Categoria é obrigatório.")]
        public string Categoria { get; set; }

        public int Quantidade { get; set; }

        [Required(ErrorMessage = "O campo Capa é obrigatório.")]
        public BookCover Capa { get; set; }

        public class BookCover
        {
            [Required(ErrorMessage = "O campo Base64 é obrigatório.")]
            public string Base64 { get; set; }

            [Required(ErrorMessage = "O campo NomeArquivo é obrigatório.")]
            public string NomeArquivo { get; set; }

            [Required(ErrorMessage = "O campo TamanhoArquivo é obrigatório.")]
            public long TamanhoArquivo { get; set; }

            [Required(ErrorMessage = "O campo TipoArquivo é obrigatório.")]
            public string TipoArquivo { get; set; }

            public BookCover(string base64, string nomeArquivo, long tamanhoArquivo, string tipoArquivo)
            {
                Base64 = base64;
                NomeArquivo = nomeArquivo;
                TamanhoArquivo = tamanhoArquivo;
                TipoArquivo = tipoArquivo;
            }
        }

        // Construtor com parâmetros para inicialização
        public Books(int id, string titulo, string autor, string editora, decimal preco, string sinopse, int quantidade, BookCover capa)
        {
            ID = id;
            Titulo = titulo;
            Autor = autor;
            Editora = editora;
            Preco = preco;
            Sinopse = sinopse;
            Quantidade = quantidade;
            Categoria = "Geral"; // Definir categoria padrão se necessário
            Capa = capa; // Inicializa o objeto BookCover diretamente
        }

        // Construtor sem parâmetros requerido para serialização JSON
        public Books()
        {
            // Inicialize propriedades com valores padrão se necessário
        }
    }
}
