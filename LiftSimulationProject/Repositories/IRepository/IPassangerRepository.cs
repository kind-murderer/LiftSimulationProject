using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdditionalSystemConfiguration;
using LiftSimulationProject.Entities.IEntities;

namespace LiftSimulationProject.Repositories.IRepository
{
    public interface IPassangerRepository
    {
        
        List<IPassanger> passangers { get; set; } //access should be synchronized

        event Action passangersUpdated;
        event Action passangerCalls;

        void OnPassangersUpdated();
        void OnPassangerCalls();
        bool AddPassanger(PersonConfigData passangerData);

        //only passangers use it
        void DeletePassanger(IPassanger passanger); 
        

    }
}
