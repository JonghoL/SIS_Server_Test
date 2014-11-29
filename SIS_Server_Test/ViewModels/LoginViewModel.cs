using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SIS_Server_Test.ViewModels;

namespace SIS_Server_Test.ViewModels
{
    public class LoginViewModel
    {
        public UserInfoViewModel UserInfo { get; set; }
        public IEnumerable<MenuItemViewModel> UserMenu { get; set; }
        public string SignOutHref { get; set; }
        public string VerifyIsAuth { get; set; }

        public string returnUrl { get; set; }
        public bool? signOutFlag { get; set; }
        public bool? verifyIsAuthFlag { get; set; }
        public bool? useHash { get; set; }
    }
}