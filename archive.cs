using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prjp
{
    public class Archive
    {
        private int cle;
        private Prets pret;
        private string observations;
        private DateTime date_fin_remboursement;

        public Archive(int cle, Prets pret_, string observations_, DateTime date_fin_remboursement_)
        {
            this.cle = cle;
            this.pret = pret_;
            this.date_fin_remboursement = date_fin_remboursement_;
            this.observations = observations_;
        }

        public void affiche_attribue()
        {
            Console.Write(this.cle + " | ");
            this.pret.affiche_attribus();
            Console.WriteLine(this.observations + " | " + this.date_fin_remboursement);
        }

        public int Cle
        {
            get
            {
                return this.cle;
            }
            set
            {
                this.cle = value;
            }
        }

        public Prets Pret
        {
            get
            {
                return this.pret;
            }
            set
            {
                this.pret = value;
            }
        }

        public string Observations
        {
            get
            {
                return this.observations;
            }
            set
            {
                this.observations = value;
            }
        }

        public DateTime Date_fin_remboursement
        {
            get
            {
                return this.date_fin_remboursement;
            }
            set
            {
                this.date_fin_remboursement = value;
            }
        }
    }
}
