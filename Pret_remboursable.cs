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
        private int en_cours;              /* cet entier indique si le remboursement d'un pret se deroule normalement ou pas , ie : en_cours == 1 si  (1/10 du montant par mois)                                                                                                                       
                                                                                                                                en_cours == 0 s   (l'employé a choisi de mettre en pause le remboursement) */
        private double[] etat_rembouressement = new double[10];
        private int debordement;

        public Pret_remboursable( Employé employé, Type_pret type, string motif, int num_pv, DateTime date_pv, double montant, DateTime date_demande, string montant_lettre, DateTime date_premier_paiment, int en_cours, double[] etat_rembouressement, int debordement) : base( employé, type, motif, num_pv, date_pv, montant, date_demande, montant_lettre)
        {
            this.date_premier_paiment = date_premier_paiment;
            this.en_cours = en_cours;
            this.etat_rembouressement = etat_rembouressement;
            this.debordement = debordement;
            responsable.ajouter_pret_remboursable(this); //ajout automatique du pret a la liste des prets remboursables.
            this.Employé.ajouter_pret_remboursable_employe(this);// ajout automatique du pret a la liste des prets remboursable de l'employe.
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
       
        public void affiche_attributs_complets()
        {
            this.affiche_attribus();
            Console.WriteLine("Date de premeir paiement" + this.Date_premier_paiment);
            if(this.En_cours==1)
            {
                Console.WriteLine("Etat actuel  : paiement régulier"  );
            }
            else
            {
                Console.WriteLine("Etat actuel  : en retardement");
            }
            Console.WriteLine("Etat mensuel de remboursement :" + this.etat_rembouressement[0] + " | " + this.etat_rembouressement[1] + " | " + this.etat_rembouressement[2] + " | " + this.etat_rembouressement[3] + " | " + this.etat_rembouressement[4]);
            Console.WriteLine("                               " + this.etat_rembouressement[5] + " | " + this.etat_rembouressement[6] + " | " + this.etat_rembouressement[7] + " | " + this.etat_rembouressement[8] + " | " + this.etat_rembouressement[9]);
                }
       
    }
}
