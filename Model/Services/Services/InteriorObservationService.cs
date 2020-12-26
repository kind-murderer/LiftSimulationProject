using System;
using System.Collections.Generic;
using Services.IServices;
using Entities.IEntities;

namespace Services.Services
{

    public  class InteriorObservationService : IInteriorObservationService
    {
        IManageSystemService manageSystemService = SystemManageServerAccessHelper.GetManageSystemService();


        public InteriorObservationService()
        {
            manageSystemService.GetTransporter().InteriorUpdated += InteriorUpdatedHandler;
        }

        public event Action InteriorUpdated;

        public int[] GetActiveInteriorCalls(out int transporterCurrentFloor, out bool wasOverloaded)
        {
            int[] activeInteriorCalls;
            
            lock (manageSystemService.GetTransporter())
            {
                lock (manageSystemService.GetPassangerRepository().passangers)
                {
                    transporterCurrentFloor = manageSystemService.GetTransporter().liftData.LiftCurrentFloor;
                    wasOverloaded = manageSystemService.GetTransporter().WasOverloaded;

                    List<IPassanger> passangersInTransporter = manageSystemService.GetPassangerRepository().passangers.
                        FindAll(passanger => passanger.IsInTransporter);

                    activeInteriorCalls = new int[passangersInTransporter.Count];
                    int i = 0;
                    foreach (IPassanger passanger in passangersInTransporter)
                    {
                        activeInteriorCalls[i] = passanger.personData.PersonDestinationFloor;
                        i++;
                    }
                }
            }
            return activeInteriorCalls;
        }

        void InteriorUpdatedHandler()
        {
            InteriorUpdated?.Invoke();
        }
    }
}
