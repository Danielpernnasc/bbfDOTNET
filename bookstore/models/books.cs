using Microsoft.EntityFrameworkCore;
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

        [Required(ErrorMessage = "O campo Categoria é obrigatória.")]
        public string Categoria { get; set; }

        public int Quantidade { get; set; }

        // Propriedade de navegação própria para CoverBook
        public CoverBook Capa { get; set; }

        // Construtor com parâmetros para inicialização
        public Books(int id, string titulo, string autor, string editora, decimal preco, string sinopse, CoverBook capa, int quantidade, string categoria)
        {
            ID = id;
            Titulo = titulo;
            Autor = autor;
            Editora = editora;
            Preco = preco;
            Sinopse = sinopse;
            Capa = capa;
            Quantidade = quantidade;
            Categoria = categoria;
        }

        // Construtor sem parâmetros requerido para serialização JSON
        public Books()
        {
            // Inicialize propriedades com valores padrão se necessário
        }
    }

    public class CoverBook
    {
        public string ImagemNome { get; set; }
        public string ImagemTipo { get; set; }
        public decimal ImagemTamanho { get; set; }
        public string Base64 { get; set; }

        // Construtor com parâmetros para inicialização
        public CoverBook(string imagemNome, string imagemTipo, decimal imagemTamanho, string base64)
        {
            ImagemNome = imagemNome;
            ImagemTipo = imagemTipo;
            ImagemTamanho = imagemTamanho;
            Base64 = base64;
        }

        // Construtor sem parâmetros requerido para serialização JSON
        public CoverBook()
        {
            // Inicialize propriedades com valores padrão se necessário
        }
    }

   
}
    