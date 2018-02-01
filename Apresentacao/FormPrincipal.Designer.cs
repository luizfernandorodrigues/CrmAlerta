namespace Apresentacao
{
    partial class FormPrincipal
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPrincipal));
            this.timerAlerta = new System.Windows.Forms.Timer(this.components);
            this.notifyIconAlerta = new System.Windows.Forms.NotifyIcon(this.components);
            this.buttonNaoMais = new System.Windows.Forms.Button();
            this.buttonUmaHora = new System.Windows.Forms.Button();
            this.buttonUmDia = new System.Windows.Forms.Button();
            this.buttonUmaSemana = new System.Windows.Forms.Button();
            this.buttonUmMes = new System.Windows.Forms.Button();
            this.buttonDespertar = new System.Windows.Forms.Button();
            this.labelDespertar = new System.Windows.Forms.Label();
            this.labelData = new System.Windows.Forms.Label();
            this.labelHora = new System.Windows.Forms.Label();
            this.txtMensagem = new System.Windows.Forms.TextBox();
            this.toolTipIcone = new System.Windows.Forms.ToolTip(this.components);
            this.maskedTextBoxHora = new System.Windows.Forms.MaskedTextBox();
            this.dateTimePickerData = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // timerAlerta
            // 
            this.timerAlerta.Enabled = true;
            this.timerAlerta.Interval = 60000;
            // 
            // notifyIconAlerta
            // 
            this.notifyIconAlerta.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIconAlerta.BalloonTipTitle = "Saerp Informa";
            this.notifyIconAlerta.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIconAlerta.Icon")));
            this.notifyIconAlerta.Visible = true;
            // 
            // buttonNaoMais
            // 
            this.buttonNaoMais.Location = new System.Drawing.Point(89, 392);
            this.buttonNaoMais.Name = "buttonNaoMais";
            this.buttonNaoMais.Size = new System.Drawing.Size(63, 23);
            this.buttonNaoMais.TabIndex = 1;
            this.buttonNaoMais.Text = "Não Mais";
            this.buttonNaoMais.UseVisualStyleBackColor = true;
            this.buttonNaoMais.Click += new System.EventHandler(this.buttonNaoMais_Click);
            // 
            // buttonUmaHora
            // 
            this.buttonUmaHora.Location = new System.Drawing.Point(160, 392);
            this.buttonUmaHora.Name = "buttonUmaHora";
            this.buttonUmaHora.Size = new System.Drawing.Size(75, 23);
            this.buttonUmaHora.TabIndex = 2;
            this.buttonUmaHora.Text = "Uma Hora";
            this.buttonUmaHora.UseVisualStyleBackColor = true;
            this.buttonUmaHora.Click += new System.EventHandler(this.buttonUmaHora_Click);
            // 
            // buttonUmDia
            // 
            this.buttonUmDia.Location = new System.Drawing.Point(243, 392);
            this.buttonUmDia.Name = "buttonUmDia";
            this.buttonUmDia.Size = new System.Drawing.Size(75, 23);
            this.buttonUmDia.TabIndex = 3;
            this.buttonUmDia.Text = "Um Dia";
            this.buttonUmDia.UseVisualStyleBackColor = true;
            this.buttonUmDia.Click += new System.EventHandler(this.buttonUmDia_Click);
            // 
            // buttonUmaSemana
            // 
            this.buttonUmaSemana.Location = new System.Drawing.Point(326, 392);
            this.buttonUmaSemana.Name = "buttonUmaSemana";
            this.buttonUmaSemana.Size = new System.Drawing.Size(87, 23);
            this.buttonUmaSemana.TabIndex = 4;
            this.buttonUmaSemana.Text = "Uma Semana";
            this.buttonUmaSemana.UseVisualStyleBackColor = true;
            this.buttonUmaSemana.Click += new System.EventHandler(this.buttonUmaSemana_Click);
            // 
            // buttonUmMes
            // 
            this.buttonUmMes.Location = new System.Drawing.Point(421, 392);
            this.buttonUmMes.Name = "buttonUmMes";
            this.buttonUmMes.Size = new System.Drawing.Size(75, 23);
            this.buttonUmMes.TabIndex = 5;
            this.buttonUmMes.Text = "Um Mês";
            this.buttonUmMes.UseVisualStyleBackColor = true;
            this.buttonUmMes.Click += new System.EventHandler(this.buttonUmMes_Click);
            // 
            // buttonDespertar
            // 
            this.buttonDespertar.Location = new System.Drawing.Point(731, 390);
            this.buttonDespertar.Name = "buttonDespertar";
            this.buttonDespertar.Size = new System.Drawing.Size(89, 23);
            this.buttonDespertar.TabIndex = 8;
            this.buttonDespertar.Text = "Redespertar";
            this.buttonDespertar.UseVisualStyleBackColor = true;
            this.buttonDespertar.Click += new System.EventHandler(this.buttonDespertar_Click);
            // 
            // labelDespertar
            // 
            this.labelDespertar.AutoSize = true;
            this.labelDespertar.Location = new System.Drawing.Point(9, 397);
            this.labelDespertar.Name = "labelDespertar";
            this.labelDespertar.Size = new System.Drawing.Size(74, 13);
            this.labelDespertar.TabIndex = 1;
            this.labelDespertar.Text = "Redespertar ?";
            // 
            // labelData
            // 
            this.labelData.AutoSize = true;
            this.labelData.Location = new System.Drawing.Point(496, 397);
            this.labelData.Name = "labelData";
            this.labelData.Size = new System.Drawing.Size(33, 13);
            this.labelData.TabIndex = 7;
            this.labelData.Text = "Data:";
            // 
            // labelHora
            // 
            this.labelHora.AutoSize = true;
            this.labelHora.Location = new System.Drawing.Point(637, 397);
            this.labelHora.Name = "labelHora";
            this.labelHora.Size = new System.Drawing.Size(33, 13);
            this.labelHora.TabIndex = 10;
            this.labelHora.Text = "Hora:";
            // 
            // txtMensagem
            // 
            this.txtMensagem.Location = new System.Drawing.Point(2, 2);
            this.txtMensagem.Multiline = true;
            this.txtMensagem.Name = "txtMensagem";
            this.txtMensagem.ReadOnly = true;
            this.txtMensagem.Size = new System.Drawing.Size(818, 384);
            this.txtMensagem.TabIndex = 0;
            // 
            // maskedTextBoxHora
            // 
            this.maskedTextBoxHora.Location = new System.Drawing.Point(676, 392);
            this.maskedTextBoxHora.Mask = "##:##";
            this.maskedTextBoxHora.Name = "maskedTextBoxHora";
            this.maskedTextBoxHora.Size = new System.Drawing.Size(49, 20);
            this.maskedTextBoxHora.TabIndex = 12;
            this.maskedTextBoxHora.ValidatingType = typeof(System.DateTime);
            // 
            // dateTimePickerData
            // 
            this.dateTimePickerData.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerData.Location = new System.Drawing.Point(535, 393);
            this.dateTimePickerData.Name = "dateTimePickerData";
            this.dateTimePickerData.Size = new System.Drawing.Size(87, 20);
            this.dateTimePickerData.TabIndex = 13;
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 424);
            this.Controls.Add(this.dateTimePickerData);
            this.Controls.Add(this.maskedTextBoxHora);
            this.Controls.Add(this.txtMensagem);
            this.Controls.Add(this.labelHora);
            this.Controls.Add(this.labelData);
            this.Controls.Add(this.labelDespertar);
            this.Controls.Add(this.buttonDespertar);
            this.Controls.Add(this.buttonUmMes);
            this.Controls.Add(this.buttonUmaSemana);
            this.Controls.Add(this.buttonUmDia);
            this.Controls.Add(this.buttonUmaHora);
            this.Controls.Add(this.buttonNaoMais);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormPrincipal_FormClosed);
            this.Load += new System.EventHandler(this.FormPrincipal_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timerAlerta;
        private System.Windows.Forms.NotifyIcon notifyIconAlerta;
        private System.Windows.Forms.Button buttonNaoMais;
        private System.Windows.Forms.Button buttonUmaHora;
        private System.Windows.Forms.Button buttonUmDia;
        private System.Windows.Forms.Button buttonUmaSemana;
        private System.Windows.Forms.Button buttonUmMes;
        private System.Windows.Forms.Button buttonDespertar;
        private System.Windows.Forms.Label labelDespertar;
        private System.Windows.Forms.Label labelData;
        private System.Windows.Forms.Label labelHora;
        private System.Windows.Forms.TextBox txtMensagem;
        private System.Windows.Forms.ToolTip toolTipIcone;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxHora;
        private System.Windows.Forms.DateTimePicker dateTimePickerData;
    }
}

