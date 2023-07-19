using Newtonsoft.Json.Linq;

namespace ASP.NET_Webhook.Models
{
    public class WebhookAttributeValues
    {
        public string PayloadAttribute1 { get; set; }
        public int PayloadAttribute2 { get; set; }

    }

    public class WebhookPayload
    {
        public int PayloadID { get; set; }
        public List<WebhookAttributeValues> WebhookPayloadList { get; set; }
    }

    public class DBContext
    {
        public int DBID { get; set; }
        public string DBName { get; set; }
        public int DBAttribute1 { get; set; }
    }
}
