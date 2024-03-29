﻿using View;
using Services.IServices;
using AdditionalSystemConfiguration;

namespace Presenters
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

            if (checkTransporterData(out int numberOfFloors) && checkPassangerData(numberOfFloors))
            {
                LiftConfigData transporterData = convertTransporterData();
                PersonConfigData passangerData = convertPassangerData();

                if (passangerData != null)
                {
                    if (manageSystemService.TryStartSystem(transporterData) && manageSystemService.TryAddPerson(passangerData))
                    {
                        view.showIncorrectInputMessage("");
                        view.CreateShowMonitoringForm();
                        view.CreateShowInteriorObservationForm();
                        view.Close();
                    }
                    else
                    {
                        view.showIncorrectInputMessage("");
                        view.showCriticalErrorMessage("Произошла критическая ошибка. Попробуйте еще раз");
                    } 
                }
                else if (passangerData == null)
                {
                    if (manageSystemService.TryStartSystem(transporterData))
                    {
                        view.showIncorrectInputMessage("");
                        view.CreateShowMonitoringForm();
                        view.CreateShowInteriorObservationForm();
                        view.Close();
                    }
                    else
                    {
                        view.showIncorrectInputMessage("");
                        view.showCriticalErrorMessage("Произошла критическая ошибка. Попробуйте еще раз");
                    }
                }
                

            }
        }
        private bool checkTransporterData(out int numberOfFloors)
        {
            numberOfFloors = 0;
            int transporterInitialFloor = 0;

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
            else
            {
                view.showIncorrectInputMessage("");
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
            if (string.IsNullOrEmpty(PassangerDestinationFloor) && string.IsNullOrEmpty(PassangerInitialFloor) && string.IsNullOrEmpty(PassangerWeight))
            {
                //we will start without passangers
                return true;
            }
            else if (!int.TryParse(PassangerDestinationFloor, out passangerDestinationFloor)
                || !int.TryParse(PassangerInitialFloor, out passangerInitialFloor)
                || !int.TryParse(PassangerWeight, out passangerWeight))
            {
                view.showIncorrectInputMessage("Некорректно введены данные");
                return false;
            }
            else if (!(
                (passangerInitialFloor > 0 && passangerInitialFloor <= numberOfFloors && passangerInitialFloor != passangerDestinationFloor)
          && (passangerDestinationFloor > 0 && passangerDestinationFloor <= numberOfFloors)
          && (passangerWeight > 0 && passangerWeight <= LiftConfigData.maxWeightToCarry)))
            {
                view.showIncorrectInputMessage("Введенные данные не лежат в необходимом диапазоне");
                return false;
            }
            else 
            {
                view.showIncorrectInputMessage("");
                return true;
            }
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
            if (string.IsNullOrEmpty(PassangerInitialFloor)
                && string.IsNullOrEmpty(PassangerDestinationFloor)
                && string.IsNullOrEmpty(PassangerWeight))
            {
                return null;
            }
            int.TryParse(PassangerInitialFloor, out int passangerInitialFloor);
            int.TryParse(PassangerDestinationFloor, out int passangerDestinationFloor);
            int.TryParse(PassangerWeight, out int passangerWeight);

            return new PersonConfigData(passangerInitialFloor, passangerDestinationFloor, passangerWeight);
        }
        
    }
}
