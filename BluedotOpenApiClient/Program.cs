using BluedotPublicApiClient.actionclient;
using BluedotPublicApiClient.applicationclient;
using BluedotPublicApiClient.beacon;
using BluedotPublicApiClient.checkinactivityclient;
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
 * Main program to execute the various client examples
 * If you don't have a customer api key then head to www.bluedotinnovation.com
 */

namespace BluedotPublicApiClient
{
    class Program
    {
        static void Main(string[] args)
        {

            /*Get a list of applications for a customer*/

            DeleteAction actionToDelete = new DeleteAction();
            //actionToDelete.delete();
            
            DeleteZone deleteZone = new DeleteZone();
            //deleteZone.delete();
            
            
            DeleteApplication apptoDelete = new DeleteApplication();
            //apptoDelete.delete();
            
            GetAllApplications appsClient = new GetAllApplications();
            //appsClient.getAllApplicationsForCustomer();
            
            /*Add an application to the Bluedot backend*/
            CreateApplication bdApplicationClient = new CreateApplication();
            //bdApplicationClient.create();
            
            /*Get a list of zone id and name for a given customer*/
            GetAllZones zones = new GetAllZones();
            //zones.getAllZonesForCustomer();

            /*Create a new zone*/
            CreateZone createZoneClient = new CreateZone();
            //createZoneClient.create();
           /*Create a new Beacon*/
           // BDCreateBeacon beaconClient = new BDCreateBeacon();
            //beaconClient.create();
            DeleteBeacon deleteBeaconClient = new DeleteBeacon();
            deleteBeaconClient.delete();
           // GetBeacons getbeaconsClient = new GetBeacons();
           // getbeaconsClient.getBeacons();
            //UpdateBeacon updatebeaconClient = new UpdateBeacon();
            //updatebeaconClient.update();

           /*Add beacon  to an existing zone*/
            //BDAddBeacontoZone beacontozoneClient = new BDAddBeacontoZone();
            //beacontozoneClient.create();


            /*Create a geo-fence to an existing zone*/
            //BDAddFenceClient fenceClient = new BDAddFenceClient();
            //fenceClient.addFence(); //Fence client has JSON for various shapes for your reference

            /*Update an existing geo-fence*/
            //BDUpdateFenceClient updateFenceClient = new BDUpdateFenceClient();
           // updateFenceClient.updateFence();


            CreateMessageAction messageActionClient = new CreateMessageAction();
            //messageActionClient.create();

            CreateURLAction urlActionClient = new CreateURLAction();
           // urlActionClient.create();

            CreateVibrationAction bdVibrationActionClient = new CreateVibrationAction();
          //  bdVibrationActionClient.create();

            CreateSoundAction bdSoundActionClient = new CreateSoundAction();
        //    bdSoundActionClient.create();

            /*Add conditions to actions*/
            CreateAllActionsWithAllConditions bdConditionsClient = new CreateAllActionsWithAllConditions();
      //      bdConditionsClient.addConditionsToMessageAction();


            CreateMessageActionWithConditions bdCreateMessageActionWithConditions = new CreateMessageActionWithConditions();
    //        bdCreateMessageActionWithConditions.createActionWithConditions();
            
            CreateApplicationActionWithConditions bdCreateApplicationActionWithConditions = new CreateApplicationActionWithConditions();
  //          bdCreateApplicationActionWithConditions.createActionWithConditions();

            CreateSoundActionWithConditions bdCreateSoundActionWithConditions = new CreateSoundActionWithConditions();
//            bdCreateSoundActionWithConditions.createActionWithConditions();

            CreateApplicationActionWithConditions bdCreateApplicationActionWithCondtions = new CreateApplicationActionWithConditions();
//            bdCreateApplicationActionWithCondtions.createActionWithConditions();

            CreateVibrationActionWithConditions bdCreateVibrationActionWithConditions = new CreateVibrationActionWithConditions();
            //bdCreateVibrationActionWithConditions.createActionWithConditions();

            CreateURLActionWithConditions bdCreateURLActionWithConditions = new CreateURLActionWithConditions();
            //bdCreateURLActionWithConditions.createActionWithConditions();


            /*Get Checkin activities*/
            GetCheckinActivities bdCheckinActivity = new GetCheckinActivities();
            //bdCheckinActivity.getAllCheckInActivitesByZone();
            //bdCheckinActivity.getCheckInActivitiesByZoneAndDateRange();

            /*Create a zone, fences, actions and conditions in one call*/
            FenceBulkLoader fenceBulkLoader = new FenceBulkLoader();
            //fenceBulkLoader.loadFences();


        }
    }
}
