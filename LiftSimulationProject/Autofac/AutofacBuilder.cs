using Autofac;
using LiftSimulationProject.Presenters;
using LiftSimulationProject.Services.Services;
using LiftSimulationProject.Services.IServices;



namespace LiftSimulationProject.Autofac
{
    class AutofacBuilder
    {
        public static IContainer Build()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<PresenterStartUp>().As<PresenterStartUp>();
            builder.RegisterType<LiftInitConfigService>().As<ILiftInitConfigService>();
            //builder.RegisterType<PersonRepositorycs>().As<IPassangerRepository>();

            return builder.Build();
        }
    }
}
