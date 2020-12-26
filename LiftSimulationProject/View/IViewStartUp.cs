using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdditionalSystemConfiguration;

namespace View
{
    public interface IViewStartUp
    {
        event Action StartSystem;

        void providePersonData(out string PersonInitialFloor, out string PersonDestinationFloor, out string PersonWeight);
        void provideLiftData(out string InitNumberOfFloor, out string LiftInitialFloor);

        void showIncorrectInputMessage(string message);
        void showCriticalErrorMessage(string message);

        void Close();
    }
}
