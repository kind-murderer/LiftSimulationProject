using System;
using System.Windows.Forms;
using LiftSimulationProject;
using Presenters;
using LiftSimulationProject.Autofac;
using Autofac;
using System.Threading;

namespace View
{
    public partial class FormInteriorObservation : Form, IViewInteriorObservation
    {
        private PresenterInteriorObservation.Factory presenterFactory { get; set; }

        private PresenterBase<IViewInteriorObservation> presenter;

        private CheckBox[] checkBoxes;

        public FormInteriorObservation(int numberOfFloors)
        {
            InitializeComponent();

            //so there won't be unaesthetic focus on the first checkbox
            this.ActiveControl = lb_CurrentFloor;

            presenterFactory = AutofacContainerProvider.Container.Resolve<PresenterInteriorObservation.Factory>();
            presenter = presenterFactory(this);

            //Generate CheckBoxes
            checkBoxes = new CheckBox[numberOfFloors];
            for (int i = 0; i < numberOfFloors; i++)
            {
                checkBoxes[i] = new CheckBox();
                checkBoxes[i].Appearance = Appearance.Button;
                checkBoxes[i].Checked = false;
                checkBoxes[i].Text = (i + 1).ToString();
            }
            //Generate Table
            int columnCount = 3;
            int rowCount = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(numberOfFloors) / columnCount));
            GenerateTable(columnCount, rowCount, checkBoxes);
        }

        public void UpdateInterior(int[] activeButtons, int transporterCurrentFloor, bool WasOverloaded)
        {
            if (this.IsHandleCreated)
            {
                lb_CurrentFloor.Invoke((Action)(() => lb_CurrentFloor.Text = String.Format($"ТЕКУЩИЙ ЭТАЖ: {transporterCurrentFloor}")));

                if (WasOverloaded)
                {
                    lb_OverloadIndicator.Invoke((Action)(() => lb_OverloadIndicator.Text = "ПЕРЕГРУЗКА"));
                }
                else
                {
                    lb_OverloadIndicator.Invoke((Action)(() => lb_OverloadIndicator.Text = ""));
                }

                foreach (CheckBox checkBox in checkBoxes)
                {
                    checkBox.Invoke((Action)(() => checkBox.Checked = false));
                }
                for (int i = 0; i < activeButtons.Length; i++)
                {
                    CheckBox checkBox = checkBoxes[activeButtons[i] - 1];
                    checkBox.Invoke((Action)(() => checkBox.Checked = true));
                }

            }
        }

        public void ClickOnMoveButton()
        {
            new Thread(() => { 
                checkBox_Move.Invoke((Action)(() => checkBox_Move.Checked = true));
                Thread.Sleep(250);
                checkBox_Move.Invoke((Action)(() => checkBox_Move.Checked = false));
            }).Start();
        }
        private void GenerateTable(int columnCount, int rowCount, CheckBox[] checkBoxes)
        {
            //Clear out the existing controls, we are generating a new table layout
            tableLayoutPanel1.Controls.Clear();

            //Clear out the existing row and column styles
            tableLayoutPanel1.ColumnStyles.Clear();
            tableLayoutPanel1.RowStyles.Clear();

            //Now we will generate the table, setting up the row and column counts first
            tableLayoutPanel1.ColumnCount = columnCount;
            tableLayoutPanel1.RowCount = rowCount;

            for (int i = 0; i < columnCount; i++)
            {
                //First add a column
                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));

                for (int j = 0; j < rowCount; j++)
                {
                    //Next, add a row.  Only do this when once, when creating the first column
                    if (i == 0)
                    {
                        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                    }
                    if (i * rowCount + j  + 1 <= checkBoxes.Length)
                    {
                        tableLayoutPanel1.Controls.Add(checkBoxes[i * rowCount + j], i, j);
                    }
                }
            }
        }

        private void CloseFormHandler(object sender, EventArgs e)
        {
            MyApplicationContext.GetCurrentContext().OnFormClosed(sender, e);
        }

    }
}
