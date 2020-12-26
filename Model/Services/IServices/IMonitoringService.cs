using System;
using System.Collections.Generic;

namespace Services.IServices
{
    public interface IMonitoringService
    {
        event Action PassangerStatusesUpdated;

        List<string> GetPassangerStatusesList();
    }
}
