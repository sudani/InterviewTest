
namespace Testsolution.Web.Infrastructure.Windsor
{
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;

    public class DataInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            var classes = Classes.FromAssembly(typeof(Testsolution.Data.AssemblyHook).Assembly);

            container.Register(classes
                .Where(type => type.Name.EndsWith("Repository"))
                .LifestylePerWebRequest()
                .WithServiceDefaultInterfaces());
        }
    }
}
