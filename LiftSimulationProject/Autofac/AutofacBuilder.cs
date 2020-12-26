using Autofac;
using Presenters;
using Services.Services;
using Services.IServices;
using Repositories.Repository;
using Repositories.IRepository;
using Entities.Entities;
using Entities.IEntities;




namespace LiftSimulationProject.Autofac
{
    class AutofacBuilder
    {
        public static IContainer Build()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<PresenterStartUp>().As<PresenterStartUp>();
            builder.RegisterType<PresenterMonitoring>().As<PresenterMonitoring>();
            builder.RegisterType<PresenterInteriorObservation>().As<PresenterInteriorObservation>();

            builder.RegisterType<MonitoringService>().As<IMonitoringService>();
            builder.RegisterType<ManageSystemService>().As<IManageSystemService>();
            builder.RegisterType<InteriorObservationService>().As<IInteriorObservationService>();

            builder.RegisterType<PersonRepository>().As<IPassangerRepository>();
            builder.RegisterType<Person>().As<IPassanger>();
            builder.RegisterType<Lift>().As<ITransporter>();

            return builder.Build();
        }
    }
}
