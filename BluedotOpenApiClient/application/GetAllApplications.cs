using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;

/**
 * @author Bluedot Innovation
 * Copyright (c) 2016 Bluedot Innovation. All rights reserved.
 * Get All Applications client demonstrates listing for all applications for a given customer.
 */
namespace BluedotPublicApiClient.applicationclient
{
    public class GetAllApplications
    {
        private static String customerApiKey = "ca4c8d11-6942-11e4-ba4b-a0481cdc3311";
        private static String bdRestUrl      = "https://api.bluedotinnovation.com/1/applications?customerApiKey=" + customerApiKey;

        public void getAllApplicationsForCustomer()
        {
            HttpClient httpRestClient = new HttpClient();

            HttpResponseMessage serverResponse = httpRestClient.GetAsync(new Uri(bdRestUrl)).Result;
            if (serverResponse.IsSuccessStatusCode)
            {
                var result = serverResponse.Content.ReadAsStringAsync().Result;

                JavaScriptSerializer serializer = new JavaScriptSerializer();
                dynamic applications = serializer.Deserialize(result, typeof(object)); // Result is an array of json
                foreach (var application in applications)
                {
                    Console.WriteLine("_id : {0} ", application["_id"]);
                    Console.WriteLine("apiKey : {0} ", application["apiKey"]);
                    Console.WriteLine("name : {0} ", application["name"]);
                    Console.WriteLine("---------\n");
                }
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)serverResponse.StatusCode, serverResponse.Content.ReadAsStringAsync().Result);
            }
        }
    }
}
