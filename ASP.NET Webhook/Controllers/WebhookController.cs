using ASP.NET_Webhook.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using static ASP.NET_Webhook.Helper;

namespace ASP.NET_Webhook.Controllers
{
    public class WebhookController : Controller
    {

        [HttpPost]
        [Route("webhook/receive")]
        public async Task<IActionResult> Receive()
        {
            try
            {
                var auth = Request.Headers.Keys;
                if (auth.Contains("Api-Key"))
                {
                    var authHeader = Request.Headers.Where(k => k.Key == "Api-Key").FirstOrDefault();
                    var authValue = authHeader.Value;

                    if (authValue != "1111")
                    {
                        return BadRequest("Authendication value incorrect");
                    }
                }
                else
                {
                    return BadRequest("Authendication Header Not Found");
                }

                List<WebhookPayload> WebhookPayloadList = new List<WebhookPayload>();

                using (var reader = new StreamReader(Request.Body))
                {

                    string jsonString = await reader.ReadToEndAsync();

                    if (jsonString == "")
                    {
                        return BadRequest("Empty Request");
                    }

                    JObject json = JObject.Parse(jsonString);


                    if (json.ContainsKey("data"))
                    {
                        JArray dataArray = (JArray)json["data"];

                        foreach (JObject obj in dataArray)
                        {
                            WebhookPayload WebhookPayload = new WebhookPayload();
                            List<WebhookAttributeValues> WebhookAttributeValuesList = new List<WebhookAttributeValues>();

                            foreach (var property in obj.Properties())
                            {

                                WebhookAttributeValues WebhookAttributeValues = new WebhookAttributeValues();

                                WebhookAttributeValues.PayloadAttribute1 = property.Name;
                                WebhookAttributeValues.PayloadAttribute2 = int.Parse(property.Value.ToString());

                                WebhookPayload.PayloadID = int.Parse(property.Value.ToString());

                                WebhookAttributeValuesList.Add(WebhookAttributeValues);

                            }

                            WebhookPayload.WebhookPayloadList = WebhookAttributeValuesList;
                            WebhookPayloadList.Add(WebhookPayload);
                        }
                    }
                }

                DBPost(WebhookPayloadList);

                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}




