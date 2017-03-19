using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dracak_wpf_Hruska
{
    public class Weapon
    {
        private string jmeno_zbrane;
        private int body;
        private int zivoty;

        public string Jmeno_zbrane
        {
            get
            {
                return jmeno_zbrane;
            }

            set
            {
                jmeno_zbrane = value;
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
    }
}
