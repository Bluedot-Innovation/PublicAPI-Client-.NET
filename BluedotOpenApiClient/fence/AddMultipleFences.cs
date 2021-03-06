﻿using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Security.Cryptography.X509Certificates;

/**
* @author Bluedot Innovation
* Copyright (c) 2016 Bluedot Innovation. All rights reserved.
* Add fence Public API client demonstrates adding fences of various shapes in a single JSON request to an existing zone using net http web api library
*/

namespace BluedotPublicApiClient.fenceclient
{
    public class BDAddMultipleFencesClient
    {
        private static String bdCustomerApiKey = "bc199c80-5441-11e4-b7bb-a0481cdc3311"; //This key is generated by Bluedot Point Access UI when your account is created
        private static String bdApplicationApiKey = "d3161e80-38d1-11e4-b039-bc305bf60831"; //This apiKey is generated when you create an application
        private static String bdZoneId = "24d9a245-2087-421b-9972-2af2ee0970f1"; //This is the id of the zone being updated. This can be fetched by calling zones/getAll API
        private static String bdRestUrl = "https://api.bluedotinnovation.com/1/fences";

        public void addFence()
        {
            WebRequestHandler handler = new WebRequestHandler();
            X509Certificate2 certificate = new X509Certificate2();
            handler.ClientCertificates.Add(certificate);
            HttpClient httpRestClient = new HttpClient(handler);

            //specify to use TLS 1.2 as default connection
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

            httpRestClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpContent jsonFenceContent = new StringContent(getJsonMultipleFence());
            jsonFenceContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            HttpResponseMessage serverResponse = httpRestClient.PostAsync(new Uri(bdRestUrl), jsonFenceContent).Result;
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


        /*This Json contains an example of all the different fence geometry types*/
        private static String getJsonMultipleFence()
        {
            String multipleFenceJson =
            "{" +
                "\"security\": {" +
                 "\"apiKey\":" + "\"" + bdApplicationApiKey + "\"," +
                 "\"customerApiKey\":" + "\"" + bdCustomerApiKey + "\" " +
             "}," +
             "\"content\": {" +
                 "\"zone\": {" +
                     "\"zoneId\":" + "\"" + bdZoneId + "\"," +
                     "\"fences\": {" +
                         "\"circles\": [" +
                             "{" +
                                 "\"order\": 1," +
                                 "\"name\": \"Circular fence-added through API 01\"," +
                                 "\"color\": \"#000fff\"," +
                                 "\"radius\": 20.235," +
                                 "\"center\": {" +
                                     "\"latitude\": \"-37.818326\"," +
                                     "\"longitude\": \"144.979318\" " +
                                 "}" +
                             "}," +
                             "{" +
                                 "\"order\": 2," +
                                 "\"name\": \"Circular fence-added through API 02\"," +
                                 "\"color\": \"#000fff\"," +
                                 "\"radius\": 30," +
                                 "\"center\": {" +
                                     "\"latitude\": \"37.8164587537386\"," +
                                     "\"longitude\": \"144.978997707366\" " +
                                 "}" +
                             "}" +
                         "]," +
                         "\"rectangles\": [" +
                            "{" +
                                "\"order\": 3," +
                                "\"name\": \"Bounding Box-1\"," +
                                "\"color\": \"#3559ef\"," +
                                "\"northEast\": {" +
                                    "\"latitude\": -37.81544591805361," +
                                    "\"longitude\": 144.9786114692688" +
                                "}," +
                                "\"southWest\": {" +
                                    "\"latitude\": -37.81758175613945," +
                                    "\"longitude\": 144.9731397628784" +
                                "}" +
                            "}" +
                        "]," +
                        "\"polygons\": [" +
                            "{" +
                                "\"order\": 4," +
                                "\"name\": \"Polygon-2\"," +
                                "\"color\": \"#000fff\"," +
                                "\"vertices\": [" +
                                     "{" +
                                         "\"latitude\": -37.818717," +
                                         "\"longitude\": 144.983085" +
                                     "}," +
                                     "{" +
                                        "\"latitude\": -37.819540," +
                                        "\"longitude\": 144.982125" +
                                     "}," +
                                     "{" +
                                        "\"latitude\": -37.820298," +
                                        "\"longitude\": 144.985178" +
                                     "}," +
                                     "{" +
                                        "\"latitude\": -37.820468," +
                                        "\"longitude\": 144.984228" +
                                     "}" +
                                "]" +
                            "}" +
                        "]," +
                        "\"polylines\": [" +
                        "{" +
                            "\"order\": 5," +
                            "\"name\": \"Geoline-1\"," +
                            "\"color\": \"#000fff\"," +
                            "\"vertices\": [" +
                                 "{" +
                                    "\"latitude\": -37.819540," +
                                    "\"longitude\": 144.982125" +
                                 "}," +
                                 "{" +
                                    "\"latitude\": -37.820298," +
                                    "\"longitude\": 144.985178" +
                                 "}" +
                            "]" +
                        "}" +
                    "]" +
                     "}" +
                 "}" +
             "}" +
            "}";
            return multipleFenceJson;
        }
    }
}