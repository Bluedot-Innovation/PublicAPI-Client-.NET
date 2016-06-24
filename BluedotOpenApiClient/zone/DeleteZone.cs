using System;
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
* DeleteZone client demonstrates deleting an zone using the id provided, through http web api library
*/
namespace BluedotPublicApiClient.zoneclient
{
    class DeleteZone
    {
        public void delete()
        {
            String bdCustomerApiKey     = "76e1ae30-c616-11e5-a7c0-b8ca3a6b879d"; //This is available on the Dashboard via edit profile tab
            String bdApplicationApiKey  = "dee11930-ebff-11e5-8e27-bc305bf60831"; //This apiKey is generated when you create an application
            String bdZoneId             = "720f2f5d-7057-4668-a546-542abc4f2128"; //This can be extracted via the GET Zones api or the Web Dashboard
            String bdRestBaseUrl        = "https://api.bluedotinnovation.com/1/zones?";

            String bdRestUrl        = bdRestBaseUrl + "customerApiKey=" + bdCustomerApiKey + "&apiKey=" + bdApplicationApiKey + "&zoneId=" + bdZoneId;
            WebRequestHandler handler = new WebRequestHandler();
            X509Certificate2 certificate = new X509Certificate2();
            handler.ClientCertificates.Add(certificate);
            HttpClient httpRestClient = new HttpClient(handler);

            //specify to use TLS 1.2 as default connection
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

            HttpResponseMessage serverResponse = httpRestClient.DeleteAsync(new Uri(bdRestUrl)).Result;
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
