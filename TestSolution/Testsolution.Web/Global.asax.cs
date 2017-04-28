using System;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace Testsolution.Web
{
    using Castle.Windsor;
    using Infrastructure.Windsor;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using IDependencyResolver = System.Web.Http.Dependencies.IDependencyResolver;

    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            AreaRegistration.RegisterAllAreas();

            GlobalConfiguration.Configure(WebApiConfig.Register);
            var container = new WindsorContainer();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            IocContainer.Setup(container);
            WindsorRegister(GlobalConfiguration.Configuration, container);

            //BundleConfig.RegisterBundles(BundleTable.Bundles);

        }

        public void WindsorRegister(HttpConfiguration config, IWindsorContainer container)
        {
            config.DependencyResolver = GetWindsorDependencyResolver(config.DependencyResolver, container);
        }

        private IDependencyResolver GetWindsorDependencyResolver(IDependencyResolver underlyingResolver, IWindsorContainer container)
        {
            return new CastleWindsorDependencyResolver(container, underlyingResolver);
        }
    }
}