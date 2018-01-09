namespace Apresentacao
{
    partial class FormJanela
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormJanela));
            this.timerTarefas = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // timerTarefas
            // 
            this.timerTarefas.Enabled = true;
            this.timerTarefas.Interval = 60000;
            this.timerTarefas.Tick += new System.EventHandler(this.timerTarefas_Tick);
            // 
            // FormJanela
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 261);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormJanela";
            this.Text = "Principal";
            this.Load += new System.EventHandler(this.FormJanela_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timerTarefas;
    }
}