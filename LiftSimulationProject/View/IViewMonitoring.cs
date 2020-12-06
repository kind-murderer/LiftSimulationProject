using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdditionalSystemConfiguration;

namespace View
{
    public interface IViewMonitoring
    {
        void providePersonData(out string PersonInitialFloor, out string PersonDestinationFloor, out string PersonWeight);

        event Action StopSystem;
        event Action CreatePassanger;

        void ShowPassangerCurrentStatus();
    }
}
