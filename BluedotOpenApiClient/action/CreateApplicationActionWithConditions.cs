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

/**
 * @author Bluedot Innovation
 * Create custom Action c# client demonstrates adding a Custom action with conditions to an existing the customer's zone using .net http web api library
 */

namespace BluedotPublicApiClient.actionclient
{
    public class CreateApplicationActionWithConditions
    {
        private static String bdCustomerApiKey    = "a6598740-75f5-11e4-86ca-a0481cdc3311"; //This key is generated by Bluedot Access UI when you register
        private static String bdApplicationApiKey = "db15b9b5-f2cf-405d-920d-0a65ea227c0c"; //This apiKey is generated when you create an application
        private static String bdZoneId            = "7022428f-c852-487d-a9bc-7029adbf7245"; //This is the id of the zone being updated. This can be fetched by calling zones/getAll API
        private static String bdRestUrl = "https://api.bluedotinnovation.com/1/actions";

        public void createActionWithConditions()
        {
            postToService(getJsonApplicationActionWithConditions());
        }


        private void postToService(String json)
        {
            HttpClient httpRestClient = new HttpClient();
            httpRestClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpContent jsonContent = new StringContent(json);
            jsonContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            HttpResponseMessage serverResponse = httpRestClient.PostAsync(new Uri(bdRestUrl), jsonContent).Result;
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



        private static String getJsonApplicationActionWithConditions()
        {
            String action =
            "{" +
            "\"security\": {" +
                 "\"apiKey\":" + "\"" + bdApplicationApiKey + "\"," +
                  "\"customerApiKey\":" + "\"" + bdCustomerApiKey + "\"" +
            "}," +
            "\"content\": {" +
                "\"zone\": {" +
                    "\"zoneId\":" + "\"" + bdZoneId + "\"," +
                    "\"actions\": {" +
                        "\"customActions\": [" +
                            "{" +
                                "\"name\" : \"A custom action providing a callback to the application\"," +
                                "\"conditions\": {" +
                                    "\"percentageCrossed\":" +
                                            "[" +
                                                "{" +
                                                    "\"percentage\": 100," +
                                                    "\"timeoutPeriod\": \"00:05\"" +
                                                "}" +
                                          "]" +                          
                                "}" +
                            "}" +
                        "]" +
                    "}" +
                "}" +
            "}" +
        "}";
            return action;
        }
    }
}
