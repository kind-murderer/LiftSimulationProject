using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using LiftSimulationProject.Entities.IEntities;
using LiftSimulationProject.Repositories.IRepository;
using AdditionalSystemConfiguration;

namespace LiftSimulationProject.Entities.Entities
{
    public class Person : IPassanger
    {
        public IPassangerRepository repository { get; set; }
        public bool IsInTransporter { get; set; }
        public bool IsCallButtonPressed { get; set; }
        public PersonConfigData personData { get; set; }

        public Person(IPassangerRepository repository_, PersonConfigData passangerData_)
        {
            IsInTransporter = false;
            IsCallButtonPressed = false;
            
            repository = repository_;
            personData = passangerData_;

            Thread newThread = new Thread(new ThreadStart(RunPassangerLife));
            newThread.Start();
        }


        //there may be not enough space
        public bool TryGetInTransporter()
        {
            if (IsCallButtonPressed)
            {
                return true;
            }
            return false;
        }
        //if we fit in
        public void BeInTransporter()
        {
            IsInTransporter = true;
        }
        
        public bool GetOutOfTransporter()
        {
            if (personData.PersonCurrentFloor == personData.PersonDestinationFloor)
            {
                IsInTransporter = false;
                return true;
            }
            return true;
            
        }

        private void RunPassangerLife()
        {
            
            Thread.Sleep(3000);
            lock (repository.passangers)
            {
                IsCallButtonPressed = true;
            }
            repository.OnPassangersUpdated(); //raise event
            Thread.Sleep(3000);
            
            repository.DeletePassanger(this); //also raises event


            //sleep 3 sek
            //change CallButton + repos.event

            //wait(betterfutureLock)

            //*dreaming about how transport will come for us*
            //*wait in transport*

            // wake up when arrive (we pass wait(betterfutureLock))

            //sleep 5 sek
            //repos.delete 
            //end

        }
    }
}