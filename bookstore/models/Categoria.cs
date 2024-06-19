using System.Collections.Generic;

namespace bookstore.models
{
    public class Categoria
    {
        public List<LivroDTO> LiteraturaEstrangeira { get; set; } = new List<LivroDTO>();
        public List<LivroDTO> LiteraturaNacional { get; set; } = new List<LivroDTO>();
        public List<LivroDTO> Politica { get; set; } = new List<LivroDTO>();
        public List<LivroDTO> Filosofia { get; set; } = new List<LivroDTO>();
        public List<LivroDTO> Economia { get; set; } = new List<LivroDTO>();
    }
}

