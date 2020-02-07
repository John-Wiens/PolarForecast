using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;


namespace WebApplication4
{
    public partial class Teams : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AmazonDynamoDBConfig clientConfig = new AmazonDynamoDBConfig();
            clientConfig.RegionEndpoint = RegionEndpoint.USEast1;
            AmazonDynamoDBClient client = new AmazonDynamoDBClient(clientConfig);
            //string tableName = "PF_TEAM_DATA_2019";
            string tableName = "PF_EVENT_DATA_2019";

            var request = new GetItemRequest
            {
                TableName = tableName,
                Key = new Dictionary<string, AttributeValue>() { { "event_key", new AttributeValue { S = "2019code" } } },
                ConsistentRead = true
            };
            var response = client.GetItem(request);

            // Check the response.
            //var result = response.GetItemResult();
            var attributeMap = response.Item; // Attribute list in the response.
            string test = "itemgrabbed";
            //This line is being added just to test commits
            
            //// View response
            //System.Diagnostics.Debug.WriteLine("Item:");
            
            //var JSONObj = new JavaScriptSerializer().Deserialize<Dictionary<string, string>>(attributeMap);

          
            //string lastTableNameEvaluated = null;
            //do
            //{
            //    var request = new ListTablesRequest
            //    {
            //        Limit = 2,
            //        ExclusiveStartTableName = lastTableNameEvaluated
            //    };

            //    var response = client.ListTables(request);
            //    foreach (string name in response.TableNames)
            //        System.Diagnostics.Debug.WriteLine(name);

            //    lastTableNameEvaluated = response.LastEvaluatedTableName;
            //} while (lastTableNameEvaluated != null);
        }
    }

 
}