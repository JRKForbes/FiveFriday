using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Castle.Windsor;
using CCM.API.CastleDI;

namespace CCM.API
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        private IWindsorContainer _container;

        public WebApiApplication()
        {
            this._container = new WindsorContainer().Install(new DependencyInstaller());
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            
            GlobalConfiguration.Configuration.Services.Replace(typeof(IHttpControllerActivator), new WindsorActivator(this._container));
        }
    }
}
