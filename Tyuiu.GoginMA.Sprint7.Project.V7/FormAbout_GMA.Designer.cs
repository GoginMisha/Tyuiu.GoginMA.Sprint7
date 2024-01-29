
namespace Tyuiu.GoginMA.Sprint7.Project.V7
{
    partial class FormAbout_GMA
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
            this.textBoxAbout_GMA = new System.Windows.Forms.TextBox();
            this.groupBoxAbout_GMA = new System.Windows.Forms.GroupBox();
            this.groupBoxAbout_GMA.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxAbout_GMA
            // 
            this.textBoxAbout_GMA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxAbout_GMA.Location = new System.Drawing.Point(3, 16);
            this.textBoxAbout_GMA.Multiline = true;
            this.textBoxAbout_GMA.Name = "textBoxAbout_GMA";
            this.textBoxAbout_GMA.ReadOnly = true;
            this.textBoxAbout_GMA.Size = new System.Drawing.Size(351, 105);
            this.textBoxAbout_GMA.TabIndex = 0;
            this.textBoxAbout_GMA.Text = "Разработчик: Гогин М. А.\r\nГруппа: АСОиУБ-23-1\r\n\r\nПрограмма разработана в рамках п" +
    "роявления своих навыков в языке C#\r\n\r\nВнутреннее имя: Tyuiu.GoginMA.Sprint7.Proj" +
    "ect.V7\r\n";
            // 
            // groupBoxAbout_GMA
            // 
            this.groupBoxAbout_GMA.Controls.Add(this.textBoxAbout_GMA);
            this.groupBoxAbout_GMA.Location = new System.Drawing.Point(12, 12);
            this.groupBoxAbout_GMA.Name = "groupBoxAbout_GMA";
            this.groupBoxAbout_GMA.Size = new System.Drawing.Size(357, 124);
            this.groupBoxAbout_GMA.TabIndex = 1;
            this.groupBoxAbout_GMA.TabStop = false;
            // 
            // FormAbout_GMA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 148);
            this.Controls.Add(this.groupBoxAbout_GMA);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAbout_GMA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "О программе";
            this.groupBoxAbout_GMA.ResumeLayout(false);
            this.groupBoxAbout_GMA.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxAbout_GMA;
        private System.Windows.Forms.GroupBox groupBoxAbout_GMA;
    }
}