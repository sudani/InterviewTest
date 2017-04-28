using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testsolution.Web.Infrastructure.Windsor
{
    using System.Web.Http.Dependencies;

    public class CastleWindsorDependencyScope : IDependencyScope
    {
        private readonly IDisposable scope;
        private readonly IDependencyScope resolver;

        public CastleWindsorDependencyScope(IDisposable scope, IDependencyScope resolver)
        {
            this.scope = scope;
            this.resolver = resolver;
        }
        public void Dispose()
        {
            this.scope.Dispose();
        }

        public object GetService(Type serviceType)
        {
            return this.resolver.GetService(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return this.resolver.GetServices(serviceType);
        }
    }
}
