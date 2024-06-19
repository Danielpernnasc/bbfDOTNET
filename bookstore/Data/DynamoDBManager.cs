using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2;
using bookstore.models;

namespace bookstore.Data
{
    public class DynamoDBManager
    {
        private readonly IAmazonDynamoDB _dynamoDBClient;
        private readonly DynamoDBContext _context;

        public DynamoDBManager()
        {
            _dynamoDBClient = new AmazonDynamoDBClient();
            _context = new DynamoDBContext(_dynamoDBClient);
        }

        public async Task InsertBookAsync(books book)
        {
            await _context.SaveAsync(book);
        }
    }
}
