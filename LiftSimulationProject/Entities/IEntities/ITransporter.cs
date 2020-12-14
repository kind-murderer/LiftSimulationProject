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

        void Load(List<IPassanger> passangers);
        void Offload(List<IPassanger> passangers);
        void Move(List<IPassanger> passangers);
    }
}
