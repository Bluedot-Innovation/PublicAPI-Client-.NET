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
* DeleteZone client demonstrates deleting an zone using the id provided, through http web api library
*/
namespace BluedotPublicApiClient.zoneclient
{
    class DeleteZone
    {

        public void delete()
        {
            String bdCustomerApiKey     = "835d9460-7b91-11e4-bcb7-a0481cdc3311"; //This is available on the Dashboard via edit profile tab
            String bdApplicationApiKey  = "d3161e80-38d1-11e4-b039-bc305bf60831"; //This apiKey is generated when you create an application
            String bdZoneId             = "0302e8d2-6618-410f-a577-3b0f14a6c79b"; //This can be extracted via the getAllZones api or the Web Dashboard
            String bdRestBaseUrl        = "https://api.bluedotinnovation.com/1/zone/delete?";

            String bdRestUrl        = bdRestBaseUrl + "customerApiKey=" + bdCustomerApiKey + "&apiKey=" + bdApplicationApiKey + "&zoneId=" + bdZoneId;
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
