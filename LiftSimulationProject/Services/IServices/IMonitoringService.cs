using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiftSimulationProject.Services.IServices
{
    public interface IMonitoringService
    {
        event Action PassangerStatusesUpdated;

        List<string> GetPassangerStatusesList();
    }
}
