using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIS_Server_Test.ViewModels
{
    public class ClientViewParameter
    {
        public string ParameterKey { get; set; }
        public string ParameterType { get; set; }
        public string ParameterValue { get; set; }
        public string ParameterDisplayText { get; set; }

        public ClientViewParameter()
        {
            this.ParameterKey = "";
            this.ParameterType = "";
            this.ParameterValue = "";
            this.ParameterDisplayText = "";
        }
    }
}