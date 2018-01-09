using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Apresentacao
{
    public static class Util
    {
        public static string usuario()
        {
            string[] usuario = File.ReadAllLines(@"C:\SAERP\usuario.txt");
            string valor = usuario[0];
            return valor;
        }
    }
}
