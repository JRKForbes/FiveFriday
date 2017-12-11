using CCM.Service;
using CCM.DAL;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using System.Web.Http.Controllers;

namespace CCM.API.CastleDI
{
    public class DependencyInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                    Component.For<ICustomerService>()
                        .ImplementedBy<CustomerService>()
                        .LifeStyle.PerWebRequest,
                    Component.For<IUnitOfWork>()
                        .ImplementedBy<UnitOfWork>()
                        .LifeStyle.PerWebRequest,
                    Component.For<IDatabaseFactory>()
                        .ImplementedBy<DatabaseFactory>()
                        .LifeStyle.PerWebRequest,
                    Classes.FromThisAssembly().BasedOn<IHttpController>().LifestyleTransient(),

                    Classes.FromAssemblyNamed("CCM.Service")
                        .Where(type => type.Name.EndsWith("Service")).WithServiceAllInterfaces().LifestylePerWebRequest(),
                    AllTypes.FromAssemblyNamed("CCM.DAL")
                        .Where(type => type.Name.EndsWith("Repository")).WithServiceAllInterfaces().LifestylePerWebRequest()
                );
        }
    }
}