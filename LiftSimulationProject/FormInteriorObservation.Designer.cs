namespace View
{
    partial class FormInteriorObservation
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
            this.lb_CurrentFloor = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lb_OverloadIndicator = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.checkBox_Move = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lb_CurrentFloor
            // 
            this.lb_CurrentFloor.AutoSize = true;
            this.lb_CurrentFloor.Location = new System.Drawing.Point(169, 17);
            this.lb_CurrentFloor.Name = "lb_CurrentFloor";
            this.lb_CurrentFloor.Size = new System.Drawing.Size(97, 13);
            this.lb_CurrentFloor.TabIndex = 0;
            this.lb_CurrentFloor.Text = "ТЕКУЩИЙ ЭТАЖ";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lb_CurrentFloor);
            this.panel1.Location = new System.Drawing.Point(31, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(421, 45);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lb_OverloadIndicator);
            this.panel2.Location = new System.Drawing.Point(345, 88);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(142, 38);
            this.panel2.TabIndex = 3;
            // 
            // lb_OverloadIndicator
            // 
            this.lb_OverloadIndicator.AutoSize = true;
            this.lb_OverloadIndicator.Location = new System.Drawing.Point(12, 11);
            this.lb_OverloadIndicator.Name = "lb_OverloadIndicator";
            this.lb_OverloadIndicator.Size = new System.Drawing.Size(121, 13);
            this.lb_OverloadIndicator.TabIndex = 0;
            this.lb_OverloadIndicator.Text = "индикатор перегрузки";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 88);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(327, 339);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // checkBox_Move
            // 
            this.checkBox_Move.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox_Move.AutoSize = true;
            this.checkBox_Move.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBox_Move.Location = new System.Drawing.Point(398, 369);
            this.checkBox_Move.Name = "checkBox_Move";
            this.checkBox_Move.Size = new System.Drawing.Size(41, 23);
            this.checkBox_Move.TabIndex = 5;
            this.checkBox_Move.Text = "ХОД";
            this.checkBox_Move.UseVisualStyleBackColor = true;
            // 
            // FormInteriorObservation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 439);
            this.Controls.Add(this.checkBox_Move);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FormInteriorObservation";
            this.Text = "Наблюдение за лифтом изнутри";
            this.Closed += new System.EventHandler(this.CloseFormHandler);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_CurrentFloor;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lb_OverloadIndicator;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.CheckBox checkBox_Move;
    }
}