using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy;

namespace SIS_Server_Test.Utils
{
    public static class RequestUtils
    {
        public static string ToPublicUrl(this Request request)
        {
            var uriBuilder = MakeUriBuilder(request);

            return new Uri(uriBuilder.Uri, request.Url.Path).AbsoluteUri;
        }

        static UriBuilder MakeUriBuilder(Request request)
        {
            var uriBuilder = new UriBuilder
            {
                Host = request.Url.HostName,
                Path = "",
                Port = 80,
                Scheme = "http",
            };

            if (request.Url.HostName == "localhost")
            {
                uriBuilder.Port = (int)request.Url.Port;
            }

            return uriBuilder;
        }

        public static string ToPublicSiteBase(this Request request)
        {
            var uriBuilder = MakeUriBuilder(request);

            return new Uri(uriBuilder.Uri, "").AbsoluteUri;
        }
    }
}