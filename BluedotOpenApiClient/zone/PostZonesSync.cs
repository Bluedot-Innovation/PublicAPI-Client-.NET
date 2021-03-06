﻿using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;
using System.Security.Cryptography.X509Certificates;

/**
* @author Bluedot Innovation
* Copyright (c) 2016 Bluedot Innovation. All rights reserved.
* The Post Zones Sync client demonstrates how the zones/sync endpoint can be used to sync the newly created, updated or deleted zones to
* all mobile devices using your application.
*/
namespace BluedotPublicApiClient.zoneclient
{

    public class PostZonesSync
    {
        
        private void sync()
        {
            String bdCustomerApiKey      = "76e1ae30-c616-11e5-a7c0-b8ca3a6b879d"; //This key is generated by Bluedot Point Access UI when your account is created
            String bdApplicationApiKey   = "dee11930-ebff-11e5-8e27-bc305bf60831"; //This key is generated by Bluedot Access UI when you register
            String bdRestUrl             = "https://api.bluedotinnovation.com/1/zones/sync";

            String zonesSyncJson = "{" +
                "\"security\": {" +
                    "\"apiKey\":" + "\"" + bdApplicationApiKey + "\"," +
                    "\"customerApiKey\":" + "\"" + bdCustomerApiKey + "\"" +
                "}" +
            "}";

            WebRequestHandler handler = new WebRequestHandler();
            X509Certificate2 certificate = new X509Certificate2();
            handler.ClientCertificates.Add(certificate);
            HttpClient httpRestClient = new HttpClient(handler);

            //specify to use TLS 1.2 as default connection
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

            httpRestClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpContent jsonContent = new StringContent(zonesSyncJson);
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
    }
}