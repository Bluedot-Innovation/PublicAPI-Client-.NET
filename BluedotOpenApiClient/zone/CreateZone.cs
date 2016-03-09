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
 * Add Zone client demonstrates adding a zone to an existing application
 */
namespace BluedotPublicApiClient.zoneclient
{

    public class CreateZone
    {
        private static String bdApplicationApiKey = "a46fc46a-63ac-4c0c-8a9c-3c9aafd88e46"; //This apiKey is generated when you create an application
        private static String bdCustomerApiKey    = "944ab370-7a0b-11e4-828c-a0481cdc3311"; //This key is generated by Bluedot Access UI when you register
        private static String bdRestUrl           = "https://api.bluedotinnovation.com/1/zones";

        public void create()
        {
            postToService(getJsonZone());
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

        /*Return JSON for a Zone. Time values have a format of HH:MM and the period value has to be one of {am/pm}*/
        private static String getJsonZone()
        {
            return "{" +
             "\"security\": {" +
                        "\"apiKey\":" + "\"" + bdApplicationApiKey + "\"," +
                        "\"customerApiKey\":" + "\"" + bdCustomerApiKey + "\"" +
            "}," +
           "\"content\": {" +
                 "\"zone\": {" +
                    "\"zoneName\": \"Congestion Zone\"," +
                    "\"minimumRetriggerTime\": \"00:01\"," +
                    "\"enableCheckOut\":true,"+
                    "\"timeActive\" : {" +
                        "\"from\": {" +
                            "\"time\": \"12:01\"," +
                            "\"period\": \"am\"" +
                        "}," +
                        "\"to\": {" +
                            "\"time\": \"11:59\"," +
                            "\"period\": \"pm\"" +
                        "}" +
                    "}" +
                "}" +
            "}" +
        "}";
       }
    }


}
