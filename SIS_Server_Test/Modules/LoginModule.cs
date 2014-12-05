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
    public class LoginModule : NancyModule
    {
        public LoginModule()
            : base("api/login")
        {
            Get["/"] = _ =>
            {
                var loginVM = new LoginViewModel();
                loginVM.verifyIsAuthFlag = false;
                loginVM.UserInfo = CreateUserInfo();
                loginVM.UserMenu = CreateMenuItems();
                loginVM.SignOutHref = this.Request.ToPublicUrl() + "?signoutFlag=true";

                return new JsonResponse(loginVM, new DefaultJsonSerializer {  }); //Response.AsJson(loginVM);
            };
        }

        internal UserInfoViewModel CreateUserInfo()
        {
            return new UserInfoViewModel
            {
                UserName = "jongho",
                UserId = "1234",
            };
        }

        internal List<MenuItemViewModel> CreateMenuItems()
        {
            return new List<MenuItemViewModel>
        	{
            	new MenuItemViewModel { Name="Patient", Description="Shinchon", MenuSize=2, 
                     Href= this.Request.ToPublicSiteBase() + "api/patientshinchon"  },
                //new MenuItemViewModel { Name="Patient", Description="Kangnam", MenuSize=1  },
                //new MenuItemViewModel { Name="Video", Description="", MenuSize=1 },
                //new MenuItemViewModel { Name="Global Talk", Description="", MenuSize=1 },
                //new MenuItemViewModel { Name="...", Description="", MenuSize=1 }
			};
        }
    }
}