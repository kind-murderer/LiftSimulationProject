using Autofac;
using LiftSimulationProject.Presenters;
using LiftSimulationProject.Services.Services;
using LiftSimulationProject.Services.IServices;
using LiftSimulationProject.Repositories.Repository;
using LiftSimulationProject.Repositories.IRepository;
using LiftSimulationProject.Entities.Entities;
using LiftSimulationProject.Entities.IEntities;




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
