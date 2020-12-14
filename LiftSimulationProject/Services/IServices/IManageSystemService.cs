using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiftSimulationProject.Repositories.IRepository;
using LiftSimulationProject.Entities.IEntities;
using AdditionalSystemConfiguration;

namespace LiftSimulationProject.Services.IServices
{
    public interface IManageSystemService
    {
   

        bool TryAddPerson(PersonConfigData passangerData);
        bool TryStartSystem(LiftConfigData transporterData, PersonConfigData passangerData);
        bool TryStopSystem();
        
        //this service will have synchronized field "transporter"
        
        IPassangerRepository GetPassangerRepository();
        ITransporter GetTransporter();

    }
}
