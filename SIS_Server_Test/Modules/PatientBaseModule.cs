using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy;
using SIS_Server_Test.ViewModels;
using Nancy.Responses;
using SIS_Server_Test.Utils;

namespace SIS_Server_Test.Modules
{
    public class PatientBaseModule : NancyModule
    {
        public PatientBaseModule()
            : base("api/patientshinchon")
        {
            Get["/"] = _ =>
            {
                return new JsonResponse(CreateViewModelForShinchon()
                    , new DefaultJsonSerializer { });
            };

            Get["/favorite"] = _ =>
            {
                return new JsonResponse(CreateViewModelForFavorite()
                    , new DefaultJsonSerializer { });
            };

            Get["/infinite"] = _ =>
            {
                return new JsonResponse(CreateViewModelForInfinite()
                    , new DefaultJsonSerializer { });
            };
        }

        internal ClientViewModel CreateViewModelForInfinite()
        {
            var ret = new ClientViewModel { MoreData = true, Href = this.Request.ToPublicSiteBase() + "api/patientshinchon/infinite" };
            ret.Details = new List<ClientViewModel>
            {
                 new ClientViewModel { ViewDisplayHeader="Infinite Scrolling1", ViewDisplayText=DateTime.Now.ToString(), ViewType="TableController" },
                 new ClientViewModel { ViewDisplayHeader="Infinite Scrolling2", ViewDisplayText=DateTime.Now.ToString(), ViewType="TableController" },
                 new ClientViewModel { ViewDisplayHeader="Infinite Scrolling3", ViewDisplayText=DateTime.Now.ToString(), ViewType="TableController" },
                 new ClientViewModel { ViewDisplayHeader="Infinite Scrolling4", ViewDisplayText=DateTime.Now.ToString(), ViewType="TableController" },
                 new ClientViewModel { ViewDisplayHeader="Infinite Scrolling5", ViewDisplayText=DateTime.Now.ToString(), ViewType="TableController" },
                 new ClientViewModel { ViewDisplayHeader="Infinite Scrolling6", ViewDisplayText=DateTime.Now.ToString(), ViewType="TableController" },
                 new ClientViewModel { ViewDisplayHeader="Infinite Scrolling7", ViewDisplayText=DateTime.Now.ToString(), ViewType="TableController" },
                 new ClientViewModel { ViewDisplayHeader="Infinite Scrolling8", ViewDisplayText=DateTime.Now.ToString(), ViewType="TableController" },
                 new ClientViewModel { ViewDisplayHeader="Infinite Scrolling9", ViewDisplayText=DateTime.Now.ToString(), ViewType="TableController" },
                 new ClientViewModel { ViewDisplayHeader="Infinite Scrolling10", ViewDisplayText=DateTime.Now.ToString(), ViewType="TableController" },
                 new ClientViewModel { ViewDisplayHeader="Infinite Scrolling11", ViewDisplayText=DateTime.Now.ToString(), ViewType="TableController" },
                 new ClientViewModel { ViewDisplayHeader="Infinite Scrolling12", ViewDisplayText=DateTime.Now.ToString(), ViewType="TableController" },
                 new ClientViewModel { ViewDisplayHeader="Infinite Scrolling13", ViewDisplayText=DateTime.Now.ToString(), ViewType="TableController" },
                 new ClientViewModel { ViewDisplayHeader="Infinite Scrolling14", ViewDisplayText=DateTime.Now.ToString(), ViewType="TableController" },
                 new ClientViewModel { ViewDisplayHeader="Infinite Scrolling15", ViewDisplayText=DateTime.Now.ToString(), ViewType="TableController" },
                 new ClientViewModel { ViewDisplayHeader="Infinite Scrolling16", ViewDisplayText=DateTime.Now.ToString(), ViewType="TableController" },
                 new ClientViewModel { ViewDisplayHeader="Infinite Scrolling17", ViewDisplayText=DateTime.Now.ToString(), ViewType="TableController" },
                 new ClientViewModel { ViewDisplayHeader="Infinite Scrolling18", ViewDisplayText=DateTime.Now.ToString(), ViewType="TableController" },
                 new ClientViewModel { ViewDisplayHeader="Infinite Scrolling19", ViewDisplayText=DateTime.Now.ToString(), ViewType="TableController" },
                 new ClientViewModel { ViewDisplayHeader="Infinite Scrolling20", ViewDisplayText=DateTime.Now.ToString(), ViewType="TableController" }
            };

            return ret;
        }

        internal ClientViewModel CreateViewModelForFavorite()
        {
            var ret = new ClientViewModel();
            ret.Details = new List<ClientViewModel>
        	{
        		new ClientViewModel { ViewDisplayHeader="Header", ViewDisplayText="Text", ViewType="WebController", Href="http://apple.com", 
        			Parameters = new List<ClientViewParameter>
        			{
        				new ClientViewParameter { ParameterKey="DirectCall", ParameterValue="True"}
        			}
        		},
                new ClientViewModel { ViewDisplayHeader="Infinite Scrolling", ViewDisplayText="Test", ViewType="TableController",
                    Href = this.Request.ToPublicSiteBase()  + "api/patientshinchon/infinite" },
                new ClientViewModel()
                {
                    ViewDisplayHeader = "GE PACS ( *BETA* )",
                    ViewType = "ExternalController",
                    Href = "crma://",
                    Parameters = new List<ClientViewParameter>
                    {
                        new ClientViewParameter
                         {
                            ParameterKey = "Install",
                            ParameterType = "hidden",
                            ParameterValue = "itms-apps://itunes.apple.com/us/app/centricity-radiology-mobile/id501936750?mt=8&uo=4",
                        },
                        new ClientViewParameter
                        {
                            ParameterKey = "InstallTitle",
                            ParameterType = "hidden",
                            ParameterValue = "Install GE App",
                        },
                        new ClientViewParameter
                        {
                            ParameterKey = "InstallMsg",
                            ParameterType = "hidden",
                            ParameterValue = "Need to Install GE Mobile PACS App",
                        }
                    }
                }
        	};

            return ret;
        }

        internal ClientViewModel CreateViewModelForShinchon()
        {
            var ret = CreateViewModel();
            ret.ViewDisplayText = "Shinchon";

            return ret;
        }

        internal ClientViewModel CreateViewModel()
        {
            var ret = new ClientViewModel()
            {
                NewWindow = true,
                ViewDisplayHeader = "Patient Search",
                ViewType = "TabController",
                //ViewImagePlaceHolder = "Patients.png",
                //ViewImagePlaceHolderText = "\uf0f0",
            };

            var dtl01 = new ClientViewModel()
            {
                ViewDisplayText = "My Patients",
                ViewType = "TableController",
                ViewImagePlaceHolder = "favorite_icon.png",
                ViewImagePlaceHolderText = "\uf005",
                Href = this.Request.ToPublicUrl() + "/favorite"
            };
            ret.Details.Add(dtl01);

            return ret;
        }
    }
}