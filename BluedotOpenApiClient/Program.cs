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

            /*Add an application to the Bluedot backend*/
            CreateApplication bdApplicationClient = new CreateApplication();
            bdApplicationClient.create();

            /*Create a new zone*/
            CreateZone bdCreateZoneClient = new CreateZone();
            bdCreateZoneClient.create();

            /*Create a new Beacon*/
            BDCreateBeacon bdBeaconClient = new BDCreateBeacon();
            bdBeaconClient.create();

            /*Add beacon to an existing zone*/
            BDAddBeacontoZone bdBeaconToZoneClient = new BDAddBeacontoZone();
            bdBeaconToZoneClient.create();

            /*Create a geo-fence to an existing zone*/
            BDAddFenceClient bdFenceClient = new BDAddFenceClient();
            bdFenceClient.addFence(); //Fence client has JSON for various shapes for your reference

            /*Add actions to an existing zone*/
            CreateMessageAction bdMessageActionClient = new CreateMessageAction();
            bdMessageActionClient.create();

            CreateURLAction bdUrlActionClient = new CreateURLAction();
            bdUrlActionClient.create();

            CreateVibrationAction bdVibrationActionClient = new CreateVibrationAction();
            bdVibrationActionClient.create();

            CreateSoundAction bdSoundActionClient = new CreateSoundAction();
            bdSoundActionClient.create();

            /*Add conditions to actions*/
            CreateAllActionsWithAllConditions bdConditionsClient = new CreateAllActionsWithAllConditions();
            bdConditionsClient.addConditionsToMessageAction();

            CreateMessageActionWithConditions bdCreateMessageActionWithConditions = new CreateMessageActionWithConditions();
            bdCreateMessageActionWithConditions.createActionWithConditions();

            CreateCustomActionWithConditions bdCreateCustomActionWithConditions = new CreateCustomActionWithConditions();
            bdCreateCustomActionWithConditions.createActionWithConditions();

            CreateSoundActionWithConditions bdCreateSoundActionWithConditions = new CreateSoundActionWithConditions();
            bdCreateSoundActionWithConditions.createActionWithConditions();

            CreateVibrationActionWithConditions bdCreateVibrationActionWithConditions = new CreateVibrationActionWithConditions();
            bdCreateVibrationActionWithConditions.createActionWithConditions();

            CreateURLActionWithConditions bdCreateURLActionWithConditions = new CreateURLActionWithConditions();
            bdCreateURLActionWithConditions.createActionWithConditions();
            
            /*Get a list of applications for a customer*/
            GetAllApplications bdAppsClient = new GetAllApplications();
            bdAppsClient.getAllApplicationsForCustomer();

            /*Get a list of zone id and name for a given customer*/
            GetAllZones bdGetZonesClient = new GetAllZones();
            bdGetZonesClient.getAllZonesForCustomer();

            /*Get Checkin activities*/
            GetCheckinActivities bdCheckinActivity = new GetCheckinActivities();
            bdCheckinActivity.getAllCheckInActivitesByZone();
            bdCheckinActivity.getCheckInActivitiesByZoneAndDateRange();

            /*Update an existing zone*/
            UpdateZone bdZoneUpdate = new UpdateZone();
            bdZoneUpdate.update();

            /*Update an existing beacone*/
            UpdateBeacon updatebeaconClient = new UpdateBeacon();
            updatebeaconClient.update();

            /*Update an existing geo-fence*/
            BDUpdateFenceClient updateFenceClient = new BDUpdateFenceClient();
            updateFenceClient.updateFence();

            /*Update an existing action*/
            DeleteAction actionToDelete = new DeleteAction();
            actionToDelete.delete();

            /*Update an existing beacon*/
            DeleteBeacon deleteBeaconClient = new DeleteBeacon();
            deleteBeaconClient.delete();

            /*Update an existing zone*/
            DeleteZone deleteZone = new DeleteZone();
            deleteZone.delete();

            /*Update an existing application*/
            DeleteApplication apptoDelete = new DeleteApplication();
            apptoDelete.delete();

        }
    }
}
