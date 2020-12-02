using Autofac;

namespace LiftSimulationProject.Autofac
{
    class AutofacBuilder
    {
        public static IContainer Build()
        {
            var builder = new ContainerBuilder();

           //Позже

            return builder.Build();
        }
    }
}
