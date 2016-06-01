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

/**
* @author Bluedot Innovation
* DeleteApplication client demonstrates deleting an application using the application id provided, through http web api library
*/
namespace BluedotPublicApiClient.applicationclient
{
    class DeleteApplication
    {
        public void delete()
        {
            String bdCustomerApiKey   = "835d9460-7b91-11e4-bcb7-a0481cdc3311";
            String bdApplicationId    = "d66d4f5d-7c09-4bd1-8549-48893f121";
            String bdRestBaseUrl      = "https://api.bluedotinnovation.com/1/application/delete?";

            String bdRestUrl = bdRestBaseUrl + "customerApiKey=" + bdCustomerApiKey + "&applicationId=" + bdApplicationId;
            HttpClient httpRestClient = new HttpClient();

            HttpResponseMessage serverResponse = httpRestClient.DeleteAsync(new Uri(bdRestUrl)).Result;
            if (serverResponse.IsSuccessStatusCode)
            {
                var result = serverResponse.Content.ReadAsStringAsync().Result;
                Console.WriteLine("{0}", result);
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)serverResponse.StatusCode, serverResponse.Content.ReadAsStringAsync().Result);
            }
        }
    }
}
