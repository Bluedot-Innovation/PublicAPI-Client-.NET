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
* Add fence c# client demonstrates updating existing geo fences within a zone using net http web api library
* Circular fence
* Bounding Box
* Polygonal
*/

namespace BluedotPublicApiClient.zoneclient
{
    public class BDUpdateFenceClient
    {

        private static String bdCustomerApiKey     = "bc199c80-5441-11e4-b7bb-a0481cdc3311"; //This key is generated by Bluedot Access UI when you register
        private static String bdApplicationApiKey  = "d3161e80-38d1-11e4-b039-bc305bf60831"; //This apiKey is generated when you create an application
        private static String bdRestUrl            = "http://bdapplication4.cloudapp.net:3000/1/fence/update";
        private static String bdZoneId             = "24d9a245-2087-421b-9972-2af2ee0970f1"; //This is the id of the zone being updated. This can be fetched by calling zones/getAll API
        private static String bdCircularFenceId    = "b4024ed6-7a28-4335-ba51-45df58459e17"; //This is the id of the fence being updated. This can be fetched by calling zones/get API
        private static String bdBoundingBoxFenceId = "b4024ed6-7a28-4335-ba51-45df58459e17"; //This is the id of the fence being updated. This can be fetched by calling zones/get API
        private static String bdPolygonalFenceId   = "b4024ed6-7a28-4335-ba51-45df58459e17"; //This is the id of the fence being updated. This can be fetched by calling zones/get API
        
        public void updateFence()
        {
            HttpClient httpRestClient = new HttpClient();
            httpRestClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpContent jsonFenceContent         = new StringContent(getJsonCircularFence());
            jsonFenceContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            HttpResponseMessage serverResponse   = httpRestClient.PostAsync(new Uri(bdRestUrl), jsonFenceContent).Result;
            if (serverResponse.IsSuccessStatusCode)
            {
                var result = serverResponse.Content.ReadAsStringAsync().Result;

                Console.WriteLine("{0}", result);

            }
            else
            {
                Console.WriteLine("{0} ({1})", (int) serverResponse.StatusCode, serverResponse.Content.ReadAsStringAsync().Result);
            }
        }

        /*Circular fence requires a centerpoint and radius*/
        private static String getJsonCircularFence()
        {
            String circularFenceJson =
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
                                 "\"fenceId\":" + "\"" + bdCircularFenceId + "\"," +
                                 "\"name\": \"Circular fence-added by Emil and Updated through public api\"," +
                                 "\"color\": \"#000ffff\"," +
                                 "\"radius\": \"10.330384237225\"," +
                                 "\"center\": {" +
                                     "\"latitude\": \"-37.818326\"," +
                                     "\"longitude\": \"144.979318\" " +
                                 "}" +
                             "}" +
                         "]" +
                     "}" +
                 "}" +
             "}" +
          "}";
            return circularFenceJson;
        }

        /*Bounding box requires north east and south west points*/
        private static String getJsonBoundingBox()
        {
            String boundingBoxFenceJson =
                    "{" +
                       "\"security\": {" +
                            "\"apiKey\":" + "\"" + bdApplicationApiKey + "\"," +
                            "\"customerApiKey\":" + "\"" + bdCustomerApiKey + "\" " +
                    "}," +
                    "\"content\": {" +
                        "\"zone\": {" +
                            "\"zoneId\":" + "\"" + bdZoneId + "\"," +
                         "\"fences\": {" +
                            "\"rectangles\": [" +
                                "{" +
                                   "\"fenceId\":" + "\"" + bdBoundingBoxFenceId + "\"," +
                                    "\"name\": \"Bounding Box-1\"," +
                                    "\"color\": \"#3559e\"," +
                                    "\"northEast\": {" +
                                        "\"latitude\": -37.81544591805361," +
                                        "\"longitude\": 144.9786114692688" +
                                    "}," +
                                    "\"southWest\": {" +
                                        "\"latitude\": -37.81758175613945," +
                                        "\"longitude\": 144.9731397628784" +
                                    "}" +
                                "}" +
                            "]" +
                        "}" +
                    "}" +
                 "}" +
               "}";
            return boundingBoxFenceJson;
        }

        /*Polygonal fence requires a series points in lat/long*/
        private static String getJsonPolygonalFence()
        {
            String polygonalFenceJson =
                           "{" +
                               "\"security\": {" +
                                   "\"apiKey\":" + "\"" + bdApplicationApiKey + "\"," +
                                   "\"customerApiKey\":" + "\"" + bdCustomerApiKey + "\" " +
                            "}," +
                            "\"content\": {" +
                                "\"zone\": {" +
                                    "\"zoneId\":" + "\"" + bdZoneId + "\"," +
                                    "\"fences\": {" +
                                    "\"polygons\": [" +
                                        "{" +
                                            "\"name\": \"Polygon-2\"," +
                                            "\"color\": \"#000ffff\"," +
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
                                                 "}," +
                                                 "{" +
                                                    "\"latitude\": -37.818768," +
                                                    "\"longitude\": 144.984330" +
                                                 "}," +
                                                 "{" +
                                                    "\"latitude\": -37.819476," +
                                                    "\"longitude\": 144.985033" +
                                                 "}," +
                                                 "{" +
                                                    "\"latitude\": -37.820527," +
                                                    "\"longitude\": 144.982978" +
                                                 "}," +
                                                 "{" +
                                                    "\"latitude\": -37.818887," +
                                                    "\"longitude\": 144.982587" +
                                                 "}" +
                                            "]" +
                                        "}" +
                                    "]" +
                                "}" +
                            "}" +
                         "}" +
                    "}";

            return polygonalFenceJson;
        }
    }
}