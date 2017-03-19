using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dracak_wpf_Hruska
{
    public abstract class Interface
    {
        private string jmeno;
        private int utok;
        private int zivoty;
        private int body;
        private string zbran;

        public string Jmeno
        {
            get
            {
                return jmeno;
            }

            set
            {
                jmeno = value;
            }
        }

        public int Utok
        {
            get
            {
                return utok;
            }

            set
            {
                utok = value;
            }
        }

        public int Zivoty
        {
            get
            {
                return zivoty;
            }

            set
            {
                zivoty = value;
            }
        }

        public int Body
        {
            get
            {
                return body;
            }

            set
            {
                body = value;
            }
        }

        public string Zbran
        {
            get
            {
                return zbran;
            }

            set
            {
                zbran = value;
            }
        }
    }
}
