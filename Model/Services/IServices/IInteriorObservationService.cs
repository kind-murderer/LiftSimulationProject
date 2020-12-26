using System;

namespace Services.IServices
{
    public interface IInteriorObservationService
    {
        event Action InteriorUpdated;

        int[] GetActiveInteriorCalls(out int transporterCurrentFloor, out bool wasOverloaded);
    }
}
