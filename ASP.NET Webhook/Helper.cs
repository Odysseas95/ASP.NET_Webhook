using System.Net;
using System.Net.Mail;
using ASP.NET_Webhook.Models;

namespace ASP.NET_Webhook
{
    public class Helper
    {

        public static string DBPost(List<WebhookPayload> WebhookPayload)
        {
            try
            {
                //Use this part to directly connect to Database 

                //using (var _DBContext = new DBContext())
                //{


                //    _DBContext.StreamVechicleStatusDataDs.Update();
                //    _DBContext.SaveChanges();


                //}

                return null;
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    return ex.InnerException.Message;
                }
                else
                {
                    return ex.Message;
                }
            }
        }

        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTime = dateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dateTime;
        }


        public static int DBGet(string vVin)
        {
            try
            {
                //Use this part to directly connect to Database 

                //int result;
                //using (var _DBContext = new DBContext())
                //{

                //    result = _DBContext.DBAttribute1;

                //    if (result != null)
                //    {
                //        return result;
                //    }
                //    else
                //    {
                //        return 0;
                //    }

                //}
                return 0;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
    }
}
