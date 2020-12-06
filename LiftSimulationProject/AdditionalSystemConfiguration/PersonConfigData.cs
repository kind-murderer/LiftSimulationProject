﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdditionalSystemConfiguration
{
    public class PersonConfigData
    {
        public static readonly int maxWeightToCarry = 400;

        public int PersonInitialFloor { get; set;  }
        public int PersonDestinationFloor { get; set; }
        public int PersonWeight { get; set; }
       
        public PersonConfigData(int personInitialFloor, int personDestinationFloor, int personWeight)
        {
            PersonInitialFloor = personDestinationFloor;
            PersonDestinationFloor = personDestinationFloor;
            PersonWeight = personWeight;
        }

    }
}