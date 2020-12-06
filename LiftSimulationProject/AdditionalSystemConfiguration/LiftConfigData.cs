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

        public int InitNumberOfFloor { get; set; }
        public int LiftInitialFloor { get; set; }

        public LiftConfigData(int initNumberOfFloor, int liftInitialFloor)
        {
            InitNumberOfFloor = initNumberOfFloor;
            LiftInitialFloor = liftInitialFloor;
        }
    }
}

