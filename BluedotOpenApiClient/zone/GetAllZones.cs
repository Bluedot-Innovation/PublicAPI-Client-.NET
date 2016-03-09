﻿using System;
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
 * Get zones client demonstrates the listing of zone names and ids for a given customer
 */

namespace BluedotPublicApiClient.zoneclient
{
    public class GetAllZones
    {
        private static String bdApplicationApiKey = "a3ca63ba-2bd4-4f25-ae89-07fd70477c67"; //This apiKey is generated when you create an application
        private static String bdCustomerApiKey    = "55b26d80-7450-11e4-9c47-a0481cdc3311"; //This key is generated by Bluedot Access UI when you register
        private static String bdRestUrl = "https://api.bluedotinnovation.com/1/zones/getAll?customerApiKey=" + bdCustomerApiKey + "&apiKey=" + bdApplicationApiKey + "&pageNumber=0";

        
        public void getAllZonesForCustomer()
        {
            HttpClient httpRestClient = new HttpClient();

            HttpResponseMessage serverResponse = httpRestClient.GetAsync(new Uri(bdRestUrl)).Result;
            if (serverResponse.IsSuccessStatusCode)
            {
                var result = serverResponse.Content.ReadAsStringAsync().Result;

                JavaScriptSerializer serializer = new JavaScriptSerializer();
                dynamic zoneRecords             = serializer.Deserialize(result, typeof(object)); // Result is an array of json
                foreach (var zoneRecord in zoneRecords)
                {
                    Console.WriteLine("_id : {0} ", zoneRecord["_id"]);
                    Console.WriteLine("name : {0} ", zoneRecord["name"]);
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
