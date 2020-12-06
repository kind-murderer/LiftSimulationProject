using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LiftSimulationProject;

namespace View
{
    public partial class FormInteriorObservation : Form//, IViewInteriorObservation
    {
        public FormInteriorObservation()
        {
            InitializeComponent();
        }


        private void closeFormHandler(object sender, EventArgs e)
        {
            MyApplicationContext.GetCurrentContext().OnFormClosed(sender, e);
        }
    }
}
