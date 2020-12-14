﻿using System;
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
using Autofac;
using LiftSimulationProject.Autofac;
using LiftSimulationProject.Presenters;

namespace View
{
    public partial class FormMonitoring : Form, IViewMonitoring
    {
        public event Action StopSystem;
        public event Action AddPassanger;
        public string PersonInitialFloor => tb_PassangerInitialFloor.Text;
        public string PersonDestinationFloor => tb_PassangerDestinationFloor.Text;
        public string PersonWeight => tb_Weight.Text;

        private PresenterMonitoring.Factory presenterFactory { get; set; }

        private PresenterBase<IViewMonitoring> presenter;

        public FormMonitoring()
        {
            InitializeComponent();

            dataGridView1.DataBindingComplete += DataBindingCompleteHandler;

            var container = AutofacBuilder.Build();
            using (var scope = container.BeginLifetimeScope())
            {
                presenterFactory = scope.Resolve<PresenterMonitoring.Factory>();
                presenter = presenterFactory(this);
            }
        }

        public void providePersonData(out string PersonInitialFloor, out string PersonDestinationFloor, out string PersonWeight)
        {
            PersonInitialFloor = tb_PassangerInitialFloor.Text;
            PersonDestinationFloor = tb_PassangerDestinationFloor.Text;
            PersonWeight = tb_Weight.Text;
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

        public void ShowCurrentPassangerStatuses(List<string> statuses)
        {
            //rebind
            
            if (this.IsHandleCreated)
            {
                dataGridView1.Invoke((Action)(() => dataGridView1.DataSource = statuses.Select(x => new { Person_Status = x }).ToList()));
            }
            
            

        }
        private void DataBindingCompleteHandler(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        }
        private void closeForm_Handler(object sender, EventArgs e)
        {
            MyApplicationContext.GetCurrentContext().OnFormClosed(sender, e);
        }

        private void button_Add_Click(object sender, EventArgs e)
        {
            AddPassanger?.Invoke();
        }

        private void button_Stop_Click(object sender, EventArgs e)
        {
            StopSystem?.Invoke();
        }
    }
}
