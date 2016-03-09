using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

/**
 * @author Bluedot Innovation
 * Get Applications java client demonstrates listing or all applications for a given customer.
 */
namespace BluedotPublicApiClient.applicationclient
{
    public class GetAllApplications
    {
        private static String apiKey         = "b817bb5d-4b58-4f41-be5f-528fd4c7c95c";
        private static String customerApiKey = "ca4c8d11-6942-11e4-ba4b-a0481cdc3311";
        String bdRestUrl                     = "https://api.bluedotinnovation.com/1/application/getAll?customerApiKey=" + customerApiKey + "&apiKey=" + apiKey 

        public void getAllApplicationsForCustomer()
        {
            HttpClient httpRestClient = new HttpClient();

            HttpResponseMessage serverResponse = httpRestClient.GetAsync(new Uri(bdRestUrl)).Result;
            if (serverResponse.IsSuccessStatusCode)
            {
                var result = serverResponse.Content.ReadAsStringAsync().Result;

                JavaScriptSerializer serializer = new JavaScriptSerializer();
                dynamic applications = serializer.Deserialize(result, typeof(object)); // Result is an array of json
                foreach (var application in applications)
                {
                    Console.WriteLine("_id : {0} ", application["_id"]);
                    Console.WriteLine("apiKey : {0} ", application["apiKey"]);
                    Console.WriteLine("name : {0} ", application["name"]);
                    Console.WriteLine("---------\n");
                }
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)serverResponse.StatusCode, serverResponse.Content.ReadAsStringAsync().Result);
            }
        }
    }
}
