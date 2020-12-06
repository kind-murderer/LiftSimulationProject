using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LiftSimulationProject.Autofac;
using Autofac;
using LiftSimulationProject.Presenters;
using LiftSimulationProject;
using AdditionalSystemConfiguration;

namespace View
{
    public partial class FormStartUp : Form, IViewStartUp
    {
        public event Action StartSystem;

        /*public PersonConfigData PersonData
        {
            get => new PersonConfigData
            {
                PersonInitialFloor = tb_PassangerInitialFloor.Text,
                PersonDestinationFloor = tb_PassangerDestinationFloor.Text,
                PersonWeight = tb_Weight.Text
            };
            set {
                tb_PassangerInitialFloor.Text = value.PersonInitialFloor;
                tb_PassangerDestinationFloor.Text = value.PersonDestinationFloor;
                tb_Weight.Text = value.PersonWeight;
            }            
        }

        public LiftConfigData LiftData
        {
            get => new LiftConfigData
            {
                InitNumberOfFloor = tb_NumberOfFloors.Text,
                LiftInitialFloor = tb_LiftInitialFloor.Text
            };
            set
            {
                tb_NumberOfFloors.Text = value.InitNumberOfFloor;
                tb_LiftInitialFloor.Text = value.LiftInitialFloor;
            }
        }*/
        //InitNumberOfFloor => tb_NumberOfFloors.Text;
        public string InitNumberOfFloor => tb_NumberOfFloors.Text;
        public string LiftInitialFloor => tb_LiftInitialFloor.Text;

        public string PersonInitialFloor => tb_PassangerInitialFloor.Text;
        public string PersonDestinationFloor => tb_PassangerDestinationFloor.Text;
        public string PersonWeight => tb_Weight.Text;


        private PresenterStartUp.Factory presenterFactory { get; set; }

        private PresenterBase<IViewStartUp> presenter;

        public FormStartUp()
        {
            InitializeComponent();

            var container = AutofacBuilder.Build();
            using (var scope = container.BeginLifetimeScope())
            {
                presenterFactory = scope.Resolve<PresenterStartUp.Factory>();
                presenter = presenterFactory(this);
            }

            
        }

        public void providePersonData(out string PersonInitialFloor, out string PersonDestinationFloor, out string PersonWeight)
        {
            PersonInitialFloor = tb_PassangerInitialFloor.Text;
            PersonDestinationFloor = tb_PassangerDestinationFloor.Text;
            PersonWeight = tb_Weight.Text;
        }
        public void provideLiftData(out string InitNumberOfFloor, out string LiftInitialFloor)
        {
            InitNumberOfFloor = tb_NumberOfFloors.Text;
            LiftInitialFloor = tb_LiftInitialFloor.Text;
        }

        public void showIncorrectInputMessage(string message)
        {
            lb_IncorrectInputMessage.Text = message;
        }

        public void showCriticalErrorMessage(string message)
        {
            MessageBox.Show(
                message,
                "Критическая ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly);
        }


        private void button_Start_Click(object sender, EventArgs e)
        {
            StartSystem?.Invoke();
        }

        private void closeFormHandler(object sender, EventArgs e)
        {
            MyApplicationContext.GetCurrentContext().OnFormClosed(sender, e);
        }
    }
}
