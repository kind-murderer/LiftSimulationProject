using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiftSimulationProject.Repositories.IRepository;
using LiftSimulationProject.Entities.IEntities;
using LiftSimulationProject.Entities.Entities;
using LiftSimulationProject.Services.IServices;
using AdditionalSystemConfiguration;
using LiftSimulationProject.Autofac;
using Autofac;
using System.Threading;

namespace LiftSimulationProject.Services.Services
{
    class ManageSystemService : IManageSystemService
    {
        // 1 for the whole programm


        private IPassangerRepository repository;

        private ITransporter transporter;

        private object runningSystemLock = new object();
        private bool keepRunning = true;


        public ManageSystemService(IPassangerRepository repository_)
        {
            repository = repository_;
            repository.passangerCalls += passangerCallsHandler;
        }

        void RunSystem()
        {
            List<IPassanger> passangersToGetOut = new List<IPassanger>();
            List<IPassanger> passangersToGetIn = new List<IPassanger>();
            List<IPassanger> passangersInTransporter = new List<IPassanger>();
            bool choosingSucceed = false;


            //choose direction
            //move (pass new list with all passangers that isintransporter)
            //sleep
            //looking for guys to exit
            //update rep
            //
            //looking for guys to get in
            //
            while (keepRunning)
            {
                //choosing direction
                lock (transporter)
                {
                    //if there no call at all - wait (don't forget to UNLOCK transporter and passangers)
                    choosingSucceed = transporter.ChooseDeriction(repository.passangers, passangersInTransporter);
                }
                if (!choosingSucceed)
                {
                    lock (runningSystemLock)
                    {
                        Monitor.Wait(runningSystemLock); //wait for passanger calls
                    }
                }

                //move
                lock (transporter)
                {
                    transporter.Move(passangersInTransporter);
                    Console.WriteLine("Moved");
                }
                
                Thread.Sleep(2000);

                lock (transporter)
                {
                    lock (repository.passangers)
                    {
                        passangersToGetOut = repository.passangers.FindAll(
                                passanger => passanger.ShouldGetOutOfTransporter());
                    }
                    transporter.Offload(passangersToGetOut);

                    //invoke update event
                    repository.OnPassangersUpdated();

                    lock (repository.passangers)
                    {
                        passangersToGetIn = repository.passangers.FindAll(
                            passanger => passanger.ShouldGetInTransporter(transporter.liftData));
                    }
                    transporter.Load(passangersToGetIn);

                    lock (repository.passangers)
                    {
                        passangersInTransporter = repository.passangers.FindAll(
                            passanger => passanger.IsInTransporter);
                    }

                }
            }

        }
        public bool TryStartSystem(LiftConfigData transporterData, PersonConfigData passangerData)
        {

            if (TryAddPerson(passangerData))
            {
                CreateTransporter(transporterData);
                Thread newThread = new Thread(new ThreadStart(RunSystem));
                newThread.IsBackground = true;
                newThread.Start();
                return true;
            }
            return false;
        }
        public bool TryStopSystem()
        {
            lock (repository.passangers)
            {
                return !repository.passangers.FindAll(passanger => passanger.IsInTransporter).Any();
            }
        }

        public bool TryAddPerson(PersonConfigData passangerData)
        {
            return repository.AddPassanger(passangerData); //true if success
        }
        private void CreateTransporter(LiftConfigData liftData)
        {
            transporter = ContainerProvider.Container.Resolve<ITransporter>(
                new TypedParameter(typeof(LiftConfigData), liftData));
        }
                
        public void passangerCallsHandler()
        {
            lock (runningSystemLock)
            {
                Monitor.Pulse(runningSystemLock);
            }
        }

        public IPassangerRepository GetPassangerRepository()
        {
            return repository;
        }
        public ITransporter GetTransporter()
        {
            return transporter;
        }

    }
}
