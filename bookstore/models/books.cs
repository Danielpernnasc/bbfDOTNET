using Amazon.DynamoDBv2.DataModel;

namespace bookstore.models
{
    [DynamoDBTable("StockBooks")]
    public class books
    {
        [DynamoDBHashKey] // Chave de partição
        public int BookID { get; set; }

        [DynamoDBProperty]
        public string Autor { get; set; }

        [DynamoDBProperty("Capa")]
        public BookCover Capa { get; set; }

        [DynamoDBProperty]
        public string Categoria { get; set; }

        [DynamoDBProperty]
        public string Editora { get; set; }

        [DynamoDBProperty]
        public decimal Preco { get; set; }

        [DynamoDBProperty]
        public int Quantidade { get; set; }

        [DynamoDBProperty]
        public string Sinopse { get; set; }

        [DynamoDBProperty]
        public string Titulo { get; set; }
    }

    public class BookCover
    {
        [DynamoDBProperty]
        public string Base64 { get; set; }

        [DynamoDBProperty]
        public string NomeArquivo { get; set; }

        [DynamoDBProperty]
        public long TamanhoArquivo { get; set; }

        [DynamoDBProperty]
        public string TipoArquivo { get; set; }
    }
}
