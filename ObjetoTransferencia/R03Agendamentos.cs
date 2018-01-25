using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjetoTransferencia
{
   public class R03Agendamentos
    {
        private string cia_ukey;
        private string r01_ukey;
        private DateTime r03_001_d;
        private string r03_002_c;
        private string r03_003_m;
        private Int16 r03_004_n;
        private Int16 r03_005_n;
        private Int16 r03_006_n;
        private string r03_007_c;
        private Int16 r03_008_n;
        private Int16 r03_009_n;
        private Int16 r03_010_n;
        private Int16 r03_011_n;
        private DateTime r03_012_d;
        private string r03_par;
        private string r03_ukeyp;
        private string sqlcmd;
        private DateTime timestamp;
        private string ukey;
        private string usr_note;
        private string usr_ukey;
        private string nomePaceiro;
        private string codigoParceiro;
        private string contato;
        private string fone;
        private string celular;

        public string Cia_ukey { get => cia_ukey; set => cia_ukey = value; }
        public string R01_ukey { get => r01_ukey; set => r01_ukey = value; }
        public DateTime R03_001_d { get => r03_001_d; set => r03_001_d = value; }
        public string R03_002_c { get => r03_002_c; set => r03_002_c = value; }
        public string R03_003_m { get => r03_003_m; set => r03_003_m = value; }
        public short R03_004_n { get => r03_004_n; set => r03_004_n = value; }
        public short R03_005_n { get => r03_005_n; set => r03_005_n = value; }
        public short R03_006_n { get => r03_006_n; set => r03_006_n = value; }
        public string R03_007_c { get => r03_007_c; set => r03_007_c = value; }
        public short R03_008_n { get => r03_008_n; set => r03_008_n = value; }
        public short R03_009_n { get => r03_009_n; set => r03_009_n = value; }
        public short R03_010_n { get => r03_010_n; set => r03_010_n = value; }
        public short R03_011_n { get => r03_011_n; set => r03_011_n = value; }
        public DateTime R03_012_d { get => r03_012_d; set => r03_012_d = value; }
        public string R03_par { get => r03_par; set => r03_par = value; }
        public string R03_ukeyp { get => r03_ukeyp; set => r03_ukeyp = value; }
        public string Sqlcmd { get => sqlcmd; set => sqlcmd = value; }
        public DateTime Timestamp { get => timestamp; set => timestamp = value; }
        public string Ukey { get => ukey; set => ukey = value; }
        public string Usr_note { get => usr_note; set => usr_note = value; }
        public string Usr_ukey { get => usr_ukey; set => usr_ukey = value; }
        public string NomePaceiro { get => nomePaceiro; set => nomePaceiro = value; }
        public string CodigoParceiro { get => codigoParceiro; set => codigoParceiro = value; }
        public string Contato { get => contato; set => contato = value; }
        public string Fone { get => fone; set => fone = value; }
        public string Celular { get => celular; set => celular = value; }
    }
}
