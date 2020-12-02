namespace View
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.tb_LiftInitialFloor = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.label8_ErrorText = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tb_NumberOfFloors = new System.Windows.Forms.TextBox();
            this.label2_NumberOfFloors = new System.Windows.Forms.Label();
            this.button_Start = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel_AddPerson1 = new System.Windows.Forms.Panel();
            this.tb_Weight = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_PassangerInitialFloor = new System.Windows.Forms.TextBox();
            this.tb_PassangerDestinationFloor = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel_InputLiftConfiguration = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel_AddPerson1.SuspendLayout();
            this.panel_InputLiftConfiguration.SuspendLayout();
            this.SuspendLayout();
            // 
            // tb_LiftInitialFloor
            // 
            this.tb_LiftInitialFloor.Location = new System.Drawing.Point(0, 93);
            this.tb_LiftInitialFloor.Name = "tb_LiftInitialFloor";
            this.tb_LiftInitialFloor.Size = new System.Drawing.Size(158, 20);
            this.tb_LiftInitialFloor.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(-3, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Начальный этаж";
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // label8_ErrorText
            // 
            this.label8_ErrorText.AutoSize = true;
            this.label8_ErrorText.Location = new System.Drawing.Point(317, 346);
            this.label8_ErrorText.Name = "label8_ErrorText";
            this.label8_ErrorText.Size = new System.Drawing.Size(176, 13);
            this.label8_ErrorText.TabIndex = 12;
            this.label8_ErrorText.Text = "***местодлявозможнойошибки***";
            this.label8_ErrorText.Click += new System.EventHandler(this.label7_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(283, 408);
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // tb_NumberOfFloors
            // 
            this.tb_NumberOfFloors.Location = new System.Drawing.Point(0, 51);
            this.tb_NumberOfFloors.Name = "tb_NumberOfFloors";
            this.tb_NumberOfFloors.Size = new System.Drawing.Size(158, 20);
            this.tb_NumberOfFloors.TabIndex = 1;
            // 
            // label2_NumberOfFloors
            // 
            this.label2_NumberOfFloors.AutoSize = true;
            this.label2_NumberOfFloors.Location = new System.Drawing.Point(-3, 35);
            this.label2_NumberOfFloors.Name = "label2_NumberOfFloors";
            this.label2_NumberOfFloors.Size = new System.Drawing.Size(142, 13);
            this.label2_NumberOfFloors.TabIndex = 3;
            this.label2_NumberOfFloors.Text = "Количество этажей* (<= N)";
            // 
            // button_Start
            // 
            this.button_Start.Location = new System.Drawing.Point(86, 317);
            this.button_Start.Name = "button_Start";
            this.button_Start.Size = new System.Drawing.Size(139, 70);
            this.button_Start.TabIndex = 14;
            this.button_Start.Text = "СТАРТ";
            this.button_Start.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Введите входные данные";
            // 
            // panel_AddPerson1
            // 
            this.panel_AddPerson1.Controls.Add(this.tb_Weight);
            this.panel_AddPerson1.Controls.Add(this.label4);
            this.panel_AddPerson1.Controls.Add(this.tb_PassangerInitialFloor);
            this.panel_AddPerson1.Controls.Add(this.tb_PassangerDestinationFloor);
            this.panel_AddPerson1.Controls.Add(this.label5);
            this.panel_AddPerson1.Controls.Add(this.label6);
            this.panel_AddPerson1.Controls.Add(this.label7);
            this.panel_AddPerson1.Location = new System.Drawing.Point(320, 178);
            this.panel_AddPerson1.Name = "panel_AddPerson1";
            this.panel_AddPerson1.Size = new System.Drawing.Size(158, 140);
            this.panel_AddPerson1.TabIndex = 22;
            // 
            // tb_Weight
            // 
            this.tb_Weight.Location = new System.Drawing.Point(0, 120);
            this.tb_Weight.Name = "tb_Weight";
            this.tb_Weight.Size = new System.Drawing.Size(158, 20);
            this.tb_Weight.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Добавить человека";
            // 
            // tb_PassangerInitialFloor
            // 
            this.tb_PassangerInitialFloor.Location = new System.Drawing.Point(0, 42);
            this.tb_PassangerInitialFloor.Name = "tb_PassangerInitialFloor";
            this.tb_PassangerInitialFloor.Size = new System.Drawing.Size(158, 20);
            this.tb_PassangerInitialFloor.TabIndex = 13;
            // 
            // tb_PassangerDestinationFloor
            // 
            this.tb_PassangerDestinationFloor.Location = new System.Drawing.Point(0, 81);
            this.tb_PassangerDestinationFloor.Name = "tb_PassangerDestinationFloor";
            this.tb_PassangerDestinationFloor.Size = new System.Drawing.Size(158, 20);
            this.tb_PassangerDestinationFloor.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(-3, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Начальный этаж";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(-3, 65);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Направление";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(-3, 104);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(26, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Вес";
            // 
            // panel_InputLiftConfiguration
            // 
            this.panel_InputLiftConfiguration.Controls.Add(this.label2_NumberOfFloors);
            this.panel_InputLiftConfiguration.Controls.Add(this.tb_NumberOfFloors);
            this.panel_InputLiftConfiguration.Controls.Add(this.label1);
            this.panel_InputLiftConfiguration.Controls.Add(this.tb_LiftInitialFloor);
            this.panel_InputLiftConfiguration.Controls.Add(this.label3);
            this.panel_InputLiftConfiguration.Location = new System.Drawing.Point(320, 35);
            this.panel_InputLiftConfiguration.Name = "panel_InputLiftConfiguration";
            this.panel_InputLiftConfiguration.Size = new System.Drawing.Size(158, 114);
            this.panel_InputLiftConfiguration.TabIndex = 23;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 432);
            this.Controls.Add(this.panel_InputLiftConfiguration);
            this.Controls.Add(this.panel_AddPerson1);
            this.Controls.Add(this.button_Start);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label8_ErrorText);
            this.Name = "Form1";
            this.Text = "Запуск системы";
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel_AddPerson1.ResumeLayout(false);
            this.panel_AddPerson1.PerformLayout();
            this.panel_InputLiftConfiguration.ResumeLayout(false);
            this.panel_InputLiftConfiguration.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
       
        private System.IO.FileSystemWatcher fileSystemWatcher1;

        private System.Windows.Forms.PictureBox pictureBox1;

        private System.Windows.Forms.Panel panel_InputLiftConfiguration;
        private System.Windows.Forms.Panel panel_AddPerson1;

        private System.Windows.Forms.Button button_Start;

        private System.Windows.Forms.TextBox tb_NumberOfFloors;
        private System.Windows.Forms.TextBox tb_LiftInitialFloor;
        private System.Windows.Forms.TextBox tb_PassangerInitialFloor;
        private System.Windows.Forms.TextBox tb_PassangerDestinationFloor;
        private System.Windows.Forms.TextBox tb_Weight;

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2_NumberOfFloors;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8_ErrorText;

    }
}

