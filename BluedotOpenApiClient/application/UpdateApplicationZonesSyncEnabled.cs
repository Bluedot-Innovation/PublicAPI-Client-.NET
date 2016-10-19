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
using System.Security.Cryptography.X509Certificates;

/**
 * @author Bluedot Innovation
 * Copyright (c) 2016 Bluedot Innovation. All rights reserved.
 * Update Application with Zones Sync enabled client demonstrates updating an existing application to to an existing the customer's account
 * using .net http web api library for which the zones sync will be available using Firebase push.
 * Pass the applicationId of the application to be updated.
 */

namespace BluedotPublicApiClient.applicationclient
{
    public class UpdateApplication
    {
        public void update()
        {
            String bdCustomerApiKey = "73ad7b80-7c4e-11e4-a2d3-b8ca3a6b879d"; //This key is generated by Bluedot Point Access UI when your account is created
            String bdApplicationId  = "564ecdc0-7e86-11e4-95ff-a0481cdba490"; //This ID is retrieved through the GET Applications call
            String bdRestUrl        = "https://api.bluedotinnovation.com/1/applications";

            String application =
               "{" +
                 "\"security\": {" +
                     /*
                      customerApiKey is generated when customer registers first time. It is also available
                      on the PointAccess interface in the Edit Profile section.
                     */
                     "\"customerApiKey\":" + "\"" + bdCustomerApiKey + "\"" +
               "}," +
               "\"content\": { " +
                   "\"application\" : {" +
                        /*This is the id of the application as opposed to the api key. 
                         * This is returned when the application/getAll is called.*/
                        "\"applicationId\":" + "\"" + bdApplicationId + "\"," + 
                        /* Time in Hour:Minute format.*/
                        "\"nextRuleUpdateIntervalFormatted\": \"00:10\"," +
                        /*The Web API key from Firebase project settings. 
                        * Using this key our backend will be able to communicate with Firebase to deliver the 
                        * zones that need to be synced to your application.*/
                        "\"firebaseApiKey\": \"gDZyt1Bj_Y6S8BKyQfKH6uZ9wc475hrRlGA_6lS\"" +
                   "}" +
                "}" +
             "}";

            WebRequestHandler handler = new WebRequestHandler();
            X509Certificate2 certificate = new X509Certificate2();
            handler.ClientCertificates.Add(certificate);
            HttpClient httpRestClient = new HttpClient(handler);

            //specify to use TLS 1.2 as default connection
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

            httpRestClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpContent jsonApplicationContent = new StringContent(@application);
            jsonApplicationContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            HttpResponseMessage serverResponse = httpRestClient.PostAsync(new Uri(bdRestUrl), jsonApplicationContent).Result;
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
