using System.ComponentModel.DataAnnotations;

namespace bookstore.models
{
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
    }
}
