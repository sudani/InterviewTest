
namespace Testsolution.Web.Infrastructure.Windsor
{
    using Castle.Windsor;
    using Castle.Windsor.Installer;
    using Data;
    using Logic;

    public class IocContainer
    {
        public static void Setup(IWindsorContainer container)
        {
            container.Install(FromAssembly.Containing<DataInstaller>());
            container.Install(FromAssembly.Containing<LogicInstaller>());
            container.Install(FromAssembly.This());
        }
    }
}
