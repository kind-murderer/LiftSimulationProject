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
        /*private IStartLiftSystemService startLiftSystemService;
        private IAddPassangerService addPassangerService; */
        private ILiftInitConfigService liftInitConfigService;
       

        public PresenterStartUp(IViewStartUp view, /*IStartLiftSystemService startLiftSystemService,
            IAddPassangerService addPassangerService,*/ ILiftInitConfigService liftInitConfigService) : base(view)
        {
            /* this.startLiftSystemService = startLiftSystemService;
             this.addPassangerService = addPassangerService;*/

            this.liftInitConfigService = liftInitConfigService;

            view.StartSystem += StartSystemHandler;
        }

        public delegate PresenterStartUp Factory(IViewStartUp view);

        private bool checkLiftData(out int numberOfFloors)
        {
            numberOfFloors = 0;
            int liftInitialFloor = 0;

            string CRITICALTESTWORD = "12";

            view.provideLiftData(out string InitNumberOfFloor, out string LiftInitialFloor);

            if (string.IsNullOrEmpty(InitNumberOfFloor) || !int.TryParse(InitNumberOfFloor, out numberOfFloors)
                || string.IsNullOrEmpty(LiftInitialFloor) || !int.TryParse(LiftInitialFloor, out liftInitialFloor))
            {
                view.showIncorrectInputMessage("Некорректно введены данные");
            }
            else if (!(
              (numberOfFloors > 1 && numberOfFloors <= LiftConfigData.maxNumberOfFloors)
          && (liftInitialFloor > 0 && liftInitialFloor <= numberOfFloors)))
            {
                view.showIncorrectInputMessage("Введенные данные не лежат в необходимом диапазоне");
            }
            else if (InitNumberOfFloor.Equals(CRITICALTESTWORD))
            {
                view.showIncorrectInputMessage("");
                view.showCriticalErrorMessage("Произошла критическая ошибка. Попробуйте еще раз");
            }
            else if (liftInitConfigService.SetLiftInitialConfiguration())
            {
                return true;
            }

            return false;
        }
        private bool checkPersonData(int numberOfFloors)
        {
            int personInitialFloor = 0;
            int personDestinationFloor = 0;
            int personWeight = 0;

            view.providePersonData(out string PersonInitialFloor, out string PersonDestinationFloor, out string PersonWeight);

            if (string.IsNullOrEmpty(PersonDestinationFloor) || !int.TryParse(PersonDestinationFloor, out personDestinationFloor)
                || string.IsNullOrEmpty(PersonInitialFloor) || !int.TryParse(PersonInitialFloor, out personInitialFloor)
                || string.IsNullOrEmpty(PersonWeight) || !int.TryParse(PersonWeight, out personWeight))
            {
                view.showIncorrectInputMessage("Некорректно введены данные");
            }
            else if (!(
                (personInitialFloor > 0 && personInitialFloor <= numberOfFloors && personInitialFloor != personDestinationFloor)
          && (personDestinationFloor > 0 && personDestinationFloor <= numberOfFloors)
          && (personWeight > 0 && personWeight <= PersonConfigData.maxWeightToCarry)))
            {
                view.showIncorrectInputMessage("Введенные данные не лежат в необходимом диапазоне");
            }
            else if (liftInitConfigService.SetLiftInitialConfiguration())
            {

                return true;
            }
            return false;
        }

        private LiftConfigData convertLiftData()
        {
            view.provideLiftData(out string InitNumberOfFloor, out string LiftInitialFloor);
            int.TryParse(InitNumberOfFloor, out int initNumberOfFloor);
            int.TryParse(LiftInitialFloor, out int liftInitialFloor);

            return new LiftConfigData(initNumberOfFloor, liftInitialFloor);
        }

        private PersonConfigData convertPersonData()
        {
            view.providePersonData(out string PersonInitialFloor, out string PersonDestinationFloor, out string PersonWeight);
            int.TryParse(PersonInitialFloor, out int personInitialFloor);
            int.TryParse(PersonDestinationFloor, out int personDestinationFloor);
            int.TryParse(PersonWeight, out int personWeight);

            return new PersonConfigData(personInitialFloor, personDestinationFloor, personWeight);
        }
        private void StartSystemHandler()
        {
            //int numberOfFloors = 0;
            /*int liftInitialFloor = 0;
            int personInitialFloor = 0;
            int personDestinationFloor = 0;
            int personWeight = 0;

            string CRITICALTESTWORD = "12";*/


            /*view.providePersonData(out string PersonInitialFloor, out string PersonDestinationFloor, out string PersonWeight);
            view.provideLiftData(out string InitNumberOfFloor, out string LiftInitialFloor);*/

            /*if (string.IsNullOrEmpty(InitNumberOfFloor) || !int.TryParse(InitNumberOfFloor, out numberOfFloors)
                || string.IsNullOrEmpty(LiftInitialFloor) || !int.TryParse(LiftInitialFloor, out liftInitialFloor)
                || string.IsNullOrEmpty(PersonDestinationFloor) || !int.TryParse(PersonDestinationFloor, out personDestinationFloor)
                || string.IsNullOrEmpty(PersonInitialFloor) || !int.TryParse(PersonInitialFloor, out personInitialFloor)
                || string.IsNullOrEmpty(PersonWeight) || !int.TryParse(PersonWeight, out personWeight))
            {
                view.showIncorrectInputMessage("Некорректно введены данные");
            } else if (!(
                (numberOfFloors > 1 && numberOfFloors <= LiftConfigData.maxNumberOfFloors)
            && (liftInitialFloor > 0 && liftInitialFloor <= numberOfFloors)
            && (personInitialFloor > 0 && personInitialFloor <= numberOfFloors && personInitialFloor!= personDestinationFloor)
            && (personDestinationFloor > 0 && personDestinationFloor <= numberOfFloors)
            && (personWeight > 0 && personWeight <= PersonConfigData.maxWeightToCarry)))
            {
                view.showIncorrectInputMessage("Введенные данные не лежат в необходимом диапазоне");
            } else if (InitNumberOfFloor.Equals(CRITICALTESTWORD))
            {
                view.showIncorrectInputMessage("");
                view.showCriticalErrorMessage("Произошла критическая ошибка. Попробуйте еще раз");
            } else if (liftInitConfigService.SetLiftInitialConfiguration())
            {
                view.showIncorrectInputMessage("");

                MyApplicationContext.createMonitoringForm().Show();
                MyApplicationContext.createInteriorObservationForm().Show();
                
                view.Close();
            }*/

            int numberOfFloors = 0;
            if (checkLiftData(out numberOfFloors) && checkPersonData(numberOfFloors) && liftInitConfigService.SetLiftInitialConfiguration())
            {
                LiftConfigData liftData = convertLiftData();
                PersonConfigData personData = convertPersonData();

                view.showIncorrectInputMessage("");

                MyApplicationContext.createMonitoringForm().Show();
                MyApplicationContext.createInteriorObservationForm().Show();

                view.Close();
            }
        }
    }
}
