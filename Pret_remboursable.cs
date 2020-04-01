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
        // private double[] etat_rembouressement = new double[10];
        private Dictionary<int, double> etat = new Dictionary<int, double>();
        private int debordement;
        private int mois_actuel = 0;
        private DateTime date_actuelle ;
        private int durée;
        private List<double> l = new List<double>();
        private double somme_remboursée;
        public Pret_remboursable(int cle_, Employé employé, Type_pret type, string motif, int num_pv, DateTime date_pv, double montant, DateTime date_demande, string montant_lettre, DateTime date_premier_paiment,int durée, int en_cours, Dictionary<int, double> dico, int debordement) : base(cle_, employé, type, motif, num_pv, date_pv, montant, date_demande, montant_lettre)
        {
            this.date_premier_paiment = date_premier_paiment;
            this.en_cours = en_cours;
            this.etat = dico;
            this.debordement = debordement;
            foreach(Pret_remboursable p in responsable.liste_pret_remboursable.Values)
            {
                if(p.debordement==this.cle)
                {
                    this.somme_remboursée = p.Somme_remboursée;
                }
            }
            //this.mois_actuel = mois_actuel_;
            this.durée = durée;
            this.date_actuelle = date_premier_paiment;
            foreach (double d in this.etat.Values)
            {
                if (d != -1)
                {
                    this.somme_remboursée = this.somme_remboursée + d;
                }
            }
            foreach (double d in this.etat.Values)
            {
                if (d != -1)
                {
                    this.date_actuelle = this.date_actuelle.AddMonths(1);
                    this.mois_actuel++;
                }

            }
            responsable.tresor = responsable.tresor - this.Montant;
           // responsable.ajouter_pret_remboursable(this); //ajout automatique du pret a la liste des prets remboursables.
           // this.Employé.ajouter_pret_remboursable_employe(this);// ajout automatique du pret a la liste des prets remboursable de l'employe.

        }

        public Dictionary<int, double> Etat
        {
            get
            {
                return this.etat;
            }
            set
            {
                this.etat = value;
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
        public DateTime Date_actuelle
        {
            get
            {
                return this.date_actuelle;
            }
            set
            {
                this.date_actuelle = value;
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
        public int Mois_actuel
        {
            get
            {
                return this.mois_actuel;
            }
            set
            {
                this.mois_actuel = value;
            }
        }
        public double Somme_remboursée
        {
            get
            {
                return this.somme_remboursée;
            }
            set
            {
                this.somme_remboursée = value;
            }
        }
        public override void affiche_attributs_complets()
        {

            this.affiche_attribus();
            Console.WriteLine("Date de premeir paiement" + this.Date_premier_paiment);
            foreach (double item in this.l) // Loop through List with foreach
            {
                Console.WriteLine(item);
            }


            if (this.En_cours == 1)
            {
                Console.WriteLine("Etat actuel  : paiement régulier");
            }
            else
            {
                Console.WriteLine("Etat actuel  : en retardement");
            }
            Console.WriteLine("Etat de remboursement");
            foreach (double d in this.etat.Values)
            {
                Console.Write(" " + d);

            }
            Console.WriteLine("          ");
            Console.WriteLine(this.mois_actuel);
            Console.WriteLine(this.somme_remboursée);


        }
        public void paiement()
        {
            if ((this.en_cours == 1) && (this.mois_actuel < 10) && (this.somme_remboursée < this.montant))
            {
                this.etat.Remove(this.mois_actuel);
                this.etat.Add(this.mois_actuel, this.montant / this.durée);
                responsable.tresor = responsable.tresor + (this.montant / this.durée);
                this.somme_remboursée = this.somme_remboursée + (this.montant / this.durée);
                this.date_actuelle = this.date_actuelle.AddMonths(1);
                this.mois_actuel++;
            }

            else
            {
                if ((this.mois_actuel == 10)&&(this.debordement==-1) && (this.somme_remboursée < this.montant))
                {
                    Pret_remboursable p = (Pret_remboursable)this.MemberwiseClone();
                    p.cle = responsable.cle_a_affecter_pret_remboursable();
                    Dictionary<int, double> dico2 = new Dictionary<int, double>();
                    for (int i = 0; i < 10; i++)
                    {
                        dico2.Add(i, -1);
                    }
                    p.Etat = dico2;
                    this.debordement = p.cle;
                    this.mois_actuel++;
                    p.mois_actuel = 0;
                    p.somme_remboursée = this.somme_remboursée;
                    p.paiement();
                    responsable.liste_pret_remboursable_provisoire.Add(p.cle, p);
                }
                else
                {
                    if((this.mois_actuel == 10) && (this.debordement != -1))
                    {
                        this.mois_actuel++;
                    }
                }


            }
            if ((this.En_cours == 0) && (this.mois_actuel < 10))
            {
                this.etat.Remove(this.mois_actuel);
                this.etat.Add(this.mois_actuel, 0);
                this.mois_actuel++;
                this.date_actuelle = this.date_actuelle.AddMonths(1);
                this.en_cours = 0;
            }
            if ((this.somme_remboursée == this.montant)||((this.somme_remboursée+1 >= this.montant)))
            {
                int cpt = this.mois_actuel;
                if (cpt < 10)
                {
                    for (cpt = this.mois_actuel; cpt < 10; cpt++)
                    {
                        this.etat.Remove(cpt);
                        this.etat.Add(cpt, 0);
                    }
                }
                this.mois_actuel = 11;
                this.date_actuelle = this.date_actuelle.AddMonths( - 1);
            }
            this.En_cours = 1;
        }

        public void retardement()
        {
            this.En_cours = 0;
            foreach (KeyValuePair<int, Pret_remboursable> kvp in responsable.liste_pret_remboursable)
            {
                if (this.debordement == kvp.Key)
                {
                    kvp.Value.retardement();
                }
            }
        }
        public void paiement_anticipé()
{
    int trace = -1;
    if ((this.mois_actuel < 10) && (this.somme_remboursée < this.montant))
    {
        this.etat.Remove(this.mois_actuel);
        this.etat.Add(this.mois_actuel, (this.montant - this.somme_remboursée));
        responsable.tresor = responsable.tresor + this.montant ;
        this.somme_remboursée = this.montant;
        int cpt = this.mois_actuel;
        for (cpt = this.mois_actuel + 1; cpt < 10; cpt++)
        {
            this.etat.Remove(cpt);
            this.etat.Add(cpt, 0);
            this.date_actuelle = this.date_actuelle.AddMonths(1);

        }
                this.mois_actuel = 11;
    }
    else
    {
        if ((this.mois_actuel == 10) &&(this.debordement==-1) &&(this.somme_remboursée < this.montant))
        {
            Pret_remboursable p = (Pret_remboursable)this.MemberwiseClone();
            p.cle = responsable.cle_a_affecter_pret_remboursable();
            trace = p.cle;
            Dictionary<int, double> dico2 = new Dictionary<int, double>();
            for (int i = 0; i < 10; i++)
            {
                dico2.Add(i, -1);
            }
            p.Etat = dico2;
            this.debordement = p.cle;
            this.mois_actuel++;
            p.mois_actuel = 0;
            p.somme_remboursée = this.somme_remboursée;
            p.paiement_anticipé();
            responsable.liste_pret_remboursable_provisoire.Add(p.cle, p);
        }
        else
                {
                    if((this.mois_actuel == 10) && (this.debordement != -1))
                    {
                        this.mois_actuel++;
                    }
                }
    }

    foreach (KeyValuePair<int, Pret_remboursable> kvp in responsable.liste_pret_remboursable)
    {
        if ((this.debordement == kvp.Key))
        {
            kvp.Value.paiement_anticipé();
        }
    }
    foreach (KeyValuePair<int, Pret_remboursable> element in responsable.liste_pret_remboursable_provisoire)
    {
        if ((this.debordement == element.Key))
        {
            element.Value.paiement_anticipé();
        }
    }

}
        

        /*public void paiement_anticipé()
        {
            int trace = -1;
            if ((this.mois_actuel < 10) && (this.somme_remboursée < this.montant))
            {
                this.etat.Remove(this.mois_actuel);
                Console.WriteLine("777777777777777777777777777777777777");
                this.etat.Add(this.mois_actuel, (this.montant - this.somme_remboursée));
                Console.WriteLine(this.etat.ContainsValue(this.montant - this.somme_remboursée));
                responsable.tresor = responsable.tresor + this.montant ;
                this.somme_remboursée = this.montant;
                int cpt = this.mois_actuel;
                for (cpt = this.mois_actuel + 1; cpt < 10; cpt++)
                {
                    this.etat.Remove(cpt);
                    this.etat.Add(cpt, 0);
                    this.date_actuelle = this.date_actuelle.AddMonths(1);

                }
            }
            else
            {
                if ((this.mois_actuel == 10) && (this.somme_remboursée < this.montant))
                {
                    Pret_remboursable p = (Pret_remboursable)this.MemberwiseClone();
                    p.cle = responsable.cle_a_affecter_pret_remboursable();
                    trace = p.cle;
                    Dictionary<int, double> dico2 = new Dictionary<int, double>();
                    for (int i = 0; i < 10; i++)
                    {
                        dico2.Add(i, -1);
                    }
                    p.Etat = dico2;
                    this.debordement = p.cle;
                    this.mois_actuel++;
                    p.mois_actuel = 0;
                    p.somme_remboursée = this.somme_remboursée;
                    p.paiement_anticipé();
                    responsable.liste_pret_remboursable_provisoire.Add(p.cle, p);
                }
            }

            foreach (KeyValuePair<int, Pret_remboursable> kvp in responsable.liste_pret_remboursable)
            {
                if ((this.debordement == kvp.Key))
                {
                    kvp.Value.paiement_anticipé();
                }
            }
            foreach (KeyValuePair<int, Pret_remboursable> element in responsable.liste_pret_remboursable_provisoire)
            {
                if ((this.debordement == element.Key))
                {
                    element.Value.paiement_anticipé();
                }
            }

        }*/
        public Pret_remboursable pere()
        {
            foreach(KeyValuePair<int,Pret_remboursable> kvp in responsable.liste_pret_remboursable)
            {
                if(kvp.Value.Debordement == this.cle)
                {
                    return kvp.Value;
                }
            }
            return this;
        }
    }
}

   
