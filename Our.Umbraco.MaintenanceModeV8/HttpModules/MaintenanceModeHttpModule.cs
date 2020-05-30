using System;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Results;
using Our.Umbraco.MaintenanceModeV8.Controllers;
using Our.Umbraco.MaintenanceModeV8.Services;
using Umbraco.Core;
using Umbraco.Core.Logging;

namespace Our.Umbraco.MaintenanceModeV8.HttpModules
{
    public class MaintenanceModeHttpModule : IHttpModule
    {
        public void Init(HttpApplication application)
        {
            application.PreRequestHandlerExecute += this.Application_PreRequestHandlerExecute;
        }

        public void Dispose()
        { }

        private void Application_PreRequestHandlerExecute(object sender, EventArgs e)
        {
            Uri requestUrl = HttpContext.Current.Request.Url;
            string host = requestUrl.Authority.ToLower();
            if (!host.StartsWith("www"))
            {
                HttpContext.Current.Response.Redirect(requestUrl.Scheme + "://www." + host + requestUrl.PathAndQuery);
                HttpContext.Current.Response.End();
            }
        }
    }
}
