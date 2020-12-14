using System.Windows.Forms;

namespace View
{
    partial class FormMonitoring
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_PassangerDestinationFloor = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_Weight = new System.Windows.Forms.TextBox();
            this.tb_PassangerInitialFloor = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button_Add = new System.Windows.Forms.Button();
            this.button_Stop = new System.Windows.Forms.Button();
            this.panel_AddPerson2 = new System.Windows.Forms.Panel();
            this.lb_IncorrectInputMessage = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel_AddPerson2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 29);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(307, 428);
            this.dataGridView1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Люди в системе:";
            // 
            // tb_PassangerDestinationFloor
            // 
            this.tb_PassangerDestinationFloor.Location = new System.Drawing.Point(0, 81);
            this.tb_PassangerDestinationFloor.Name = "tb_PassangerDestinationFloor";
            this.tb_PassangerDestinationFloor.Size = new System.Drawing.Size(158, 20);
            this.tb_PassangerDestinationFloor.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(-3, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Целевой этаж";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(-3, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Вес";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(-3, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Начальный этаж";
            // 
            // tb_Weight
            // 
            this.tb_Weight.Location = new System.Drawing.Point(0, 120);
            this.tb_Weight.Name = "tb_Weight";
            this.tb_Weight.Size = new System.Drawing.Size(158, 20);
            this.tb_Weight.TabIndex = 14;
            // 
            // tb_PassangerInitialFloor
            // 
            this.tb_PassangerInitialFloor.Location = new System.Drawing.Point(0, 42);
            this.tb_PassangerInitialFloor.Name = "tb_PassangerInitialFloor";
            this.tb_PassangerInitialFloor.Size = new System.Drawing.Size(158, 20);
            this.tb_PassangerInitialFloor.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Добавить человека";
            // 
            // button_Add
            // 
            this.button_Add.Location = new System.Drawing.Point(408, 175);
            this.button_Add.Name = "button_Add";
            this.button_Add.Size = new System.Drawing.Size(75, 23);
            this.button_Add.TabIndex = 19;
            this.button_Add.Text = "Добавить";
            this.button_Add.UseVisualStyleBackColor = true;
            this.button_Add.Click += new System.EventHandler(this.button_Add_Click);
            // 
            // button_Stop
            // 
            this.button_Stop.Location = new System.Drawing.Point(343, 387);
            this.button_Stop.Name = "button_Stop";
            this.button_Stop.Size = new System.Drawing.Size(139, 70);
            this.button_Stop.TabIndex = 20;
            this.button_Stop.Text = "СТОП";
            this.button_Stop.UseVisualStyleBackColor = true;
            this.button_Stop.Click += new System.EventHandler(this.button_Stop_Click);
            // 
            // panel_AddPerson2
            // 
            this.panel_AddPerson2.Controls.Add(this.tb_Weight);
            this.panel_AddPerson2.Controls.Add(this.label2);
            this.panel_AddPerson2.Controls.Add(this.tb_PassangerInitialFloor);
            this.panel_AddPerson2.Controls.Add(this.tb_PassangerDestinationFloor);
            this.panel_AddPerson2.Controls.Add(this.label3);
            this.panel_AddPerson2.Controls.Add(this.label4);
            this.panel_AddPerson2.Controls.Add(this.label5);
            this.panel_AddPerson2.Location = new System.Drawing.Point(325, 29);
            this.panel_AddPerson2.Name = "panel_AddPerson2";
            this.panel_AddPerson2.Size = new System.Drawing.Size(158, 140);
            this.panel_AddPerson2.TabIndex = 21;
            // 
            // lb_IncorrectInputMessage
            // 
            this.lb_IncorrectInputMessage.AutoSize = true;
            this.lb_IncorrectInputMessage.Location = new System.Drawing.Point(325, 209);
            this.lb_IncorrectInputMessage.Name = "lb_IncorrectInputMessage";
            this.lb_IncorrectInputMessage.Size = new System.Drawing.Size(0, 13);
            this.lb_IncorrectInputMessage.TabIndex = 22;
            // 
            // FormMonitoring
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 469);
            this.Controls.Add(this.lb_IncorrectInputMessage);
            this.Controls.Add(this.panel_AddPerson2);
            this.Controls.Add(this.button_Stop);
            this.Controls.Add(this.button_Add);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FormMonitoring";
            this.Text = "Мониторинг";
            this.Closed += new System.EventHandler(this.closeForm_Handler);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel_AddPerson2.ResumeLayout(false);
            this.panel_AddPerson2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;

        private System.Windows.Forms.Panel panel_AddPerson2;

        private System.Windows.Forms.Button button_Add;
        private System.Windows.Forms.Button button_Stop;

        private System.Windows.Forms.TextBox tb_PassangerInitialFloor;
        private System.Windows.Forms.TextBox tb_PassangerDestinationFloor;
        private System.Windows.Forms.TextBox tb_Weight;

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lb_IncorrectInputMessage;
        //private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
    }
}