    using Amazon.DynamoDBv2.DocumentModel;
    using bookstore.models;
    using System;

    public class BookService
    {
        public books MapDocumentToBook(Document document)
        {
            var book = new books
            {
                BookID = Convert.ToInt32(document["BookID"].AsString()),
                Titulo = document["Titulo"].AsString(),
                Autor = document["Autor"].AsString(),
                Sinopse = document["Sinopse"].AsString(),
                Editora = document["Editora"].AsString(),
                Preco = Convert.ToDecimal(document["Preco"].AsString()),
                Categoria = document["Categoria"].AsString(),
                Quantidade = Convert.ToInt32(document["Quantidade"].AsString())
            };

            if (document.ContainsKey("Capa") && document["Capa"] is Document capa)
            {
                book.Capa = new BookCover
                {
                    Base64 = capa["Base64"].AsString(),
                    NomeArquivo = capa["NomeArquivo"].AsString(),
                    TamanhoArquivo = Convert.ToInt64(capa["TamanhoArquivo"].AsString()),
                    TipoArquivo = capa["TipoArquivo"].AsString()
                };
            }

            return book;
        }
    }
