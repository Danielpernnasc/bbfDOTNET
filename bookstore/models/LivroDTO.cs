using static bookstore.models.Books;
using System.ComponentModel.DataAnnotations;

namespace bookstore.models
{
    public class LivroDTO
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "O campo Título é obrigatório.")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "O campo Autor é obrigatório.")]
        public string Autor { get; set; }

        [Required(ErrorMessage = "O campo Editora é obrigatório.")]
        public string Editora { get; set; }

        [Required(ErrorMessage = "O campo Preço é obrigatório.")]
        public decimal Preco { get; set; }

        public string Sinopse { get; set; }

        [Required(ErrorMessage = "O campo Quantidade é obrigatório.")]
        [Range(0, int.MaxValue, ErrorMessage = "O campo Quantidade deve ser um número positivo.")]
        public int Quantidade { get; set; }

        [Required(ErrorMessage = "O campo Capa é obrigatório.")]
        public BookCover Capa { get; set; }
    }
}
