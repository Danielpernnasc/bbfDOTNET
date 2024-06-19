using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2.Model;
using System.Threading.Tasks;

public class DynamoDBService
{
    private readonly IAmazonDynamoDB _dynamoDBClient;

    public DynamoDBService(IAmazonDynamoDB dynamoDBClient)
    {
        _dynamoDBClient = dynamoDBClient;
    }

    public async Task<int> GetNextBookId()
    {
        var request = new UpdateItemRequest
        {
            TableName = "Counter",
            Key = new Dictionary<string, AttributeValue>
            {
                { "CounterId", new AttributeValue { S = "BookId" } }
            },
            UpdateExpression = "SET CurrentValue = CurrentValue + :increment",
            ExpressionAttributeValues = new Dictionary<string, AttributeValue>
            {
                { ":increment", new AttributeValue { N = "1" } }
            },
            ReturnValues = "UPDATED_NEW"
        };

        var response = await _dynamoDBClient.UpdateItemAsync(request);
        return int.Parse(response.Attributes["CurrentValue"].N);
    }
}
