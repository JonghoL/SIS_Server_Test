using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIS_Server_Test.ViewModels
{
    public class UserInfoViewModel
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string DeptName { get; set; }
        public string OcpType { get; set; }
        public string UserData
        {
            get
            {
                var ret = "UserId:" + (UserId ?? "") + ";UserName:" + (UserName ?? "") + ";DeptName:" + (DeptName ?? "") + ";OcpType:" + (OcpType ?? "");
                return ret;
            }
        }

        public UserInfoViewModel() { }
        public UserInfoViewModel(string userData)
        {
            var data = userData.Split(';');
            foreach (var dtl in data)
            {
                var kv = dtl.Split(':');
                if (kv.Length > 1)
                {
                    if (kv[0] == "UserId")
                    {
                        UserId = kv[1];
                    }
                    else if (kv[0] == "UserName")
                    {
                        UserName = kv[1];
                    }
                    else if (kv[0] == "DeptName")
                    {
                        DeptName = kv[1];
                    }
                    else if (kv[0] == "OcpType")
                    {
                        OcpType = kv[1];
                    }
                }
            }
        }
    }
}