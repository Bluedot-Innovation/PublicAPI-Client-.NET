﻿using System;
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
* Update beacon c# client demonstrates adding a beacon to to an existing the customer's account using net http web api library
* Pass beaconId of the beacon to update
*/

namespace BluedotPublicApiClient.beacon
{
    class UpdateBeacon
    {
        private static String bdApplicationApiKey = "45f087e0-245c-11e4-a968-bc305bf60831"; //This apiKey is generated when you create an application
        private static String bdCustomerApiKey    = "86577370-7b91-11e4-bcb7-a0481cdc3311"; //This key is generated by Bluedot Access UI when you register
        private static String bdBeaconId          = "977444dc-968a-4b13-84d8-4b194b794c18";
        private static String bdRestUrl           = "https://api.bluedotinnovation.com/1/beacons";

       public void update()
        {
            postToService(getJsonUpdatedBeacon());
        }
          private void postToService(String json)
        {
            HttpClient httpRestClient = new HttpClient();
            httpRestClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpContent jsonUpdateBeaconContent = new StringContent(json);
            jsonUpdateBeaconContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            HttpResponseMessage serverResponse = httpRestClient.PostAsync(new Uri(bdRestUrl), jsonUpdateBeaconContent).Result;
            if (serverResponse.IsSuccessStatusCode)
            {
                var result = serverResponse.Content.ReadAsStringAsync().Result;

                Console.WriteLine("{0}", result.ToString());
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)serverResponse.StatusCode, serverResponse.Content.ReadAsStringAsync().Result);
            }
        }

        /*JSON to create a beacon*/
        private static String getJsonUpdatedBeacon()
        {
          return "{" +
                 "\"security\": {" +
                 "\"apiKey\":" + "\"" + bdApplicationApiKey + "\"," +
                 "\"customerApiKey\":" + "\"" + bdCustomerApiKey + "\" " +
             "}," +
             "\"content\": {" +
                   "\"beacon\": {" +
                             "\"beaconId\":" + "\"" + bdBeaconId + "\" " +
                             "\"name\": \"Beacon-15-test2\"," +
                             "\"proximityUUID\": \"f7826da6-4fa2-4e98-8024-bc5b71e0893e\"," +
                             "\"longitude\": \"123.34455\"," +
                             "\"latitude\": \"47.777888\"," +
                             "\"major\": 12," +
                             "\"minor\": 14," +
                             "\"macAddress\":\"01:17:C5:31:84:21\"," +
                             "\"txPower\": -77," +
                             "\"description\": \"Sample description\"," +
                         "}" +
                  "}" +
          "}";

        }
    }
}