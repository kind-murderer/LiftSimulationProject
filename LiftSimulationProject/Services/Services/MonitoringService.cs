using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiftSimulationProject.Services.IServices;
using LiftSimulationProject.Repositories.IRepository;
using LiftSimulationProject.Entities.IEntities;

namespace LiftSimulationProject.Services.Services
{
    public class MonitoringService : IMonitoringService
    {
        IManageSystemService manageSystemService = SystemManageServerAccessHelper.GetManageSystemService();

        public event Action PassangerStatusesUpdated;

        public MonitoringService()
        {

            manageSystemService.GetPassangerRepository().passangersUpdated += passangersUpdatedHandler;
        }

        private void passangersUpdatedHandler()
        {
            PassangerStatusesUpdated?.Invoke();
        }
        public List<string> GetPassangerStatusesList()
        {
            List<string> statuses = new List<string>();

            //always lock transporter BEFORE passangers because of deadlocks
            lock (manageSystemService.GetTransporter())
            {
                lock (manageSystemService.GetPassangerRepository().passangers)
                {
                    List<IPassanger> passangers = manageSystemService.GetPassangerRepository().passangers;
                   
                    foreach (IPassanger passanger in passangers)
                    {
                        //we don't need passanger that just was created and didn't call for this moment
                        if (!(!passanger.IsInTransporter
                            && passanger.personData.PersonCurrentFloor != passanger.personData.PersonDestinationFloor
                            && !passanger.IsCallingTransporter))
                        {
                            if (!passanger.IsInTransporter
                            && passanger.personData.PersonCurrentFloor != passanger.personData.PersonDestinationFloor
                            && passanger.IsCallingTransporter)
                            {
                                statuses.Add(String.Format($"Человек ожидает лифт на этаже {passanger.personData.PersonCurrentFloor}"));
                            }
                            else if (passanger.IsInTransporter
                                && passanger.personData.PersonCurrentFloor != passanger.personData.PersonDestinationFloor)
                            {
                                string direction = "-";
                                if (manageSystemService.GetTransporter().Direction.Equals("Up")) {
                                    direction = "вверх";
                                }
                                else if (manageSystemService.GetTransporter().Direction.Equals("Down")) {
                                    direction = "вниз";
                                }
                                statuses.Add(String.Format($"Человек находится в движущемся {direction} лифте на уровне этажа {passanger.personData.PersonCurrentFloor}"));
                            } else if (!passanger.IsInTransporter
                            && passanger.personData.PersonCurrentFloor == passanger.personData.PersonDestinationFloor)
                            {
                                statuses.Add(String.Format($"Человек доставлен на целевой этаж {passanger.personData.PersonDestinationFloor}"));
                            }
                        }
                    }
                }
                
            }
            
            return statuses;//can be empty
        }
    }
}
