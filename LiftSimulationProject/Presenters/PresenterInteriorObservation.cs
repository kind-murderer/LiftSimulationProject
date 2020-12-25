using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using View;
using LiftSimulationProject.Services.IServices;

namespace LiftSimulationProject.Presenters
{
    public class PresenterInteriorObservation : PresenterBase<IViewInteriorObservation>
    {
        IInteriorObservationService interiorObservationService;
        IManageSystemService manageSystemService = SystemManageServerAccessHelper.GetManageSystemService();
        public PresenterInteriorObservation(IViewInteriorObservation view, IInteriorObservationService interiorObservationService_) : base(view)
        {
            interiorObservationService = interiorObservationService_;
            interiorObservationService.InteriorUpdated += InteriorUpdatedHandler;
            manageSystemService.transporterAwake += transporterAwakeHandler;
        }

        public delegate PresenterInteriorObservation Factory(IViewInteriorObservation view);

        void InteriorUpdatedHandler()
        {
            view.UpdateInterior(interiorObservationService.GetActiveInteriorCalls(out int transporterCurrentFloor, out bool wasOverloaded),
                transporterCurrentFloor, wasOverloaded);
        }

        void transporterAwakeHandler()
        {
            view.ClickOnMoveButton();
        }
    }
}
