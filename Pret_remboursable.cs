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
        private DateTime date_actuelle;
        private List<double> l = new List<double>();
        private double somme_remboursée;
        public Pret_remboursable(int cle_, Employé employé, Type_pret type, string motif, int num_pv, DateTime date_pv, double montant, DateTime date_demande, string montant_lettre, DateTime date_premier_paiment, int en_cours, Dictionary<int, double> dico, int debordement) : base(cle_, employé, type, motif, num_pv, date_pv, montant, date_demande, montant_lettre)
        {
            this.date_premier_paiment = date_premier_paiment;
            this.en_cours = en_cours;
            this.etat = dico;
            this.debordement = debordement;
            //this.mois_actuel = mois_actuel_;
            responsable.ajouter_pret_remboursable(this); //ajout automatique du pret a la liste des prets remboursables.
            this.Employé.ajouter_pret_remboursable_employe(this);// ajout automatique du pret a la liste des prets remboursable de l'employe.
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

                    this.mois_actuel++;
                }

            }
            responsable.tresor = responsable.tresor - this.Montant;

        }
        /* public double[] Etat_Rembouressement
         {
             get
             {
                 return this.etat_rembouressement;
             }
             set
             {
                 this.etat_rembouressement = value;
             }
         }*/
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
        /*public double afficher_etat_remboursement_mensuel(int m)
        {
            return this.etat_rembouressement[m];
        }*/

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
        public void affiche_attributs_complets()
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
                this.etat.Add(this.mois_actuel, this.montant / 10);
                responsable.tresor = responsable.tresor + (this.montant / 10);
                this.somme_remboursée = this.somme_remboursée + (this.montant / 10);
                this.date_actuelle = this.date_actuelle.AddMonths(1);
                this.mois_actuel++;
            }

            else
            {
                if ((this.mois_actuel == 10) && (this.somme_remboursée < this.montant))
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


            }
            if ((this.En_cours == 0) && (this.mois_actuel < 10))
            {
                this.etat.Remove(this.mois_actuel);
                this.etat.Add(this.mois_actuel, 0);
                this.mois_actuel++;
                this.date_actuelle = this.date_actuelle.AddMonths(1);
                this.en_cours = 0;
            }
            if (this.somme_remboursée == this.montant)
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
               // this.mois_actuel++;
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
           /* foreach (KeyValuePair<int, Pret_remboursable> element in responsable.liste_pret_remboursable_provisoire)
            {
                responsable.liste_pret_remboursable.Add(element.Key, element.Value);
            }
            foreach (KeyValuePair<int, Pret_remboursable> element in responsable.liste_pret_remboursable)
            {
                responsable.liste_pret_remboursable_provisoire.Remove(element.Key);
            }*/

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
            /* foreach (KeyValuePair<int, Pret_remboursable> element in responsable.liste_pret_remboursable_provisoire)
             {
                 responsable.liste_pret_remboursable.Add(element.Key, element.Value);
             }*/

        }
    }
}


            /* public void paiement()
             {
                 if ((this.en_cours == 1) && (this.mois_actuel < 10) && (this.somme_remboursée < this.montant))
                 {
                     this.etat.Remove(this.mois_actuel);
                     this.etat.Add(this.mois_actuel, this.montant / 10);
                     this.somme_remboursée = this.somme_remboursée + (this.montant / 10);
                     this.date_actuelle = this.date_actuelle.AddMonths(1);
                     this.mois_actuel++;
                 }
                 else
                 {
                     if ((this.mois_actuel == 10) && (this.somme_remboursée < this.montant))
                     {
                         Pret_remboursable p = (Pret_remboursable)this.MemberwiseClone();
                         //Pret_remboursable p = this;
                         this.mois_actuel++;
                         //p.cle = Prets.Cle_unique_prets;
                         //Prets.Cle_unique_prets++;
                         Dictionary<int, double> dico2 = new Dictionary<int, double>();
                         for (int i = 0; i < 10; i++)
                         {
                             dico2.Add(i, -1);
                         }
                         p.Etat = dico2;
                         this.debordement = p.cle;
                         //this.mois_actuel++;
                         p.mois_actuel = 0;
                         p.somme_remboursée = this.somme_remboursée;
                         p.paiement();
                         responsable.liste_pret_remboursable_provisoire.Add(responsable.cle_liste_pret_remboursable, p);
                         responsable.cle_liste_pret_remboursable++;
                     }
                 }
                 if (this.somme_remboursée == this.montant)
                 {



                     int cpt = this.mois_actuel;
                     for (cpt = this.mois_actuel; cpt < 10; cpt++)
                     {
                         this.etat.Remove(cpt);
                         this.etat.Add(cpt, 0);
                     }


                 }

                 this.en_cours = 1;
             }*/

          /*  public void retardement()
        {
            if ((this.mois_actuel < 10) && (this.somme_remboursée < this.montant))
            {
                this.etat.Remove(this.mois_actuel);

                this.etat.Add(this.mois_actuel, 0);
                this.mois_actuel++;
                this.date_actuelle = this.date_actuelle.AddMonths(1);
                this.en_cours = 0;

            }
            else
            {
                if (this.mois_actuel == 10)
                {
                    this.mois_actuel++;
                    this.date_actuelle = this.date_actuelle.AddMonths(1);
                    this.en_cours = 0;
                }
            }
                foreach (KeyValuePair<int, Pret_remboursable> kvp in responsable.liste_pret_remboursable)
                {
                    if (this.debordement == kvp.Key)
                    {
                        kvp.Value.retardement();
                    }
                }
            
        }*/
       /* public double get_value(int m, Dictionary<int, double> dico)
        {
            foreach (KeyValuePair<int, double> element in dico)
            {
                if (element.Key == m)
                {
                    return element.Value;
                }

            }
            return 0;
        }*/
      /*  public void paiement_anticipé()
        {
             if ((this.mois_actuel < 10) && (this.somme_remboursée < this.montant))
             {
                 this.etat.Remove(this.mois_actuel);
                 this.etat.Add(this.mois_actuel, (this.montant - this.somme_remboursée));
                 int cpt = this.mois_actuel;
                 for (cpt = this.mois_actuel + 1; cpt < 10; cpt++)
                 {
                     this.etat.Remove(cpt);
                     this.etat.Add(cpt, 0);
                     this.date_actuelle = this.date_actuelle.AddMonths(1);

                 }
                 this.mois_actuel = 11;
             }
            Console.WriteLine(this.mois_actuel);
            Console.WriteLine(this.somme_remboursée);
            if ((this.mois_actuel == 10) && (this.somme_remboursée < this.montant))
            {
                Pret_remboursable p = (Pret_remboursable)this.MemberwiseClone();
                this.mois_actuel++;
                //p.cle = Prets.Cle_unique_prets;
                //Prets.Cle_unique_prets++;
                Dictionary<int, double> dico2 = new Dictionary<int, double>();

                p.Etat = dico2;
                this.debordement = p.cle;
                Console.WriteLine(this.somme_remboursée);
                p.Somme_remboursée = this.somme_remboursée;
                p.mois_actuel=0;
                p.etat.Remove(0);
                p.etat.Add(0, (p.montant - p.somme_remboursée));
                int cpt = p.mois_actuel;
               /* for (cpt =  1; cpt < 10; cpt++)
                {
                    p.etat.Remove(cpt);
                    p.etat.Add(cpt, 0);
                    p.date_actuelle = p.date_actuelle.AddMonths(1);

                }*/
             /*   p.paiement_anticipé();
                p.mois_actuel = 11;
                //p.paiement_anticipé();

                responsable.liste_pret_remboursable_provisoire.Add(responsable.cle_liste_pret_remboursable, p);
                responsable.cle_liste_pret_remboursable++;
                foreach (KeyValuePair<int, Pret_remboursable> kvp in responsable.liste_pret_remboursable)
                {
                    if (this.debordement == kvp.Key)
                    {
                        kvp.Value.paiement_anticipé();
                    }
                }
            }
        }*/
           /* public void paiement_anticipé()
        {
            if ((this.mois_actuel < 10)&&(this.somme_remboursée<this.montant))
            {
                this.etat.Remove(this.mois_actuel);
                this.etat.Add(this.mois_actuel, (this.montant-this.somme_remboursée));
                int cpt = this.mois_actuel;
                for (cpt = this.mois_actuel+1; cpt < 10; cpt++)
                {
                    this.etat.Remove(cpt);
                    this.etat.Add(cpt, 0);
                    this.date_actuelle = this.date_actuelle.AddMonths(1);
                    
                }
                this.mois_actuel = 11;
            }
           if((this.mois_actuel==10)&&(this.somme_remboursée<this.montant))
            {
                Pret_remboursable p = (Pret_remboursable)this.MemberwiseClone();
                this.mois_actuel++;
                p.cle = Prets.Cle_unique_prets;
                Prets.Cle_unique_prets++;
                Dictionary<int, double> dico2 = new Dictionary<int, double>();
        
                p.Etat = dico2;
                this.debordement = p.cle;
                p.Somme_remboursée = this.somme_remboursée;
                p.etat.Remove(p.mois_actuel);
               p.etat.Add(this.mois_actuel, (p.montant - p.somme_remboursée));
                int cpt = p.mois_actuel;
                for (cpt = p.mois_actuel + 1; cpt < 10; cpt++)
                {
                    p.etat.Remove(cpt);
                    p.etat.Add(cpt, 0);
                    p.date_actuelle = p.date_actuelle.AddMonths(1);

                }
                p.mois_actuel = 11;
                p.paiement_anticipé();
                
                responsable.liste_pret_remboursable_provisoire.Add(responsable.cle_liste_pret_remboursable, p);
                responsable.cle_liste_pret_remboursable++;
                foreach (KeyValuePair<int, Pret_remboursable> kvp in responsable.liste_pret_remboursable)
                {
                    if (this.debordement == kvp.Key)
                    {
                        kvp.Value.paiement_anticipé();
                    }
                }

            }*/
   
