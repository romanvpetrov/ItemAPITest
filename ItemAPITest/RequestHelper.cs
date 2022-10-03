using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ItemAPITest
{
    public class RequestHelper
    {
        public static string getAllRequest()
        {
            string url = "https://1ryu4whyek.execute-api.us-west-2.amazonaws.com/dev/skus/";

            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            string jsonValue = "";
            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                StreamReader reader = new StreamReader(response.GetResponseStream());
                jsonValue = reader.ReadToEnd();
            }

            return jsonValue;
        }

        public static string getRequest(string sku)
        {
            string url = "https://1ryu4whyek.execute-api.us-west-2.amazonaws.com/dev/skus/" + sku;

            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            string jsonValue = "";
            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                StreamReader reader = new StreamReader(response.GetResponseStream());
                jsonValue = reader.ReadToEnd();
            }

            return jsonValue;
        }

        public static string deleteRequest(string sku)
        {
            string url = "https://1ryu4whyek.execute-api.us-west-2.amazonaws.com/dev/skus/" + sku;

            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            request.Method = "DELETE";
            string jsonValue = "";
            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                StreamReader reader = new StreamReader(response.GetResponseStream());
                jsonValue = reader.ReadToEnd();
            }

            return jsonValue;
        }

        public static string postRequest(Item item)
        {
            string url = "https://1ryu4whyek.execute-api.us-west-2.amazonaws.com/dev/skus";

            var httpWebRequest = WebRequest.CreateHttp(url);
            httpWebRequest.ContentType = "application/json; charset=utf-8";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = "{ \"sku\" : \"" + item.sku + "\", \"description\" : \"" + item.description + "\", \"price\" : \"" + item.price + "\" }";
                //string json = JsonConvert.SerializeObject(item);

                streamWriter.Write(json);
                streamWriter.Flush();
            }
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var responseText = streamReader.ReadToEnd();
                return responseText;
            }
        }
    }
}
