namespace bookstore.models
{
    public class Categoria
    {
        public List<LivroDTO> LiteraturaEstrangeira { get; set; } = new List<LivroDTO>();
        public List<LivroDTO> LiteraturaNacional { get; set; } = new List<LivroDTO>();
        public List<LivroDTO> LiteraturaInfatoJuv { get; set; } = new List<LivroDTO>();
        public List<LivroDTO> Infantil { get; set; } = new List<LivroDTO>();
        public List<LivroDTO> Religioso { get; set; } = new List<LivroDTO>();
        public List<LivroDTO> Politica { get; set; } = new List<LivroDTO>();
        public List<LivroDTO> Filosofia { get; set; } = new List<LivroDTO>();
        public List<LivroDTO> Historia { get; set; } = new List<LivroDTO>();
        public List<LivroDTO> Economia { get; set; } = new List<LivroDTO>();
        public List<LivroDTO> Negocios { get; set; } = new List<LivroDTO>();
        public List<LivroDTO> AutoAjuda { get; set; } = new List<LivroDTO>();
        public List<LivroDTO> Tecnologia { get; set; } = new List<LivroDTO>();
        public List<LivroDTO> DireitosCivis { get; set; } = new List<LivroDTO>();
        public List<LivroDTO> Gastronomia { get; set; } = new List<LivroDTO>();
        public List<LivroDTO> Arte { get; set; } = new List<LivroDTO>();
    }

    public class LivroDTO
    {
        public int ID { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Editora { get; set; }
        public decimal Preco { get; set; }
        public string Sinopse { get; set; }
        public CoverBook Capa { get; set; }
        public int Quantidade { get; set; }
    }
}