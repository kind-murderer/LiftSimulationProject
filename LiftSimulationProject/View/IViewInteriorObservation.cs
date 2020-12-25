using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View
{
    public interface IViewInteriorObservation
    {
        void UpdateInterior(int[] activeButtons, int transporterCurrentFloor, bool WasOverloaded);
        void ClickOnMoveButton();
    }
}
