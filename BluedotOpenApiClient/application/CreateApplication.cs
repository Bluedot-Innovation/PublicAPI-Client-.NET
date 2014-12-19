using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Net;
using System.Web.Script.Serialization;
using System.IO;
using System.Threading.Tasks;

namespace BluedotPublicApiClient.applicationclient
{
    public class CreateApplication
    {
        public void create()
        {
            String bdCustomerApiKey = "73ad7b80-7c4e-11e4-a2d3-b8ca3a6b879d";
            String bdRestUrl = "http://bdapplication4.cloudapp.net:3033/1/applications";

            String application =
               "{" +
                 "\"security\": {" +
                          /*
                                customerApiKey is generated when customer registers first time. It is also available
                               on the PointAccess interface in the Edit Profile section.
                          */
                         "\"customerApiKey\":" + "\"" + bdCustomerApiKey + "\"" +
               "}," +
               "\"content\": { " +
                   "\"application\" : {" +
                            "\"name\" : \"A Bluedot Application\"," +
                            "\"packageName\": \"com.bluedotinnovation.testapplication\"," +
                            /* Time in Hour:Minute format.*/
                             "\"nextRuleUpdateIntervalFormatted\": \"00:07\"" +
                        "}" +
                   "}" +
             "}";


            
            /*Or hand build json using key value pair
            JavaScriptSerializer js = new JavaScriptSerializer();
            var securityDictionary = new Dictionary<string, string>
            {
                {"customerApiKey", bdCustomerApiKey},
            };

            var applicationContentDictionary = new Dictionary<string, string>
               {
                   { "security", js.Serialize(securityDictionary)}
               };
          
            string application = js.Serialize(applicationContentDictionary);
            */

            HttpClient httpRestClient = new HttpClient();
            httpRestClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpContent jsonApplicationContent         = new StringContent(@application);
            jsonApplicationContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            HttpResponseMessage serverResponse         = httpRestClient.PostAsync(new Uri(bdRestUrl), jsonApplicationContent).Result;
            if (serverResponse.IsSuccessStatusCode)
            {
                var result = serverResponse.Content.ReadAsStringAsync().Result;
                Console.WriteLine("{0}", result);
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int) serverResponse.StatusCode, serverResponse.Content.ReadAsStringAsync().Result);
            }

        }
    }


}
