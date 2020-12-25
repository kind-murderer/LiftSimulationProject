using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiftSimulationProject.Entities.IEntities;
using LiftSimulationProject.Entities.Entities;
using LiftSimulationProject.Repositories.IRepository;
using AdditionalSystemConfiguration;
using Autofac;
using LiftSimulationProject.Autofac;

namespace LiftSimulationProject.Repositories.Repository
{
    public class PersonRepository : IPassangerRepository
    {
        //1 for the whole program

        public List<IPassanger> passangers { get; set; }

        public event Action passangersUpdated;
        public event Action passangerCalls;

        public PersonRepository()
        {
            passangers = new List<IPassanger>();
        }
        public bool AddPassanger(PersonConfigData passangerData)
        {
            lock (passangers)
            {
                IPassanger passanger = ContainerProvider.Container.Resolve<IPassanger>(
                    new TypedParameter(typeof(IPassangerRepository), this), 
                    new TypedParameter(typeof(PersonConfigData), passangerData));
                
                passangers.Add(passanger);
                Console.WriteLine("we added person");
            }
            //You're reached repository
            return true;
        }

        public void DeletePassanger(IPassanger passanger)
        {
            lock (passangers)
            {
                passangers.Remove(passanger);
            }
            OnPassangersUpdated();
        }
        public void UpdatePassangerData(IPassanger passanger, PersonConfigData personData)
        {
        }
        public void OnPassangersUpdated()
        {
            passangersUpdated?.Invoke();
        }

        public void OnPassangerCalls()
        {
            passangerCalls?.Invoke();
        }
    }
}
