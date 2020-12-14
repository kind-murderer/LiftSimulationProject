using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiftSimulationProject.Services.IServices;
using View;
using AdditionalSystemConfiguration;

namespace LiftSimulationProject.Presenters
{
    public class PresenterMonitoring : PresenterBase<IViewMonitoring>
    {
        IMonitoringService monitoringService;

        public PresenterMonitoring(IViewMonitoring view, IMonitoringService monitoringService) : base(view)
        {
            this.monitoringService = monitoringService;

            view.StopSystem += StopSystemHandler;
            view.AddPassanger += AddPassangerHandler;

            monitoringService.PassangerStatusesUpdated += PassangerStatusesUpdatedHandler;
        }

        public delegate PresenterMonitoring Factory(IViewMonitoring view);
        private void AddPassangerHandler()
        {
            Console.WriteLine("in add passanger handler");
            if (checkPassangerData(LiftConfigData.NumberOfFloors))
            {
                PersonConfigData passangerData = convertPassangerData();
                if (!SystemManageServerAccessHelper.GetManageSystemService().TryAddPerson(passangerData))
                {
                    view.showIncorrectInputMessage("");
                    view.showCriticalErrorMessage("Произошла критическая ошибка. Попробуйте еще раз");
                }
            }
            else
            {
                view.showIncorrectInputMessage("Некорректно введены данные");
            }
            
        }
        private void StopSystemHandler()
        {
            if (SystemManageServerAccessHelper.GetManageSystemService().TryStopSystem())
            {
                System.Windows.Forms.Application.Exit(); //close application
            }
            else
            {
                view.showCriticalErrorMessage("Вы не можете закрыть приложения, пока есть люди в системе.");
            }
        }

        public void PassangerStatusesUpdatedHandler()
        {
            List<string> statuses = monitoringService.GetPassangerStatusesList();
            view.ShowCurrentPassangerStatuses(statuses);
        }

        private bool checkPassangerData(int numberOfFloors)
        {
            int passangerInitialFloor = 0;
            int passangerDestinationFloor = 0;
            int passangerWeight = 0;

            view.providePersonData(out string PassangerInitialFloor, out string PassangerDestinationFloor, out string PassangerWeight);

            if (string.IsNullOrEmpty(PassangerDestinationFloor) || !int.TryParse(PassangerDestinationFloor, out passangerDestinationFloor)
                || string.IsNullOrEmpty(PassangerInitialFloor) || !int.TryParse(PassangerInitialFloor, out passangerInitialFloor)
                || string.IsNullOrEmpty(PassangerWeight) || !int.TryParse(PassangerWeight, out passangerWeight))
            {
                view.showIncorrectInputMessage("Некорректно введены данные");
            }
            else if (!(
                (passangerInitialFloor > 0 && passangerInitialFloor <= numberOfFloors && passangerInitialFloor != passangerDestinationFloor)
          && (passangerDestinationFloor > 0 && passangerDestinationFloor <= numberOfFloors)
          && (passangerWeight > 0 && passangerWeight <= PersonConfigData.maxWeightToCarry)))
            {
                view.showIncorrectInputMessage("Введенные данные не лежат в необходимом диапазоне");
            }
            else
            {
                return true;
            }
            return false;
        }
        private PersonConfigData convertPassangerData()
        {
            view.providePersonData(out string PassangerInitialFloor, out string PassangerDestinationFloor, out string PassangerWeight);
            int.TryParse(PassangerInitialFloor, out int passangerInitialFloor);
            int.TryParse(PassangerDestinationFloor, out int passangerDestinationFloor);
            int.TryParse(PassangerWeight, out int passangerWeight);

            return new PersonConfigData(passangerInitialFloor, passangerDestinationFloor, passangerWeight);
        }
    }
}
