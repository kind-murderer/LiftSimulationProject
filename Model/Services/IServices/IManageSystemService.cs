using System;
using Repositories.IRepository;
using Entities.IEntities;
using AdditionalSystemConfiguration;

namespace Services.IServices
{
    public interface IManageSystemService
    {

        event Action transporterAwake;
        bool TryAddPerson(PersonConfigData passangerData);
        bool TryStartSystem(LiftConfigData transporterData, PersonConfigData passangerData);
        bool TryStopSystem();
        
        //this service will have synchronized field "transporter"
        
        IPassangerRepository GetPassangerRepository();
        ITransporter GetTransporter();

    }
}
