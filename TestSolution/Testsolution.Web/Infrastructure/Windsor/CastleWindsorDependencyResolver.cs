using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testsolution.Web.Infrastructure.Windsor
{
    using System.Web.Http.Dependencies;
    using Castle.MicroKernel.Lifestyle;
    using Castle.Windsor;

    public class CastleWindsorDependencyResolver :IDependencyResolver
    {
        private readonly IWindsorContainer container;
        private readonly IDependencyResolver underlyingResolver;

        public CastleWindsorDependencyResolver(IWindsorContainer container, IDependencyResolver underlyingResolver)
        {
            this.container = container;
            this.underlyingResolver = underlyingResolver;
        }
        public void Dispose()
        {
            this.container.Dispose();
        }

        public object GetService(Type serviceType)
        {
            if (!this.container.Kernel.HasComponent(serviceType))
                return this.underlyingResolver.GetService(serviceType);

            return this.container.Resolve(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return this.container.ResolveAll(serviceType).Cast<object>();
        }

        public IDependencyScope BeginScope()
        {
            return new CastleWindsorDependencyScope(container.BeginScope(), this);
        }
    }
}
