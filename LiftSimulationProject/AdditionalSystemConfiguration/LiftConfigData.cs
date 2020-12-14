using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdditionalSystemConfiguration
{
    public class LiftConfigData
    {
        public static readonly int maxNumberOfFloors = 12;

        public static int NumberOfFloors { get; set; }
        public int LiftCurrentFloor { get; set; }

        public LiftConfigData(int initNumberOfFloor, int liftInitialFloor)
        {
            NumberOfFloors = initNumberOfFloor;
            LiftCurrentFloor = liftInitialFloor;
        }
    }
}

