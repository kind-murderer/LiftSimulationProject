using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using View;
using LiftSimulationProject.Services.Services;
using LiftSimulationProject.Services.IServices;
using LiftSimulationProject;
using AdditionalSystemConfiguration;
using System.Threading;

namespace LiftSimulationProject.Presenters
{
    public class PresenterStartUp : PresenterBase<IViewStartUp>
    {
        IManageSystemService manageSystemService = SystemManageServerAccessHelper.GetManageSystemService();
       
        public PresenterStartUp(IViewStartUp view) : base(view)
        {
            view.StartSystem += StartSystemHandler;
        }

        public delegate PresenterStartUp Factory(IViewStartUp view);

        private void StartSystemHandler()
        {

            //string CRITICALTESTWORD = "12";

            //int numberOfFloors = 0;
            if (checkTransporterData(out int numberOfFloors) && checkPassangerData(numberOfFloors))
            {
                LiftConfigData transporterData = convertTransporterData();
                PersonConfigData passangerData = convertPassangerData();
                if (manageSystemService.TryStartSystem(transporterData, passangerData))
                {
                    view.showIncorrectInputMessage("");

                    MyApplicationContext.createMonitoringForm().Show();
                    MyApplicationContext.createInteriorObservationForm().Show();

                    view.Close();
                }
                else
                {
                    view.showIncorrectInputMessage("");
                    view.showCriticalErrorMessage("Произошла критическая ошибка. Попробуйте еще раз");
                }

            }
        }
        private bool checkTransporterData(out int numberOfFloors)
        {
            numberOfFloors = 0;
            int transporterInitialFloor = 0;

            //string CRITICALTESTWORD = "12";

            view.provideLiftData(out string NumberOfFloor, out string TransporterInitialFloor);

            if (string.IsNullOrEmpty(NumberOfFloor) || !int.TryParse(NumberOfFloor, out numberOfFloors)
                || string.IsNullOrEmpty(TransporterInitialFloor) || !int.TryParse(TransporterInitialFloor, out transporterInitialFloor))
            {
                view.showIncorrectInputMessage("Некорректно введены данные");
            }
            else if (!(
              (numberOfFloors > 1 && numberOfFloors <= LiftConfigData.maxNumberOfFloors)
          && (transporterInitialFloor > 0 && transporterInitialFloor <= numberOfFloors)))
            {
                view.showIncorrectInputMessage("Введенные данные не лежат в необходимом диапазоне");
            }
            /*else if (NumberOfFloor.Equals(CRITICALTESTWORD))
            {
                view.showIncorrectInputMessage("");
                view.showCriticalErrorMessage("Произошла критическая ошибка. Попробуйте еще раз");
            }*/
            else
            {
                return true;
            }

            return false;
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

        private LiftConfigData convertTransporterData()
        {
            view.provideLiftData(out string NumberOfFloor, out string TransporterInitialFloor);
            int.TryParse(NumberOfFloor, out int numberOfFloor);
            int.TryParse(TransporterInitialFloor, out int transporterInitialFloor);
            return new LiftConfigData(numberOfFloor, transporterInitialFloor);
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
