using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiftSimulationProject.Services.Services;
using Autofac;
using LiftSimulationProject.Autofac;
using LiftSimulationProject.Repositories.IRepository;

namespace LiftSimulationProject.Services.IServices
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
            
            IPassangerRepository repository = ContainerProvider.Container.Resolve<IPassangerRepository>();
            
            IManageSystemService manageSystemService = ContainerProvider.Container.Resolve<IManageSystemService>(
                new TypedParameter(typeof(IPassangerRepository), repository));

            return manageSystemService;
        }

    }
}
