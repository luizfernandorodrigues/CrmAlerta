/*Classe responsavel pelos metodos que manipula os dados
 * Aqui contem as funções que recebe os dados dos forms e envia para o banco
 * recebe os dados do banco e passa para os forms
 */
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcessaDados;
using ObjetoTransferencia;

namespace Negocio
{
    public class R03Negocio
    {
        /// <summary>
        /// Função para buscar agendamentos, retorna uma coleção de agendamentos
        /// </summary>
        /// <returns></returns>
        public R03AgendamentosCollection buscaAgendamento(string ukey_usuario)
        {
            AcessaBanco conn = new AcessaBanco();
            R03AgendamentosCollection r03AgendamentosCollection = new R03AgendamentosCollection();
            conn.CriarConexao();
            DataTable dataTable = new DataTable();
            var select = "SELECT" +
                " CASE WHEN A08.UKEY IS NULL THEN A03_016_C WHEN A08.UKEY IS NOT NULL THEN A08_005_C END AS CONTATO," +
                " CASE WHEN A08.UKEY IS NULL THEN A03_012_C WHEN A08.UKEY IS NOT NULL THEN A08_003_C END AS FONE," +
                " CASE WHEN A08.UKEY IS NULL THEN A03_014_C WHEN A08.UKEY IS NOT NULL THEN A08_014_C END AS CELULAR," +
                " USUARIO.UKEY AS UKEY_USER, A03.UKEY AS UKEY_CLIENTE, R03.UKEY AS R03_UKEY, * " +
                " FROM R03" +
                " INNER JOIN R01 ON R01.UKEY = R03.R01_UKEY" +
                " INNER JOIN A03 ON A03.UKEY = R01.A03_UKEY" +
                " LEFT JOIN A08 ON A08.A03_UKEY = A03.UKEY AND A08.A08_001_N = 2" +
                " INNER JOIN USUARIO ON USUARIO.UKEY = R03.USR_UKEY" +
                " WHERE R03_004_N = @NAO_DESPERTA AND R03_010_N = @DESPERTA_TELA AND R03_006_N = @DESPERTA_NOVAMENTE AND R03_001_D = @DATA_DESPERTA" +
                " AND R03.USR_UKEY = @UKEY_USER AND R03_008_N = @TAREFA_ENCERRADA AND R03_002_C <= @HORA_AGENDADA" +
                " ORDER BY R03.TIMESTAMP ASC";
            DateTime dateTime = DateTime.Now;
            // string hora_minuto = string.Format("{0:hh:mm}", dateTime);
            string hora_minuto = dateTime.ToShortTimeString();

            conn.AdicionarParametros("@NAO_DESPERTA", 0);
            conn.AdicionarParametros("@DESPERTA_TELA", 1);
            conn.AdicionarParametros("@DESPERTA_NOVAMENTE", 0);
            conn.AdicionarParametros("@DATA_DESPERTA", DateTime.Now.Date);
            conn.AdicionarParametros("@UKEY_USER", ukey_usuario);
            conn.AdicionarParametros("@TAREFA_ENCERRADA", 0);
            conn.AdicionarParametros("@HORA_AGENDADA", hora_minuto);
            dataTable = conn.ExecutaConsulta(CommandType.Text, select);

            foreach (DataRow linha in dataTable.Rows)
            {
                R03Agendamentos r03Agendamentos = new R03Agendamentos();
                r03Agendamentos.R03_001_d = Convert.ToDateTime(linha["R03_001_D"]);
                r03Agendamentos.R03_002_c = Convert.ToString(linha["R03_002_C"]);
                r03Agendamentos.R03_003_m = Convert.ToString(linha["R03_003_M"]);
                r03Agendamentos.R03_004_n = Convert.ToInt16(linha["R03_004_N"]);
                r03Agendamentos.R03_005_n = Convert.ToInt16(linha["R03_005_N"]);
                r03Agendamentos.R03_006_n = Convert.ToInt16(linha["R03_006_N"]);
                r03Agendamentos.R03_007_c = Convert.ToString(linha["R03_007_C"]);
                r03Agendamentos.R03_008_n = Convert.ToInt16(linha["R03_008_N"]);
                r03Agendamentos.R03_009_n = Convert.ToInt16(linha["R03_009_N"]);
                r03Agendamentos.R03_010_n = Convert.ToInt16(linha["R03_010_N"]);
                r03Agendamentos.R03_011_n = Convert.ToInt16(linha["R03_011_N"]);
                r03Agendamentos.R03_012_d = Convert.ToDateTime(linha["R03_012_D"]);
                r03Agendamentos.R03_par = Convert.ToString(linha["R03_PAR"]);
                r03Agendamentos.R03_ukeyp = Convert.ToString(linha["R03_UKEYP"]);
                r03Agendamentos.Timestamp = Convert.ToDateTime(linha["TIMESTAMP"]);
                r03Agendamentos.Ukey = Convert.ToString(linha["UKEY"]);
                r03Agendamentos.Usr_note = Convert.ToString(linha["USR_NOTE"]);
                r03Agendamentos.NomePaceiro = Convert.ToString(linha["A03_003_C"]);
                r03Agendamentos.CodigoParceiro = Convert.ToString(linha["A03_001_C"]);
                r03Agendamentos.Contato = Convert.ToString(linha["CONTATO"]);
                r03Agendamentos.Celular = Convert.ToString(linha["CELULAR"]);
                r03Agendamentos.Fone = Convert.ToString(linha["FONE"]);
                r03AgendamentosCollection.Add(r03Agendamentos);
            }
            return r03AgendamentosCollection;

        }
        /// <summary>
        /// Função que recebe o nome do usuario e retorna a ukey dele
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public string user_ukey(string usuario)
        {
            AcessaBanco conn = new AcessaBanco();
            DataTable dataTable = new DataTable();
            conn.LimparParametros();
            var select = "SELECT UKEY FROM USUARIO WHERE USUARIO = @USUARIO";
            conn.AdicionarParametros("@USUARIO", usuario);
            dataTable = conn.ExecutaConsulta(CommandType.Text, select);
            string valor = dataTable.Rows[0]["UKEY"].ToString();
            return valor;
        }
        /// <summary>
        /// função que altera a tarefa para não despertar mais
        /// </summary>
        /// <param name="ukey"></param>
        /// <param name="ukey_user"></param>
        public void naoDesperta(string ukey, string ukey_user)
        {
            AcessaBanco conn = new AcessaBanco();
            conn.LimparParametros();
            var update = "UPDATE R03 SET R03_004_N  = @VALOR, USR_UKEY = @USUARIO, TIMESTAMP = @TIMESTAMP WHERE UKEY = @UKEY";
            conn.AdicionarParametros("@VALOR", 1);
            conn.AdicionarParametros("@USUARIO", ukey_user);
            conn.AdicionarParametros("@TIMESTAMP", DateTime.Now);
            conn.AdicionarParametros("@UKEY", ukey);
            conn.ExecutaManipulacao(CommandType.Text, update);
        }
        /// <summary>
        /// Função que busca as tarefas atrasadas com base na data atual
        /// </summary>
        /// <param name="user_ukey"></param>
        /// <returns></returns>
        public R03AgendamentosCollection tarefasAtrasadas(string user_ukey)
        {
            AcessaBanco conn = new AcessaBanco();
            R03AgendamentosCollection r03AgendamentosCollection = new R03AgendamentosCollection();
            conn.CriarConexao();
            DataTable dataTable = new DataTable();
            var select = "SELECT" +
                " CASE WHEN A08.UKEY IS NULL THEN A03_016_C WHEN A08.UKEY IS NOT NULL THEN A08_005_C END AS CONTATO," +
                " CASE WHEN A08.UKEY IS NULL THEN A03_012_C WHEN A08.UKEY IS NOT NULL THEN A08_003_C END AS FONE," +
                " CASE WHEN A08.UKEY IS NULL THEN A03_014_C WHEN A08.UKEY IS NOT NULL THEN A08_014_C END AS CELULAR," +
                " USUARIO.UKEY AS UKEY_USER, A03.UKEY AS UKEY_CLIENTE, R03.UKEY AS R03_UKEY, * FROM R03" +
                " INNER JOIN R01 ON R01.UKEY = R03.R01_UKEY" +
                " INNER JOIN A03 ON A03.UKEY = R01.A03_UKEY" +
                " LEFT JOIN A08 ON A08.A03_UKEY = A03.UKEY AND A08.A08_001_N = 2" +
                " INNER JOIN USUARIO ON USUARIO.UKEY = R03.USR_UKEY" +
                " WHERE R03_004_N = @NAO_DESPERTA AND R03_010_N = @DESPERTA_TELA AND R03_001_D = @DATA_DESPERTA" +
                " AND R03.USR_UKEY = @UKEY_USER AND R03_008_N = @TAREFA_ENCERRADA AND R03_002_C <= @HORADESPERTA AND R03_006_N = @DESPERTA_NOVAMENTE" +
                " ORDER BY R03.R03_001_D ASC";

            System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("pt-BR");

            string hrinicial = String.Format("{0:t}", DateTime.Now);
            string data = DateTime.Now.ToShortDateString();
            conn.AdicionarParametros("@NAO_DESPERTA", 0);
            conn.AdicionarParametros("@DESPERTA_TELA", 1);
            conn.AdicionarParametros("@DATA_DESPERTA", data);
            conn.AdicionarParametros("@UKEY_USER", user_ukey);
            conn.AdicionarParametros("@TAREFA_ENCERRADA", 0);
            conn.AdicionarParametros("@HORADESPERTA", hrinicial);
            conn.AdicionarParametros("@DESPERTA_NOVAMENTE", 0);
            dataTable = conn.ExecutaConsulta(CommandType.Text, select);

            foreach (DataRow linha in dataTable.Rows)
            {
                R03Agendamentos r03Agendamentos = new R03Agendamentos();
                r03Agendamentos.R03_001_d = Convert.ToDateTime(linha["R03_001_D"]);
                r03Agendamentos.R03_002_c = Convert.ToString(linha["R03_002_C"]);
                r03Agendamentos.R03_003_m = Convert.ToString(linha["R03_003_M"]);
                r03Agendamentos.R03_004_n = Convert.ToInt16(linha["R03_004_N"]);
                r03Agendamentos.R03_005_n = Convert.ToInt16(linha["R03_005_N"]);
                r03Agendamentos.R03_006_n = Convert.ToInt16(linha["R03_006_N"]);
                r03Agendamentos.R03_007_c = Convert.ToString(linha["R03_007_C"]);
                r03Agendamentos.R03_008_n = Convert.ToInt16(linha["R03_008_N"]);
                r03Agendamentos.R03_009_n = Convert.ToInt16(linha["R03_009_N"]);
                r03Agendamentos.R03_010_n = Convert.ToInt16(linha["R03_010_N"]);
                r03Agendamentos.R03_011_n = Convert.ToInt16(linha["R03_011_N"]);
                r03Agendamentos.R03_012_d = Convert.ToDateTime(linha["R03_012_D"]);
                r03Agendamentos.R03_par = Convert.ToString(linha["R03_PAR"]);
                r03Agendamentos.R03_ukeyp = Convert.ToString(linha["R03_UKEYP"]);
                r03Agendamentos.Timestamp = Convert.ToDateTime(linha["TIMESTAMP"]);
                r03Agendamentos.Ukey = Convert.ToString(linha["UKEY"]);
                r03Agendamentos.Usr_note = Convert.ToString(linha["USR_NOTE"]);
                r03Agendamentos.NomePaceiro = Convert.ToString(linha["A03_003_C"]);
                r03Agendamentos.CodigoParceiro = Convert.ToString(linha["A03_001_C"]);
                r03Agendamentos.Contato = Convert.ToString(linha["CONTATO"]);
                r03Agendamentos.Celular = Convert.ToString(linha["CELULAR"]);
                r03Agendamentos.Fone = Convert.ToString(linha["FONE"]);
                r03AgendamentosCollection.Add(r03Agendamentos);
            }
            return r03AgendamentosCollection;
        }
        /// <summary>
        /// Função que altera a tarefa para despertar uma hora depois
        /// </summary>
        /// <param name="ukey"></param>
        /// <param name="user_ukey"></param>
        public void despertaUmaHoraDepois(string ukey, string user_ukey)
        {
            string horaAtual;
            DateTime hora = DateTime.Now;
            hora = hora.AddHours(1);
            horaAtual = hora.ToShortTimeString();
            AcessaBanco conn = new AcessaBanco();
            conn.LimparParametros();
            var update = "UPDATE R03 SET R03_004_N = @NAO_DESPERTA, R03_006_N = @VOLTA_DESPERTAR," +
                " R03_002_C = @HORA_AGENDADA, USR_UKEY = @UKEY_USER WHERE UKEY = @UKEY";
            conn.AdicionarParametros("@NAO_DESPERTA", 0);
            conn.AdicionarParametros("@VOLTA_DESPERTAR", 0);
            conn.AdicionarParametros("@HORA_AGENDADA", horaAtual);
            conn.AdicionarParametros("@UKEY_USER", user_ukey);
            conn.AdicionarParametros("@UKEY", ukey);
            conn.ExecutaManipulacao(CommandType.Text, update);
        }
        /// <summary>
        /// Função que altera a tarefa para despertar um dia depois
        /// </summary>
        /// <param name="ukey"></param>
        /// <param name="user_ukey"></param>
        public void despertaUmDiaDepois(string ukey, string user_ukey)
        {
            string diaAtual;
            DateTime dia = DateTime.Now;
            dia = dia.AddDays(1);
            diaAtual = dia.ToShortDateString();

            AcessaBanco conn = new AcessaBanco();
            conn.LimparParametros();
            var update = "UPDATE R03 SET R03_004_N = @NAO_DESPERTA, R03_006_N = @VOLTA_DESPERTAR," +
                " R03_001_D = @HORA_AGENDADA, USR_UKEY = @UKEY_USER WHERE UKEY = @UKEY";
            conn.AdicionarParametros("@NAO_DESPERTA", 0);
            conn.AdicionarParametros("@VOLTA_DESPERTAR", 0);
            conn.AdicionarParametros("@HORA_AGENDADA", diaAtual);
            conn.AdicionarParametros("@UKEY_USER", user_ukey);
            conn.AdicionarParametros("@UKEY", ukey);
            conn.ExecutaManipulacao(CommandType.Text, update);
        }
        /// <summary>
        /// Função que altera a tarefa para despertar uma semana depois
        /// </summary>
        /// <param name="ukey"></param>
        /// <param name="user_ukey"></param>
        public void despertaUmaSemanaDepois(string ukey, string user_ukey)
        {
            string diaAtual;
            DateTime dia = DateTime.Now;
            dia = dia.AddDays(7);
            diaAtual = dia.ToShortDateString();

            AcessaBanco conn = new AcessaBanco();
            conn.LimparParametros();
            var update = "UPDATE R03 SET R03_004_N = @NAO_DESPERTA, R03_006_N = @VOLTA_DESPERTAR," +
                " R03_001_D = @HORA_AGENDADA, USR_UKEY = @UKEY_USER WHERE UKEY = @UKEY";
            conn.AdicionarParametros("@NAO_DESPERTA", 0);
            conn.AdicionarParametros("@VOLTA_DESPERTAR", 0);
            conn.AdicionarParametros("@HORA_AGENDADA", diaAtual);
            conn.AdicionarParametros("@UKEY_USER", user_ukey);
            conn.AdicionarParametros("@UKEY", ukey);
            conn.ExecutaManipulacao(CommandType.Text, update);
        }
        /// <summary>
        /// Função que altera a tarefa para despertar um mes depois
        /// </summary>
        /// <param name="ukey"></param>
        /// <param name="user_ukey"></param>
        public void despertaUmMesDepois(string ukey, string user_ukey)
        {
            string mesAtual;
            DateTime mes = DateTime.Now;
            mes = mes.AddMonths(1);
            mesAtual = mes.ToShortDateString();

            AcessaBanco conn = new AcessaBanco();
            conn.LimparParametros();
            var update = "UPDATE R03 SET R03_004_N = @NAO_DESPERTA, R03_006_N = @VOLTA_DESPERTAR," +
                " R03_001_D = @HORA_AGENDADA, USR_UKEY = @UKEY_USER WHERE UKEY = @UKEY";
            conn.AdicionarParametros("@NAO_DESPERTA", 0);
            conn.AdicionarParametros("@VOLTA_DESPERTAR", 0);
            conn.AdicionarParametros("@HORA_AGENDADA", mesAtual);
            conn.AdicionarParametros("@UKEY_USER", user_ukey);
            conn.AdicionarParametros("@UKEY", ukey);
            conn.ExecutaManipulacao(CommandType.Text, update);
        }
        /// <summary>
        /// Função que altera a tarefa para despertar em uma data e hora especifica
        /// </summary>
        /// <param name="ukey"></param>
        /// <param name="user_ukey"></param>
        /// <param name="data"></param>
        /// <param name="hora"></param>
        public void despertaDataEspecifica(string ukey, string user_ukey, string data, string hora)
        {
            AcessaBanco conn = new AcessaBanco();
            conn.LimparParametros();
            var update = "UPDATE R03 SET R03_004_N = @NAO_DESPERTA, R03_006_N = @VOLTA_DESPERTAR," +
                " R03_001_D = @HORA_AGENDADA, R03_002_C = @HORA, USR_UKEY = @UKEY_USER WHERE UKEY = @UKEY";
            conn.AdicionarParametros("@NAO_DESPERTA", 0);
            conn.AdicionarParametros("@VOLTA_DESPERTAR", 0);
            conn.AdicionarParametros("@HORA_AGENDADA", data);
            conn.AdicionarParametros("@HORA", hora);
            conn.AdicionarParametros("@UKEY_USER", user_ukey);
            conn.AdicionarParametros("@UKEY", ukey);
            conn.ExecutaManipulacao(CommandType.Text, update);
        }

        public R03AgendamentosCollection despertaAtradosDataAnteriorHoraMaior(string user_ukey)
        {
            AcessaBanco conn = new AcessaBanco();
            R03AgendamentosCollection r03AgendamentosCollection = new R03AgendamentosCollection();
            conn.LimparParametros();
            DataTable dataTable = new DataTable();
            var select = "SELECT" +
                " CASE WHEN A08.UKEY IS NULL THEN A03_016_C WHEN A08.UKEY IS NOT NULL THEN A08_005_C END AS CONTATO," +
                " CASE WHEN A08.UKEY IS NULL THEN A03_012_C WHEN A08.UKEY IS NOT NULL THEN A08_003_C END AS FONE," +
                " CASE WHEN A08.UKEY IS NULL THEN A03_014_C WHEN A08.UKEY IS NOT NULL THEN A08_014_C END AS CELULAR," +
                " USUARIO.UKEY AS UKEY_USER, A03.UKEY AS UKEY_CLIENTE, R03.UKEY AS R03_UKEY, * FROM R03" +
                " INNER JOIN R01 ON R01.UKEY = R03.R01_UKEY" +
                " INNER JOIN A03 ON A03.UKEY = R01.A03_UKEY" +
                " LEFT JOIN A08 ON A08.A03_UKEY = A03.UKEY AND A08.A08_001_N = 2" +
                " INNER JOIN USUARIO ON USUARIO.UKEY = R03.USR_UKEY" +
                " WHERE R03_004_N = @NAO_DESPERTA AND R03_010_N = @DESPERTA_TELA AND R03_001_D < @DATA_DESPERTA" +
                " AND R03.USR_UKEY = @UKEY_USER AND R03_008_N = @TAREFA_ENCERRADA AND R03_006_N = @DESPERTA_NOVAMENTE" +
                " ORDER BY R03.R03_001_D ASC";
            System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("pt-BR");

            string hrinicial = String.Format("{0:t}", DateTime.Now);
            string data = DateTime.Now.ToShortDateString();

            conn.AdicionarParametros("@NAO_DESPERTA", 0);
            conn.AdicionarParametros("@DESPERTA_TELA", 1);
            conn.AdicionarParametros("@DATA_DESPERTA", data);
            conn.AdicionarParametros("@UKEY_USER", user_ukey);
            conn.AdicionarParametros("@TAREFA_ENCERRADA", 0);
            conn.AdicionarParametros("@DESPERTA_NOVAMENTE", 0);
            dataTable = conn.ExecutaConsulta(CommandType.Text, select);

            foreach (DataRow linha in dataTable.Rows)
            {
                R03Agendamentos r03Agendamentos = new R03Agendamentos();
                r03Agendamentos.R03_001_d = Convert.ToDateTime(linha["R03_001_D"]);
                r03Agendamentos.R03_002_c = Convert.ToString(linha["R03_002_C"]);
                r03Agendamentos.R03_003_m = Convert.ToString(linha["R03_003_M"]);
                r03Agendamentos.R03_004_n = Convert.ToInt16(linha["R03_004_N"]);
                r03Agendamentos.R03_005_n = Convert.ToInt16(linha["R03_005_N"]);
                r03Agendamentos.R03_006_n = Convert.ToInt16(linha["R03_006_N"]);
                r03Agendamentos.R03_007_c = Convert.ToString(linha["R03_007_C"]);
                r03Agendamentos.R03_008_n = Convert.ToInt16(linha["R03_008_N"]);
                r03Agendamentos.R03_009_n = Convert.ToInt16(linha["R03_009_N"]);
                r03Agendamentos.R03_010_n = Convert.ToInt16(linha["R03_010_N"]);
                r03Agendamentos.R03_011_n = Convert.ToInt16(linha["R03_011_N"]);
                r03Agendamentos.R03_012_d = Convert.ToDateTime(linha["R03_012_D"]);
                r03Agendamentos.R03_par = Convert.ToString(linha["R03_PAR"]);
                r03Agendamentos.R03_ukeyp = Convert.ToString(linha["R03_UKEYP"]);
                r03Agendamentos.Timestamp = Convert.ToDateTime(linha["TIMESTAMP"]);
                r03Agendamentos.Ukey = Convert.ToString(linha["UKEY"]);
                r03Agendamentos.Usr_note = Convert.ToString(linha["USR_NOTE"]);
                r03Agendamentos.NomePaceiro = Convert.ToString(linha["A03_003_C"]);
                r03Agendamentos.CodigoParceiro = Convert.ToString(linha["A03_001_C"]);
                r03Agendamentos.Contato = Convert.ToString(linha["CONTATO"]);
                r03Agendamentos.Celular = Convert.ToString(linha["CELULAR"]);
                r03Agendamentos.Fone = Convert.ToString(linha["FONE"]);
                r03AgendamentosCollection.Add(r03Agendamentos);
            }
            return r03AgendamentosCollection;
        }

        public DateTime pegaDataBrasil()
        {
            return TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));
        }

        public void atualizaR03_006_n(string ukey)
        {
            AcessaBanco conn = new AcessaBanco();
            conn.LimparParametros();
            var update = "UPDATE R03 SET R03_006_N = @DESPERTA_NOVAMENTE WHERE UKEY = @UKEY";
            conn.AdicionarParametros("@DESPERTA_NOVAMENTE", 1);
            conn.AdicionarParametros("@UKEY", ukey);
            conn.ExecutaManipulacao(CommandType.Text, update);
        }

        public void atualizaR03_006_nFechar(string ukey)
        {
            AcessaBanco conn = new AcessaBanco();
            conn.LimparParametros();
            var update = "UPDATE R03 SET R03_006_N = @DESPERTA_NOVAMENTE WHERE UKEY = @UKEY";
            conn.AdicionarParametros("@DESPERTA_NOVAMENTE", 0);
            conn.AdicionarParametros("@UKEY", ukey);
            conn.ExecutaManipulacao(CommandType.Text, update);
        }
    }
}
