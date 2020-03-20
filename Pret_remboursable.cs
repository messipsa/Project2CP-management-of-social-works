using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prjp
{
    public class Pret_remboursable : Prets
    {
        private DateTime date_premier_paiment;
        private Type_pret type_pret;
        private int en_cours;
        private double[] etat_rembouressement = new double[12];
        private int debordement;

        public Pret_remboursable(Employé employe, double montant, double[] mois, int en_cours, Type_pret type_pret, DateTime date_premier_paiment, int debordement) : base(employe, montant)
        {
            this.etat_rembouressement = mois;
            this.date_premier_paiment = date_premier_paiment;
            this.en_cours = en_cours;
            this.type_pret = type_pret;
            this.debordement = debordement;
        }
        public double[] Etat_Rembouressement
        {
            get
            {
                return this.etat_rembouressement;
            }
            set
            {
                this.etat_rembouressement = value;
            }
        }
        public Type_pret Type_prets
        {
            get
            {
                return this.type_pret;
            }
            set
            {
                this.type_pret = value;
            }
        }

        public int En_cours
        {
            get
            {
                return this.en_cours;
            }
            set
            {
                this.en_cours = value;
            }
        }

        public DateTime Date_premier_paiment
        {
            get
            {
                return this.date_premier_paiment;
            }
            set
            {
                this.date_premier_paiment = value;
            }
        }

        public int Debordement
        {
            get
            {
                return this.debordement;
            }
            set
            {
                this.debordement = value;
            }
        }
        public Boolean meme_pret( Pret_remboursable p2)
        {
            if(this.Employé.meme_employé(p2.employé)&&(this.Somme==p2.Somme)&&(this.Date_demande==p2.Date_demande)&&(this.Date_premier_paiment==p2.Date_premier_paiment)&&(this.Type_prets==p2.Type_prets))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
       /* public void archiver_pret(Pret_remboursable p)
        {
            foreach( Pret_remboursable s in responsable.liste_pret_remboursable.Values)
            {
                if(s.Equals(p)
                    {
                   // responsable.liste_archives.Add(1,s);
                   // responsable.liste_pret_remboursable.Remove(s.)
                }

            }

        }*/
    }
}
