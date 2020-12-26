using Autofac;
using LiftSimulationProject.Autofac;
using Repositories.IRepository;

namespace Services.IServices
{
    public class SystemManageServerAccessHelper
    {
        //because i can't make Singleton(RunningSystemServ) implementing interface (IRunningService can't contain static fields)
        //(like "static method GetRunningService()")
        //this class will take responsibility of controlling the creating+access of SystemRunningServer

        private static IManageSystemService manageSystemService;
        private readonly static object synchObject = new object();
        public SystemManageServerAccessHelper() { }

        public static IManageSystemService GetManageSystemService()
        {
            if (manageSystemService == null)
            {
                lock (synchObject)
                {
                    if (manageSystemService == null)
                    {
                        manageSystemService = createManageSystemService();
                    }
                }
            }
            return manageSystemService;
        }

        private static IManageSystemService createManageSystemService()
        {
            
            IPassangerRepository repository = AutofacContainerProvider.Container.Resolve<IPassangerRepository>();
            
            IManageSystemService manageSystemService = AutofacContainerProvider.Container.Resolve<IManageSystemService>(
                new TypedParameter(typeof(IPassangerRepository), repository));

            return manageSystemService;
        }

    }
}
