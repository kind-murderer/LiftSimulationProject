using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using View;
using LiftSimulationProject;

namespace View
{
    public partial class FormMonitoring : Form//, IViewMonitoring
    {
        public FormMonitoring()
        {
            InitializeComponent();
        }



        private void closeFormHandler(object sender, EventArgs e)
        {
            MyApplicationContext.GetCurrentContext().OnFormClosed(sender, e);
        }
    }
}
