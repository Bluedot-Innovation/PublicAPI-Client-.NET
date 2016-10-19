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
 * Update Application client demonstrates updating an exsiting application to to an existing the customer's account using .net http web api library
 * Pass the applicationId of the application to be updated.
 */

namespace BluedotPublicApiClient.applicationclient
{
    public class UpdateApplicationWithWebhook
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
                              * This is returned when the application/getAll is called*/
                             "\"applicationId\":" + "\"" + bdApplicationId + "\"," + 
                             /* Time in Hour:Minute format.*/
                             "\"nextRuleUpdateIntervalFormatted\": \"00:10\"," +
                             "\"webhook\": {" +
                                /*The URL of the server where the webhooks will be received.*/
                                "\"url\": \"https://api.testapplication.com/webhook/checkinreceiver\"," +
                                "\"enabled\" : true," +
                                /*The Security Token Key is the name of the field to be sent in the POST request header.*/
                                "\"securityTokenKey\" : \"authToken\"," +
                                /*The Security Token Value field is value of the Security Token Key field sent in the POST request header.*/
                                "\"securityTokenValue\" : \"f2f7a58c-f0d5-498c-9bad-acbc89923dc5\"" +
                            "}" +
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
