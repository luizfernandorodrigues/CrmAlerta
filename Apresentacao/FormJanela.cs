﻿using Negocio;
using ObjetoTransferencia;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Apresentacao
{
    public partial class FormJanela : Form
    {
        R03Negocio negocio = new R03Negocio();
        R03AgendamentosCollection collection = new R03AgendamentosCollection();
        R03Agendamentos agendamentos = new R03Agendamentos();
       
        public FormJanela()
        {
            InitializeComponent();
            this.timerTarefas.Start();
            //carrega atrasadas primeiro
            carregaAtrasada();
            atrasadasComHora();

            this.notifyIconJanelaPrincipal.Visible = true;

        }
        /// <summary>
        /// Evento load do form, responsavel por ocultar o icone da aplicação e deixa-la minimizada
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormJanela_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;

        }
        /// <summary>
        /// Evento Times da aplicação
        /// a cada um minuto o mesmo executa o que estiver dentro do evento
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerTarefas_Tick(object sender, EventArgs e)
        {
            carregaAtrasada();
            atrasadasComHora();
            // recebe a coleção de tarefas 
            collection = negocio.buscaAgendamento(negocio.user_ukey(Util.usuario()));
            //verifico se não é vazio a collection
            //se for da um return vazio para evitar erros
            if (collection.Count == 0)
            {
                return;
            }
            // loop para percorrer a collection e abrir um form de tarefas com cada objeto que conter na collection
            for (int i = 0; i < collection.Count; i++)
            {
                agendamentos = collection[i];
                FormPrincipal frm = new FormPrincipal(agendamentos);
                negocio.atualizaR03_006_n(agendamentos.Ukey);
                Util.ukeys.Add(agendamentos.Ukey);
                frm.Show();
            }
            collection.Clear();

        }
        /// <summary>
        /// função para carregar tarefas atrasadas conforme a data atual
        /// é chamada somente no construtor do form de inicialização da aplicação
        /// </summary>
        private void carregaAtrasada()
        {
            collection = negocio.tarefasAtrasadas(negocio.user_ukey(Util.usuario()));
            if (collection.Count == 0)
            {
                return;
            }
            for (int i = 0; i < collection.Count; i++)
            {
                agendamentos = collection[i];
                FormPrincipal frm = new FormPrincipal(agendamentos);
                negocio.atualizaR03_006_n(agendamentos.Ukey);
                Util.ukeys.Add(agendamentos.Ukey);
                frm.Show();
            }
            collection.Clear();
        }

        private void notifyIconJanelaPrincipal_MouseMove(object sender, MouseEventArgs e)
        {
            this.notifyIconJanelaPrincipal.Text = "CRM SAERP (Online)";
        }

        private void notifyIconJanelaPrincipal_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {

            }
        }

        private void toolStripMenuItemFechar_Click(object sender, EventArgs e)
        {
            Application.Exit();
            this.Close();
        }

        private void atrasadasComHora()
        {
            collection = negocio.despertaAtradosDataAnteriorHoraMaior(negocio.user_ukey(Util.usuario()));
            if (collection.Count == 0)
            {
                return;
            }
            for (int i = 0; i < collection.Count; i++)
            {
                agendamentos = collection[i];
                FormPrincipal frm = new FormPrincipal(agendamentos);
                negocio.atualizaR03_006_n(agendamentos.Ukey);
                Util.ukeys.Add(agendamentos.Ukey);
                frm.Show();
            }
            collection.Clear();
        }

        private void FormJanela_FontChanged(object sender, EventArgs e)
        {
            string ukey;
            try
            {
                R03Negocio negocio = new R03Negocio();
                for (int i = 0; i < Util.ukeys.Count; i++)
                {
                    ukey = Util.ukeys[i];
                    negocio.atualizaR03_006_nFechar(ukey);
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao Atualizar Status da Tarefa! " + ex.Message, "SAERP Informa!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
