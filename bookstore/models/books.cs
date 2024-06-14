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

        // Construtor com parâmetros para inicialização
        public Books(int id, string titulo, string autor, string editora, decimal preco, string sinopse)
        {
            ID = id;
            Titulo = titulo;
            Autor = autor;
            Editora = editora;
            Preco = preco;
            Sinopse = sinopse;
            Categoria = "Geral"; // Definir categoria padrão se necessário
        }

        // Construtor sem parâmetros requerido para serialização JSON
        public Books()
        {
            // Inicialize propriedades com valores padrão se necessário
        }
    }
}
