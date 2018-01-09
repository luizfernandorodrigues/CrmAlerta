/*Criado por Luiz Fernando 02/01/2018
 *classe de acessa banco de dados
 *contem todas funções para manipular o banco de dados
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace AcessaDados
{
    public class AcessaBanco
    {
        #region propriedades da classe
        private string server;
        private string banco;
        private string senha;
        private string usuario;
        #endregion

        /// <summary>
        /// Função para criar a conexão com o banco de dados
        /// </summary>
        /// <returns></returns>
        public SqlConnection CriarConexao()
        {
            //busca os dados de acesso ao servidor atraves do conecta
            string[] array = File.ReadAllLines(@"C:\SAERP\conecta.txt");
            string aux = array[1];
            string[] arrayaux = aux.Split(',');
            server = arrayaux[0];
            usuario = arrayaux[1];
            senha = arrayaux[2];
            banco = arrayaux[3];
            return new SqlConnection("Data Source = " + server + "; Initial Catalog = " + banco + "; Persist Security Info = True; User ID = " + usuario + "; Password = " + senha + "");


        }
        private SqlParameterCollection sqlParametros = new SqlCommand().Parameters;

        /// <summary>
        /// Função que limpa os parametros que contem no sqlParameters
        /// </summary>
        public void LimparParametros()
        {
            sqlParametros.Clear();
        }

        /// <summary>
        /// Função que adiciona parametros para operações de manipulações
        /// </summary>
        /// <param name="nomeParametro"></param>
        /// <param name="valorParametro"></param>
        public void AdicionarParametros(string nomeParametro, object valorParametro)
        {
            sqlParametros.Add(new SqlParameter(nomeParametro, valorParametro));
        }
        /// <summary>
        /// Metodo que manipula o banco Insert, update, delete
        /// </summary>
        /// <param name="commandType"></param>
        /// <param name="sql"></param>
        /// <returns></returns>
        public void ExecutaManipulacao(CommandType commandType, string sql)
        {
            SqlConnection sqlconnection = CriarConexao();
            try
            {
                //criar conexao

                //abre a conexao
                sqlconnection.Open();
                //cria comando que vai levar informação para o banco de dados
                SqlCommand sqlCommand = sqlconnection.CreateCommand();
                //colocando as coisas dentro do comando
                sqlCommand.CommandType = commandType;
                sqlCommand.CommandText = sql;
                sqlCommand.CommandTimeout = 7200;//tempo maximo de uma execução
                                                 //adicionar os parametros no comando
                foreach (SqlParameter sqlParameter in sqlParametros)
                {
                    sqlCommand.Parameters.Add(new SqlParameter(sqlParameter.ParameterName, sqlParameter.Value));
                }
                // executar comando pra levar para o banco
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                sqlconnection.Close();
            }

        }
        /// <summary>
        /// Metodo que executa consulta no banco de dados retorna uma dataTable(tabela de dados)
        /// </summary>
        /// <param name="commandType"></param>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DataTable ExecutaConsulta(CommandType commandType, string sql)
        {
            try
            {
                //criar conexao
                SqlConnection sqlconnection = CriarConexao();
                //abre a conexao
                sqlconnection.Open();
                //cria comando que vai levar informação para o banco de dados
                SqlCommand sqlCommand = sqlconnection.CreateCommand();
                //colocando as coisas dentro do comando
                sqlCommand.CommandType = commandType;
                sqlCommand.CommandText = sql;
                sqlCommand.CommandTimeout = 7200;//tempo maximo de uma execução
                //adicionar os parametros no comando
                foreach (SqlParameter sqlParameter in sqlParametros)
                {
                    sqlCommand.Parameters.Add(new SqlParameter(sqlParameter.ParameterName, sqlParameter.Value));
                }
                //criar um adapatador
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                //crias um data table vazia
                DataTable dataTable = new DataTable();
                //preenchimento da DataTable que estava vazia
                sqlDataAdapter.Fill(dataTable);
                return dataTable;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// ************AQUI PRA BAIXO É UMA TRANSAÇÃO DE TESTES NÃO TEM UTILIDADE NO MOMENTO*********************
        /*
        //declaração da coleção de parametros do tipo de pessoa
        private SqlParameterCollection sqlParametrosTipoPessoa = new SqlCommand().Parameters;

        //adiciona paratros do tipo de pessoa
        public void AdicionarParametrosTipoPessoa(string nomeParametro, object valorParametro)
        {
            sqlParametrosTipoPessoa.Add(new SqlParameter(nomeParametro, valorParametro));
        }

        public void ExecutaTransaction(CommandType commandType, string sqlPessoa, string sqlTipoPessoa)
        {
            // cria conexao
            SqlConnection sqlconnection = CriarConexao();

            //adicionando parametros de pessoa
            SqlCommand sqlCommand = sqlconnection.CreateCommand();
            sqlCommand.CommandType = commandType;
            sqlCommand.CommandText = sqlPessoa;
            sqlCommand.CommandTimeout = 7200;//tempo maximo de uma execução
                                             //adicionar os parametros no comando
            foreach (SqlParameter sqlParameter in sqlParametros)
            {
                sqlCommand.Parameters.Add(new SqlParameter(sqlParameter.ParameterName, sqlParameter.Value));
            }

            SqlCommand sqlCommandTipoPessoa = sqlconnection.CreateCommand();
            sqlCommandTipoPessoa.CommandType = commandType;
            sqlCommandTipoPessoa.CommandText = sqlTipoPessoa;
            sqlCommandTipoPessoa.CommandTimeout = 7200;

            foreach (SqlParameter sqlParameter in sqlParametrosTipoPessoa)
            {
                sqlCommandTipoPessoa.Parameters.Add(new SqlParameter(sqlParameter.ParameterName, sqlParameter.Value));
            }

            sqlconnection.Open();
            SqlTransaction tran = sqlconnection.BeginTransaction();
            try
            {
                //comando no bd de pessoa
                sqlCommand.Transaction = tran;
                sqlCommand.ExecuteNonQuery();

                //comando no bd tipo pessoa
                sqlCommandTipoPessoa.Transaction = tran;
                sqlCommandTipoPessoa.ExecuteNonQuery();

                tran.Commit();
                sqlParametrosTipoPessoa.Clear();
            }
            catch (SqlException ex)
            {
                tran.Rollback();
                throw new Exception(ex.Message);
            }
            finally
            {
                sqlconnection.Close();
            }
            
        }*/
    }
}
