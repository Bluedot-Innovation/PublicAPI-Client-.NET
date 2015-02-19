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

/**
* @author Bluedot Innovation
* DeleteFence client demonstrates deleting a fence using the id provided, through http web api library
*/
namespace BluedotPublicApiClient.zoneclient
{
    class DeleteFence
    {
        public void delete()
        {
            String bdCustomerApiKey = "835d9460-7b91-11e4-bcb7-a0481cdc3311";
            String bdZoneId         = "3846fa1d-11f7-4044-8eab-0977f90d987e";
            String fenceId          = "fe6c357a-5273-4f95-8980-2e37ef2dc115";
            String bdRestBaseUrl    = "https://api.bluedotinnovation.com/1/fence/delete?";

            String bdRestUrl = bdRestBaseUrl + "customerApiKey=" + bdCustomerApiKey + "&zoneId=" + bdZoneId + "&fenceId=" + fenceId;
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
