using System;
using System.Collections.Generic;
using AdditionalSystemConfiguration;

namespace Entities.IEntities
{
    public interface ITransporter
    {
        string Direction { get; set; }
        bool IsPaused { get; set; }
        bool WasOverloaded { get; set; }

        event Action InteriorUpdated;
        LiftConfigData liftData { get;}

        bool ChooseDeriction(List<IPassanger> passangers, List<IPassanger> passangersInTransporter);
        void Load(List<IPassanger> passangersToGetIn);
        void Offload(List<IPassanger> passangersToGetOut);
        void Move(List<IPassanger> passangersInTransporter);
        void OnInteriorUpdated();
    }
}
