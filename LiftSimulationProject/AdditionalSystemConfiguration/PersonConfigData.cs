using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdditionalSystemConfiguration
{
    public class PersonConfigData
    {
        
        public int PersonCurrentFloor { get; set;  }
        public int PersonDestinationFloor { get; set; }
        public int PersonWeight { get; set; }
       
        public PersonConfigData(int personInitialFloor, int personDestinationFloor, int personWeight)
        {
            PersonCurrentFloor = personInitialFloor;
            PersonDestinationFloor = personDestinationFloor;
            PersonWeight = personWeight;
        }

    }
}
