using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
namespace Apresentacao
{
    public static class Util
    {
        /// <summary>
        /// função para pegar o nome do usuario que esta no arquivo usuario.txt na pasta do executavel
        /// </summary>
        /// <returns></returns>
        public static string usuario()
        {
            try
            {
                string caminho = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory.ToString());
                string nomeArquivo = "usuario.txt";
                string caminhoAbsoluto = Path.Combine(caminho, nomeArquivo);
                string[] usuario = File.ReadAllLines(caminhoAbsoluto);
                return usuario[0];
            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}
