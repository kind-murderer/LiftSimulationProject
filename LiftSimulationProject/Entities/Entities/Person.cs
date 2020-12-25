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
        public bool IsCallingTransporter { get; set; }
        public PersonConfigData personData { get; set; }

        private object runningLifeBlock = new object();

        public Person(IPassangerRepository repository_, PersonConfigData passangerData_)
        {
            IsInTransporter = false;
            IsCallingTransporter = false;
            
            repository = repository_;
            personData = passangerData_;

            Thread newThread = new Thread(new ThreadStart(RunPassangerLife));
            newThread.IsBackground = true;
            newThread.Start();
        }


        public bool ShouldGetInTransporter(LiftConfigData liftData)
        {
            lock (repository.passangers)
            {
                if (IsCallingTransporter && personData.PersonCurrentFloor == liftData.LiftCurrentFloor)
                {
                    //isintransporter changes later by transporter
                    return true;
                }
                return false;
            }
            
        }

        public bool ShouldGetOutOfTransporter()
        {
            lock (repository.passangers)
            {
                if (personData.PersonCurrentFloor == personData.PersonDestinationFloor && IsInTransporter)
                {
                    //isintransporter changes later by transporter
                    lock (runningLifeBlock)
                    {
                        Monitor.Pulse(runningLifeBlock);
                    }
                    return true;
                }
                return false;
            }
            
        }
        private void CallTransporter()
        {
            Console.WriteLine("Try to call");
            lock (repository.passangers)
            {
                IsCallingTransporter = true;
            }
            repository.OnPassangersUpdated(); //raise event
            repository.OnPassangerCalls();
        }
        private void RunPassangerLife()
        {
            Thread.Sleep(5000);
            CallTransporter();
            lock (runningLifeBlock)
            {
                Monitor.Wait(runningLifeBlock);
            }
            
            Thread.Sleep(5000);
            
            repository.DeletePassanger(this); //also raises event

        }

        /*public void ContinueLive()
        {
            
            lock (runningLifeBlock)
            {
                Monitor.Pulse(runningLifeBlock);
            }
        }*/
    }
}