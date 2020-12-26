namespace View
{
    public interface IViewInteriorObservation
    {
        void UpdateInterior(int[] activeButtons, int transporterCurrentFloor, bool WasOverloaded);
        void ClickOnMoveButton();
    }
}
