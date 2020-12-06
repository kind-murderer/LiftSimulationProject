using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiftSimulationProject.Presenters
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
