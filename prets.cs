using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prjp
{
    abstract public class Prets
    {
        protected Employé employé;
        protected string motif;
        protected Double somme;
        protected DateTime date_demande;
        protected string somme_lettre;


        public Prets(Employé employe, Double montant)
        {
            this.employé = employe;
            this.somme = montant;

        }

        public Employé Employé
        {

            get
            {
                return this.employé;
            }
            set
            {
                this.employé = value;
            }
        }


        public Double Somme
        {
            get
            {
                return this.somme;
            }
            set
            {
                this.somme = value;
            }
        }

        public string Motif
        {
            get
            {
                return this.motif;
            }
            set
            {
                this.motif = value;
            }
        }

        public DateTime Date_demande
        {
            get
            {
                return this.date_demande;
            }
            set
            {
                this.date_demande = value;
            }
        }

        public string Somme_lettre
        {
            get
            {
                return this.somme_lettre;
            }
            set
            {
                this.somme_lettre = value;
            }
        }
       /* public override bool Equals(object obj)
        {
            Prets p = obj as Prets;
            if(p==null)
            {
                return false;
            }
            return(this.)
        }*/

    }



    }
