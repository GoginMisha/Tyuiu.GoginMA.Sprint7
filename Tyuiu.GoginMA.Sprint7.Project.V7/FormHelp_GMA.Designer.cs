
namespace Tyuiu.GoginMA.Sprint7.Project.V7
{
    partial class FormHelp_GMA
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormHelp_GMA));
            this.groupBoxHelp_GMA = new System.Windows.Forms.GroupBox();
            this.textBoxHelp_GMA = new System.Windows.Forms.TextBox();
            this.groupBoxHelp_GMA.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxHelp_GMA
            // 
            this.groupBoxHelp_GMA.Controls.Add(this.textBoxHelp_GMA);
            this.groupBoxHelp_GMA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxHelp_GMA.Location = new System.Drawing.Point(0, 0);
            this.groupBoxHelp_GMA.Name = "groupBoxHelp_GMA";
            this.groupBoxHelp_GMA.Size = new System.Drawing.Size(480, 120);
            this.groupBoxHelp_GMA.TabIndex = 0;
            this.groupBoxHelp_GMA.TabStop = false;
            // 
            // textBoxHelp_GMA
            // 
            this.textBoxHelp_GMA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxHelp_GMA.Location = new System.Drawing.Point(3, 16);
            this.textBoxHelp_GMA.Multiline = true;
            this.textBoxHelp_GMA.Name = "textBoxHelp_GMA";
            this.textBoxHelp_GMA.ReadOnly = true;
            this.textBoxHelp_GMA.Size = new System.Drawing.Size(474, 101);
            this.textBoxHelp_GMA.TabIndex = 0;
            this.textBoxHelp_GMA.Text = resources.GetString("textBoxHelp_GMA.Text");
            // 
            // FormHelp_GMA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 120);
            this.Controls.Add(this.groupBoxHelp_GMA);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormHelp_GMA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Справка";
            this.groupBoxHelp_GMA.ResumeLayout(false);
            this.groupBoxHelp_GMA.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxHelp_GMA;
        private System.Windows.Forms.TextBox textBoxHelp_GMA;
    }
}