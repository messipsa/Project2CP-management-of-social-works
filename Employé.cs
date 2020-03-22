using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prjp
{
    public class Employé
    {
        private int cle;
        private string nom;
        private string prenom;
        private string num_sec_social;
        private DateTime date_naissance;
        private DateTime date_prem;
        private string grade;
        private string ccp;
        private string cle_ccp;
        private string etat;
        private string num_tel;
        private bool demande;
        private string matricule;

        private Dictionary<int, Pret_remboursable> pret_remboursable_employe = new Dictionary<int, Pret_remboursable>();
        private Dictionary<int, Pret_non_remboursable> pret_non_remboursable_employe = new Dictionary<int, Pret_non_remboursable>();


        public Employé(int cle, string matricule, string nom, string prenom, string num_sec_social, DateTime date_naissance, string grade, DateTime date_prem, string etat, string ccp, string cle_ccp, string tel, bool demande)
        {
            this.cle = cle;
            this.matricule = matricule;
            this.nom = nom;
            this.prenom = prenom;
            this.num_sec_social = num_sec_social;
            this.date_naissance = date_naissance;
            this.date_prem = date_prem;
            this.grade = grade;
            this.ccp = ccp;
            this.cle_ccp = cle_ccp;
            this.etat = etat;
            this.ccp = ccp;
            this.tel = tel;
            this.demande = demande;
        }

        public void affiche_attribus()
        {
            Console.WriteLine(this.cle + " | " + this.matricule + " | " + this.nom + " | " + this.prenom + " | " + this.num_sec_social + " | " + this.date_naissance + " | " + this.grade + " | " + this.date_prem + " | " + this.etat + " | " + this.ccp + " | " + this.cle_ccp + " | " + this.tel + " | " + this.demande);
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

        public string Matricule
        {
            get
            {
                return this.matricule;
            }
            set
            {
                this.matricule = value;
            }
        }

        public string Nom
        {
            get
            {
                return this.nom;
            }
            set
            {
                this.nom = value;
            }
        }

        public string Prenom
        {
            get
            {
                return this.prenom;
            }
            set
            {
                this.prenom = value;
            }
        }
        public string sec_soc
        {
            get
            {
                return this.num_sec_social;
            }
            set
            {
                this.num_sec_social = value;
            }
        }
        public string compte_ccp
        {
            get
            {
                return this.ccp;
            }
            set
            {
                this.ccp = value;
            }

        }
        public string Cle_ccp
        {
            get
            {
                return this.cle_ccp;
            }
            set
            {
                this.cle_ccp = value;
            }
        }

        public string etats
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
        public string tel
        {
            get
            {
                return this.num_tel;
            }
            set
            {
                this.num_tel = value;
            }
        }
        public bool Demande
        {
            get
            {
                return this.demande;
            }
            set
            {
                this.demande = value;
            }
        }

        public DateTime Date_naissance
        {
            get
            {
                return this.date_naissance;
            }
            set
            {
                this.date_naissance = value;
            }
        }

        public DateTime Date_prem
        {
            get
            {
                return this.date_prem;
            }
            set
            {
                this.date_prem = value;
            }
        }

        public string Grade
        {
            get
            {
                return this.grade;
            }
            set
            {
                this.grade = value;
            }
        }
        public  void affich_employ()
        {
            Console.WriteLine(this.nom + " " + this.prenom + " né le " + this.date_naissance + " est un : " + this.grade );
        }
        public bool meme_employé(Employé e)
        {
            if (this.num_sec_social==e.sec_soc)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public override bool Equals(object obj)
        {
            if (obj==null)
            {
                return false;
            }
            Employé emp = obj as Employé;
            return (this.num_sec_social == emp.sec_soc);
        }
    }
}
