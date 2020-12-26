using System;

namespace View
{
    public interface IViewStartUp
    {
        event Action StartSystem;

        void providePersonData(out string PersonInitialFloor, out string PersonDestinationFloor, out string PersonWeight);
        void provideLiftData(out string InitNumberOfFloor, out string LiftInitialFloor);

        void showIncorrectInputMessage(string message);
        void showCriticalErrorMessage(string message);
        void CreateShowMonitoringForm();
        void CreateShowInteriorObservationForm();
        void Close();
    }
}
