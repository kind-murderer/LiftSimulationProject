using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiftSimulationProject.Services.IServices
{
    public interface IInteriorObservationService
    {
        event Action InteriorUpdated;

        int[] GetActiveInteriorCalls(out int transporterCurrentFloor, out bool wasOverloaded);
    }
}
