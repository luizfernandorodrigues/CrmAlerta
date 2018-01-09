using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjetoTransferencia
{
    public class R01Crm
    {
        private string a03_ukey;
        private string a03_ukey1;
        private string cia_ukey;
        private string r01_001_m;
        private string sqlcmd;
        private DateTime timestamp;
        private string ukey;
        private string usr_note;

        public string A03_ukey { get => a03_ukey; set => a03_ukey = value; }
        public string A03_ukey1 { get => a03_ukey1; set => a03_ukey1 = value; }
        public string Cia_ukey { get => cia_ukey; set => cia_ukey = value; }
        public string R01_001_m { get => r01_001_m; set => r01_001_m = value; }
        public string Sqlcmd { get => sqlcmd; set => sqlcmd = value; }
        public DateTime Timestamp { get => timestamp; set => timestamp = value; }
        public string Ukey { get => ukey; set => ukey = value; }
        public string Usr_note { get => usr_note; set => usr_note = value; }
    }
}
