using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy;
using SIS_Server_Test.ViewModels;
using Nancy.Responses;

namespace SIS_Server_Test.Modules
{
    public class LoginModule : NancyModule
    {
        public LoginModule()
            : base("/login")
        {
            Get["/"] = _ =>
            {
                var loginVM = new LoginViewModel();
                loginVM.verifyIsAuthFlag = false;
                loginVM.UserInfo = LoginModule.CreateUserInfo();
                loginVM.UserMenu = LoginModule.CreateMenuItems();
                loginVM.SignOutHref = "http://localhost:5000/api/Login?signoutFlag=true";

                return new JsonResponse(loginVM, new DefaultJsonSerializer {  }); //Response.AsJson(loginVM);
            };
        }

        static internal UserInfoViewModel CreateUserInfo()
        {
            return new UserInfoViewModel
            {
                UserName = "jongho",
                UserId = "1234",
            };
        }

        static internal List<MenuItemViewModel> CreateMenuItems()
        {
            return new List<MenuItemViewModel>
        	{
            	new MenuItemViewModel { Name="Patient", Description="Shinchon", MenuSize=2, Href="http://localhost:5000/api/patientshinchon"  },
            	new MenuItemViewModel { Name="Patient", Description="Kangnam", MenuSize=1  },
            	new MenuItemViewModel { Name="Video", Description="", MenuSize=1 },
            	new MenuItemViewModel { Name="Global Talk", Description="", MenuSize=1 },
                new MenuItemViewModel { Name="...", Description="", MenuSize=1 }
			};
        }
    }
}