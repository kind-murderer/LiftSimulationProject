using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiftSimulationProject.Entities.IEntities;
using AdditionalSystemConfiguration;

namespace LiftSimulationProject.Entities.Entities
{
    public class Lift : ITransporter
    {
        //Up / Down
        public string Direction { get; set; }
        public bool IsPaused { get; set; }

        public LiftConfigData liftData { get; }
        public Lift(LiftConfigData liftData_)
        {
            liftData = liftData_;
            IsPaused = true;
        }

        public void Load(List<IPassanger> passangers)
        {
            //also checks total weight
        }
        public void Offload(List<IPassanger> passangers)
        {
            //also checks total weight
        }
        public void Move(List<IPassanger> passangers)
        {
            if (Direction.Equals("Up"))
            {
                liftData.LiftCurrentFloor++;
            } else if (Direction.Equals("Down"))
            {
                liftData.LiftCurrentFloor--;
            }

            if(passangers != null)
            {
                //change their currentFloor
            }


        }

    }
}
