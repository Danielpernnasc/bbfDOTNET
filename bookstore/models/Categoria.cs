using Amazon.DynamoDBv2.DataModel;
using bookstore.models;


[DynamoDBTable("Categorias")]
public class Categoria
{
    

    [DynamoDBProperty("LivrosLiteraturaEstrangeira")]
    public List<books> LiteraturaEstrangeira { get; set; }

    [DynamoDBProperty("LivrosLiteraturaNacional")]
    public List<books> LiteraturaNacional { get; set; }

    [DynamoDBProperty("LivrosPolitica")]
    public List<books> Politica { get; set; }

    [DynamoDBProperty("LivrosFilosofia")]
    public List<books> Filosofia { get; set; }

    [DynamoDBProperty("LivrosEconomia")]
    public List<books> Economia { get; set; }
}

