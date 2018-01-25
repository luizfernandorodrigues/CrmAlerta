﻿
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using AcessaDados;
using Negocio;
using ObjetoTransferencia;

namespace Apresentacao
{
    public partial class FormPrincipal : Form
    {

        R03Agendamentos r03 = new R03Agendamentos();
        private string dataInicial = DateTime.Now.ToString();


        public FormPrincipal(R03Agendamentos r03Agendamentos)
        {
            InitializeComponent();
            this.r03 = r03Agendamentos;
        }
        /// <summary>
        /// Evento Load do form que apresenta as tarefas agendadas
        /// apresenta a mensagem da tarefa e a data e hora da mesma junto com o titulo do form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(r03.Contato.Trim()))
            {
                r03.Contato = "Nenhum Contato Encontrado!";
            }
            if (string.IsNullOrEmpty(r03.Fone.Trim()))
            {
                r03.Fone = "Nenhum Telefone Encontrado!";
            }
            if (string.IsNullOrEmpty(r03.Celular.Trim()))
            {
                r03.Celular = "Nenhum Celular Encontrado!";
            }
            string mensagem = string.Format("Código: " + r03.CodigoParceiro.Trim() + "{0}", Environment.NewLine);
            mensagem += string.Format("Contato: " + r03.Contato.Trim() + "{0}", Environment.NewLine);
            mensagem += string.Format("Celular: " + r03.Celular.Trim() + "{0}", Environment.NewLine);
            mensagem += string.Format("Fone: " + r03.Fone.Trim() + "{0}", Environment.NewLine);
            mensagem += "Mensagem: " + r03.R03_003_m;
            txtMensagem.Text = mensagem;

            this.Text = r03.NomePaceiro;
            this.maskedTextBoxData.Text = dataInicial;
            notifyIconAlerta.BalloonTipText = r03.NomePaceiro;
            notifyIconAlerta.Visible = true;
            notifyIconAlerta.ShowBalloonTip(10000);
            notifyIconAlerta.Visible = false;
        }
        /// <summary>
        /// função botão para não despertar mais a tarefa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonNaoMais_Click(object sender, EventArgs e)
        {
            R03Negocio negocio = new R03Negocio();
            try
            {
                negocio.naoDesperta(r03.Ukey, negocio.user_ukey(Util.usuario()));
                MessageBox.Show("Tarefa Fechada com Sucesso!", "Saerp Informa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não Foi Possivel Fechar a Tarefa!\n" + ex.Message, "Saerp Informa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        /// <summary>
        /// função botão adiciona uma hora a mais na tarefa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonUmaHora_Click(object sender, EventArgs e)
        {
            R03Negocio negocio = new R03Negocio();
            try
            {
                negocio.despertaUmaHoraDepois(r03.Ukey, negocio.user_ukey(Util.usuario()));
                MessageBox.Show("Tarefa Reagendada com Sucesso!", "Saerp Informa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não Foi Possivel Reagendar a Tarefa!\n" + ex.Message, "Saerp Informa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        /// <summary>
        /// Evento click do botão para reagendar a tarefa para um dia
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonUmDia_Click(object sender, EventArgs e)
        {
            R03Negocio negocio = new R03Negocio();
            try
            {
                negocio.despertaUmDiaDepois(r03.Ukey, negocio.user_ukey(Util.usuario()));
                MessageBox.Show("Tarefa Reagendada com Sucesso!", "Saerp Informa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não Foi Possivel Reagendar a Tarefa!\n" + ex.Message, "Saerp Informa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        /// <summary>
        /// Evento do botão agendar a tarefa para daqui uma semana
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonUmaSemana_Click(object sender, EventArgs e)
        {
            R03Negocio negocio = new R03Negocio();
            try
            {
                negocio.despertaUmaSemanaDepois(r03.Ukey, negocio.user_ukey(Util.usuario()));
                MessageBox.Show("Tarefa Reagendada com Sucesso!", "Saerp Informa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não Foi Possivel Reagendar a Tarefa!\n" + ex.Message, "Saerp Informa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        /// <summary>
        /// Evento Click do botão reagendar para daqui um mes 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonUmMes_Click(object sender, EventArgs e)
        {
            R03Negocio negocio = new R03Negocio();
            try
            {
                negocio.despertaUmMesDepois(r03.Ukey, negocio.user_ukey(Util.usuario()));
                MessageBox.Show("Tarefa Reagendada com Sucesso!", "Saerp Informa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não Foi Possivel Reagendar a Tarefa!\n" + ex.Message, "Saerp Informa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        /// <summary>
        /// Evento click do botão redespertar, pega a data e hora e reagenda a tarefa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDespertar_Click(object sender, EventArgs e)
        {
            //pega a data e hora e formata
            string data = maskedTextBoxData.Text.Replace("/", "").Trim();
            string hora = maskedTextBoxHora.Text.Replace(":", "").Trim();
            //verifica se algum campo esta vazio, se estiver da um return e avisa que os dois campos tem que estar preenchido
            if (data.Equals("") || hora.Equals(""))
            {
                MessageBox.Show("Informe uma data e hora!", "Saerp Informa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // caso esteja tudo correto reagenda a tarefa
            R03Negocio negocio = new R03Negocio();
            try
            {
                negocio.despertaDataEspecifica(r03.Ukey, negocio.user_ukey(Util.usuario()), maskedTextBoxData.Text, maskedTextBoxHora.Text);
                MessageBox.Show("Tarefa Reagendada com Sucesso!", "Saerp Informa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não Foi Possivel Reagendar a Tarefa!\n" + ex.Message, "Saerp Informa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
