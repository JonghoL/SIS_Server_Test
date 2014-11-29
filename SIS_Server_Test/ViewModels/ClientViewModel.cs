using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIS_Server_Test.ViewModels
{
    public class ClientViewModel
    {
        public string ViewType { get; set; }
        public bool NewWindow { get; set; }
        public string ViewDisplayHeader { get; set; }
        public string ViewDisplayText { get; set; }
        public string ViewImageHref { get; set; }
        public string ViewImagePlaceHolder { get; set; }
        public string ViewImagePlaceHolderText { get; set; }
        public string Href { get; set; }
        public IList<ClientViewParameter> Parameters { get; set; }
        public IList<ClientViewModel> Details { get; set; }
        public bool MoreData { get; set; }

        public ClientViewModel()
        {
            this.ViewType = "";
            this.NewWindow = false;
            this.ViewDisplayHeader = "";
            this.ViewDisplayText = "";
            this.ViewImageHref = "";
            this.ViewImagePlaceHolder = "";
            this.ViewImagePlaceHolderText = "";
            this.Href = "";
            this.Parameters = new List<ClientViewParameter>();
            this.Details = new List<ClientViewModel>();
            this.MoreData = false;
        }
    }
}