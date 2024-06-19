using Amazon;
using Amazon.DynamoDBv2;
using Amazon.Runtime;

public static class DynamoDBConfig
{
    public static AmazonDynamoDBClient InitializeDynamoClient()
    {
        var awsCredentials = new BasicAWSCredentials("YourAccessKeyId", "YourSecretAccessKey");
        var config = new AmazonDynamoDBConfig
        {
            RegionEndpoint = RegionEndpoint.USEast1 // Substitua pela sua região AWS correta
        };

        var client = new AmazonDynamoDBClient(awsCredentials, config);
        return client;
    }
}
