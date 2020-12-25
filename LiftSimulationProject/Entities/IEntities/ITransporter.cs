using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdditionalSystemConfiguration;

namespace LiftSimulationProject.Entities.IEntities
{
    public interface ITransporter
    {
        string Direction { get; set; }
        bool IsPaused { get; set; }

        LiftConfigData liftData { get;}

        bool ChooseDeriction(List<IPassanger> passangers, List<IPassanger> passangersInTransporter);
        void Load(List<IPassanger> passangersToGetIn);
        void Offload(List<IPassanger> passangersToGetOut);
        void Move(List<IPassanger> passangersInTransporter);
    }
}
