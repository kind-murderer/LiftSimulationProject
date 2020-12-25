using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdditionalSystemConfiguration;
using LiftSimulationProject.Repositories.IRepository;

namespace LiftSimulationProject.Entities.IEntities
{
    public interface IPassanger
    {
        IPassangerRepository repository { get; set; }
        bool IsInTransporter { get; set; }
        bool IsCallingTransporter { get; set; }
        PersonConfigData personData { get; set; }



        //change class properties and return true if the moment when passanger shoult get in the transport had come
        //properties of the passangers changes in the interval between GetInTransporter and GetOutOfTransporter 
        bool ShouldGetInTransporter(LiftConfigData liftData);
        bool ShouldGetOutOfTransporter();
        void ContinueLive();
    }
}
