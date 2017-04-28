
namespace Testsolution.Web.Infrastructure.Windsor
{
    using Castle.Windsor;
    using Castle.Windsor.Installer;

    public class IocContainer
    {
        public static void Setup(IWindsorContainer container)
        {
            container.Install(FromAssembly.This());
        }
    }
}
