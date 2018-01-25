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
            this.notifyIconJanelaPrincipal = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStripMenuBalao = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemFechar = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripMenuBalao.SuspendLayout();
            this.SuspendLayout();
            // 
            // timerTarefas
            // 
            this.timerTarefas.Enabled = true;
            this.timerTarefas.Interval = 60000;
            this.timerTarefas.Tick += new System.EventHandler(this.timerTarefas_Tick);
            // 
            // notifyIconJanelaPrincipal
            // 
            this.notifyIconJanelaPrincipal.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIconJanelaPrincipal.BalloonTipText = "Crm SAERP";
            this.notifyIconJanelaPrincipal.BalloonTipTitle = "SAERP";
            this.notifyIconJanelaPrincipal.ContextMenuStrip = this.contextMenuStripMenuBalao;
            this.notifyIconJanelaPrincipal.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIconJanelaPrincipal.Icon")));
            this.notifyIconJanelaPrincipal.Visible = true;
            this.notifyIconJanelaPrincipal.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIconJanelaPrincipal_MouseClick);
            this.notifyIconJanelaPrincipal.MouseMove += new System.Windows.Forms.MouseEventHandler(this.notifyIconJanelaPrincipal_MouseMove);
            // 
            // contextMenuStripMenuBalao
            // 
            this.contextMenuStripMenuBalao.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemFechar});
            this.contextMenuStripMenuBalao.Name = "contextMenuStripMenuBalao";
            this.contextMenuStripMenuBalao.Size = new System.Drawing.Size(153, 48);
            // 
            // toolStripMenuItemFechar
            // 
            this.toolStripMenuItemFechar.Name = "toolStripMenuItemFechar";
            this.toolStripMenuItemFechar.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItemFechar.Text = "Fechar";
            this.toolStripMenuItemFechar.Click += new System.EventHandler(this.toolStripMenuItemFechar_Click);
            // 
            // FormJanela
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 304);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormJanela";
            this.Text = "Principal";
            this.Load += new System.EventHandler(this.FormJanela_Load);
            this.contextMenuStripMenuBalao.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timerTarefas;
        private System.Windows.Forms.NotifyIcon notifyIconJanelaPrincipal;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripMenuBalao;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemFechar;
    }
}