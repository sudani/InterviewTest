namespace Testsolution.Web.Infrastructure.Windsor
{
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;

    public class LogicInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromAssembly(typeof(Logic.AssemblyHook).Assembly)
                .Where(type => type.Name.EndsWith("Manager"))
                .WithServiceDefaultInterfaces()
                .LifestylePerWebRequest());
        }
    }
}
