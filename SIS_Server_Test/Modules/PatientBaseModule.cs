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

            Get["/infinite/{value:int}"] = _ =>
            {
                int value = _.value;
                return new JsonResponse(CreateViewModelForInfinite(value)
                    , new DefaultJsonSerializer { });
            };

            Get["/image"] = _ =>
            {
                return new JsonResponse(CreateViewModelForImage()
                    , new DefaultJsonSerializer { });
            };
        }

        internal ClientViewModel CreateViewModelForImage()
        {
            var ret = new ClientViewModel();
            ret.Details.Add(new ClientViewModel { ViewImageHref = "https://cloud.githubusercontent.com/assets/72919/5170445/b7956c46-73c4-11e4-9874-36b6f5f94fab.jpg" });
            ret.Details.Add(new ClientViewModel { ViewImageHref = "https://cloud.githubusercontent.com/assets/72919/5170397/3b7c54c6-73c4-11e4-9fa7-305e8f655685.jpg" });
            ret.Details.Add(new ClientViewModel { ViewImageHref = "http://nancyfx.org/images/logo.png" });

            return ret;
        }

        internal ClientViewModel CreateViewModelForInfinite(int value)
        {
            var ret = new ClientViewModel { MoreData = value < 99, Href = this.Request.ToPublicSiteBase() + "api/patientshinchon/infinite/" + (value + 20) };
            if (ret.MoreData)
            {
                for (int i = 0; i < 20; i++)
                {
                    ret.Details.Add(new ClientViewModel { ViewDisplayHeader = "Infinite Scrolling " + value++, ViewDisplayText = DateTime.Now.ToString(), ViewType = "TableController" });
                }
            }
 
            return ret;
        }

        internal ClientViewModel CreateViewModelForFavorite()
        {
            var ret = new ClientViewModel();
            ret.Details = new List<ClientViewModel>
        	{
        		new ClientViewModel { ViewDisplayHeader="WebController", ViewDisplayText="direct webpage", ViewType="WebController", Href="http://apple.com", 
        			Parameters = new List<ClientViewParameter>
        			{
        				new ClientViewParameter { ParameterKey="DirectCall", ParameterValue="True"}
        			}
        		},
                new ClientViewModel { ViewDisplayHeader="TableController", ViewDisplayText="infinite scrolling", ViewType="TableController",
                    Href = this.Request.ToPublicSiteBase()  + "api/patientshinchon/infinite/0" },
                new ClientViewModel { ViewDisplayHeader="ImageController", ViewDisplayText="infinite scrolling", ViewType="ImageController",
                    Href = this.Request.ToPublicSiteBase()  + "api/patientshinchon/image" },
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