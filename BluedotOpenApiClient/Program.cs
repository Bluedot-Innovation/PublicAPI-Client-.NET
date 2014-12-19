using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using BluedotPublicApiClient.applicationclient;
using BluedotPublicApiClient.zoneclient;
using BluedotPublicApiClient.checkinactivityclient;

/**
 * @author Bluedot Innovation
 * Add application java client demonstrates adding an application to your Bluedot backend using Web Api.
 */

namespace BluedotPublicApiClient
{
    class Program
    {
        static void Main(string[] args)
        {
            FenceBulkLoader fenceBulkLoader = new FenceBulkLoader();
            //fenceBulkLoader.loadFences();


            /*Add an application to the Bluedot backend*/
            CreateApplication bdApplicationClient = new CreateApplication();
            bdApplicationClient.create();

            /*Get a list of zone id and name for a given customer*/
            GetAllZones zones = new GetAllZones();
            //zones.getAllZonesForCustomer();

            CreateZone addZone = new CreateZone();
            //addZone.add();
            
            //GetAllApplications apps = new GetAllApplications();

            //apps.getAllApplicationsForCustomer();
            

            /*Add a fence to an existing zone*/
             BDAddFenceClient fenceClient = new BDAddFenceClient();
             fenceClient.addFence(); //Fence client has JSON for various shapes for your reference

            //BDUpdateFenceClient updateFenceClient = new BDUpdateFenceClient();
            //updateFenceClient.updateFence();

            /*Add actions to an existing zone*/
            CreateAllActions actionClient = new CreateAllActions();
            //actionClient.addApplicationAction();
            //actionClient.addMessageAction();
            //actionClient.addSoundAction();
            //actionClient.addURLAction();

            CreateMessageAction addMessageAction = new CreateMessageAction();
            addMessageAction.add();

            CreateURLAction urlAction = new CreateURLAction();
            //urlAction.add();

            CreateVibrationAction bdVibrationAction = new CreateVibrationAction();
            bdVibrationAction.add();

            CreateSoundAction bdAddSoundAction = new CreateSoundAction();
           bdAddSoundAction.add();

            /*Add conditions to actions*/
            CreateAllActionsWithAllConditions bdConditionsClient = new CreateAllActionsWithAllConditions();
            //bdConditionsClient.addConditionsToMessageAction();


            CreateMessageActionWithConditions bdAddMessageActionWithConditions = new CreateMessageActionWithConditions();
            //bdAddMessageActionWithConditions.addActionWithConditions();
            
            CreateApplicationActionWithConditions bdApplicationActionWithConditions = new CreateApplicationActionWithConditions();
            //bdApplicationActionWithConditions.addActionWithConditions();

            //bdConditionsClient.addConditionsToVibrationAction();

            CreateSoundActionWithConditions bdAddSoundActionWithConditions = new CreateSoundActionWithConditions();
            //bdAddSoundActionWithConditions.addActionWithConditions();

            CreateApplicationActionWithConditions bdApplicationActionWithCondtions = new CreateApplicationActionWithConditions();
            //bdApplicationActionWithCondtions.addActionWithConditions();

            CreateVibrationActionWithConditions bdVibrationActionWithConditions = new CreateVibrationActionWithConditions();
            //bdVibrationActionWithConditions.addActionWithConditions();

            CreateURLActionWithConditions bdURLActionWithConditions = new CreateURLActionWithConditions();
            //bdURLActionWithConditions.addActionWithConditions();
            /*Get Checkin activities*/
            GetCheckinActivities bdCheckinActivity = new GetCheckinActivities();
            //bdCheckinActivity.getAllCheckInActivitesByZone();
            //bdCheckinActivity.getCheckInActivitiesByZoneAndDateRange();

            /*Create a zone, fences, actions and conditions in one call*/

        }
    }
}
