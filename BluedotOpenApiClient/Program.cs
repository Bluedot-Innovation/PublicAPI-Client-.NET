using BluedotPublicApiClient.zoneclient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

/**
 * @author Bluedot Innovation
 * Main program to execute the various client examples. 
 * Here examples of creating, updating, fetching and deleting zones have been provided.
 * If you don't have a customer api key then head to www.bluedotinnovation.com
 */

namespace BluedotPublicApiClient 
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Create a new zone*/
            CreateCompleteZone bdCreateCompleteZoneClient = new CreateCompleteZone();
            bdCreateCompleteZoneClient.createCompleteZoneActiveAllDay();

            /*Get a list of zone id and name for a given customer*/
            GetAllZones bdGetZonesClient = new GetAllZones();
            bdGetZonesClient.getAllZonesForCustomer();

            /*Update an existing zone*/
            UpdateZone bdZoneUpdate = new UpdateZone();
            bdZoneUpdate.update();

            /*Update an existing zone*/
            DeleteZone deleteZone = new DeleteZone();
            deleteZone.delete();

        }
    }
}
