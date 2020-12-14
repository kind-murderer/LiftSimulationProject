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

namespace LiftSimulationProject.Services.Services
{
    class ManageSystemService : IManageSystemService
    {
        // 1 for the whole programm


        private IPassangerRepository repository;

        private ITransporter transporter;


        public ManageSystemService(IPassangerRepository repository_)
        {
            repository = repository_;
        }

        public bool TryStartSystem(LiftConfigData transporterData, PersonConfigData passangerData)
        {

            if (TryAddPerson(passangerData))
            {
                CreateTransporter(transporterData);
                return true;
            }
            return false;
        }
        public bool TryStopSystem()
        {
            lock (repository.passangers)
            {
                return !repository.passangers.Any();
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
