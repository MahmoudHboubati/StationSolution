using Core.Repositories;
using Core.Services;
using DAL.Repository;
using Ninject;
using Ninject.Parameters;
using Ninject.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Dependencies;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace StationAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            IKernel kernel = new StandardKernel();

            kernel.Bind<IStationProvider>().To<StationProvider>();
            kernel.Bind<IStationRepository>().To<StationRepository>();

            GlobalConfiguration.Configuration.DependencyResolver = new NInjectDependencyResolver(kernel);
        }
    }

    public class NInjectDependencyResolver : NInjectDependencyScope, System.Web.Http.Dependencies.IDependencyResolver
    {
        private IKernel _kernel;

        public NInjectDependencyResolver(IKernel kernel)
            : base(kernel)
        {
            _kernel = kernel;
        }

        public IDependencyScope BeginScope()
        {
            return new NInjectDependencyScope(_kernel.BeginBlock());
        }
    }

    public class NInjectDependencyScope : IDependencyScope
    {
        private IResolutionRoot _resolutionRoot;

        public NInjectDependencyScope(IResolutionRoot resolutionRoot)
        {
            _resolutionRoot = resolutionRoot;
        }

        public void Dispose()
        {
            var disposable = _resolutionRoot as IDisposable;

            if (disposable != null)
                disposable.Dispose();

            _resolutionRoot = null;
        }

        public object GetService(Type serviceType)
        {
            return GetServices(serviceType).FirstOrDefault();
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            var request = _resolutionRoot.CreateRequest(serviceType, null, new IParameter[0], true, true);

            return _resolutionRoot.Resolve(request);
        }
    }
}
