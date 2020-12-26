using System;
using System.Collections.Generic;

namespace View
{
    public interface IViewMonitoring
    {
        void providePersonData(out string PersonInitialFloor, out string PersonDestinationFloor, out string PersonWeight);

        void showIncorrectInputMessage(string message);
        void showCriticalErrorMessage(string message);

        event Action StopSystem;
        event Action AddPassanger;

        void ShowCurrentPassangerStatuses(List<string> statuses);
        void ShowStatistic(String text);

    }
}
