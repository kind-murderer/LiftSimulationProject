using System;
using System.Collections.Generic;
using AdditionalSystemConfiguration;
using Entities.IEntities;

namespace Repositories.IRepository
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
