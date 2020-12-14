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

        //another class that has reference to passangers and different methods with it..
        //..should know the state of the passangers lock  
        /*object PassPassangersLockObject();*/

        void OnPassangersUpdated();
        bool AddPassanger(PersonConfigData passangerData);

        //only passangers use it; should be synchronized method
        void DeletePassanger(IPassanger passanger); 
        void UpdatePassangerData(IPassanger passanger, PersonConfigData personData);

        //List<IPassanger> GetPassangers();
    }
}
