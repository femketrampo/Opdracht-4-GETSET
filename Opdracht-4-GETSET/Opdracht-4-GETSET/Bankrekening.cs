using System;
using System.Collections.Generic;
using System.Text;

namespace Opdracht_4
{
    class Bankrekening
    {
        private double balans;
        private double limiet;
        private string verrichtingen;

        public double Balans
        {
            get { return balans; }
            set { balans = value; }
        }
        public double Limiet
        {
            get { return limiet; }
            set { limiet = value; }
        }
        public string Verrichtingen
        {
            get { return verrichtingen; }
            set { verrichtingen = value; }
        }

        public Bankrekening()
        {
            balans = 0;
            Limiet = 0;
            Verrichtingen = "";
        }
    }
}