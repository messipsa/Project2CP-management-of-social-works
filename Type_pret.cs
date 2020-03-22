using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prjp
{
    public class Type_pret
    {
        private static int num_type =1;
        private int type_du_pret;
        private int disponibilité;
        private string description;
        private int remboursable;

        public Type_pret( int dispo, string descri, int remboursable)
        {
            this.type_du_pret = Type_pret.num_type;
            this.disponibilité = dispo;
            this.description = descri;
            this.remboursable = remboursable;
            responsable.ajouter_type_pret(this);
            Type_pret.num_type++;
        }

        public void affiche_attribus()
        {
            Console.WriteLine(this.type_du_pret + " | " + this.disponibilité + " | " + this.Description + " | " + this.remboursable);
        }

        public int Type_de_pret
        {
            get
            {
                return this.type_du_pret;
            }
            set
            {
                this.type_du_pret = value;
            }
        }

        public int Disponibilité
        {
            get
            {
                return this.disponibilité;
            }
            set
            {
                this.disponibilité = value;
            }
        }

        public string Description
        {
            get
            {
                return this.description;
            }
            set
            {
                this.description = value;
            }
        }

        public int Remboursable
        {
            get
            {
                return this.remboursable;
            }
            set
            {
                this.remboursable = value;
            }
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            Type_pret p = obj as Type_pret;
            return ((this.type_du_pret == p.Type_de_pret)&&(this.remboursable==p.Remboursable)&&(this.disponibilité==p.Disponibilité)&&(this.description==this.Description));
        }
    }
}
