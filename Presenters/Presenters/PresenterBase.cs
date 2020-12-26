namespace Presenters
{
    public abstract class PresenterBase<T_IView>
    {
        protected T_IView view;
        public PresenterBase(T_IView view)
        {
            this.view = view;
        }
    }
}
