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

namespace BluedotPublicApiClient.actionclient
{
    public class CreateVibrationActionWithConditions
    {
        private static String bdCustomerApiKey    = "a6598740-75f5-11e4-86ca-a0481cdc3311"; //This key is generated by Bluedot Access UI when you register
        private static String bdApplicationApiKey = "01f0c102-785b-45e0-a147-f07cdf75dfac"; //This apiKey is generated when you create an application
        private static String bdRestUrl           = "https://api.bluedotinnovation.com/1/actions";
        private static String bdZoneId            = "94423938-5740-45f9-9bd4-9faab7293162"; //This is the id of the zone being updated. This can be fetched by calling zones/getAll API

        public void createActionWithConditions()
        {
            postToService(getJsonVibrationActionWithConditions());
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

        private static String getJsonVibrationActionWithConditions()
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
                        "\"vibrationActions\": [" +
                            "{" +
                                "\"name\" : \"A vibration action\"," +
                                "\"conditions\": {" +
                                   "\"timeActive\": [{" +
                                            "\"from\": {" +
                                                "\"time\": \"09:00\"," +
                                                "\"period\": \"am\" " +
                                            "}," +
                                            "\"to\": {" +
                                                "\"time\": \"05:00\"," +
                                                "\"period\": \"pm\" " +
                                            "}" +
                                        "}]" +
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
