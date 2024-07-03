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

        public CoverBook Capa { get; set; }

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

        public Books()
        {
        }
    }

    public class CoverBook
    {
        private static readonly string[] AllowedImageTypes = { "image/jpg", "image/jpeg", "image/png", "image/tiff", "image/svg+xml" };
        public string ImagemNome { get; set; }
        public string ImagemTipo { get; set; }
        public decimal ImagemTamanho { get; set; }
        public string Base64 { get; set; }

        public CoverBook(string imagemNome, string imagemTipo, decimal imagemTamanho, string base64)
        {
            if (Array.IndexOf(AllowedImageTypes, imagemTipo.ToLower()) == -1)
            {
                throw new ArgumentException("Tipo de imagem não permitido. Permitido somente: JPG, JPEG, PNG, TIFF, SVG");
            }
            ImagemNome = imagemNome;
            ImagemTipo = imagemTipo;
            ImagemTamanho = imagemTamanho;
            Base64 = base64;
        }

        public CoverBook()
        {
        }
    }
}
