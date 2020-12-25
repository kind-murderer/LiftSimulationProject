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

        public event Action transporterAwake;
        private IPassangerRepository repository;

        private ITransporter transporter;

        private object runningSystemLock = new object();
        private bool keepRunning = true;


        public ManageSystemService(IPassangerRepository repository_)
        {
            repository = repository_;
            repository.passangerCalls += PassangerCallsHandler;
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
            transporter.OnInteriorUpdated();
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
                }
                //invoke update event
                repository.OnPassangersUpdated();
                lock (transporter)
                {
                    lock (repository.passangers)
                    {
                        passangersToGetIn = repository.passangers.FindAll(
                            passanger => passanger.ShouldGetInTransporter(transporter.liftData));
                    }
                    transporter.Load(passangersToGetIn);
                }
                transporter.OnInteriorUpdated();

                lock (repository.passangers)
                {
                    passangersInTransporter = repository.passangers.FindAll(
                        passanger => passanger.IsInTransporter);
                }
            }

        }
        public bool TryStartSystem(LiftConfigData transporterData, PersonConfigData passangerData)
        {

            if (TryAddPerson(passangerData))
            {
                CreateTransporter(transporterData);
                CounterService.StartCountingTime();
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
                if (!repository.passangers.FindAll(passanger => passanger.IsInTransporter).Any())
                {
                    CounterService.StopCountingTime();
                    return true;
                }
                else
                {
                    return false;
                }
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
                
        public void PassangerCallsHandler()
        {
            lock (runningSystemLock)
            {
                Monitor.Pulse(runningSystemLock);
                transporterAwake?.Invoke();
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
