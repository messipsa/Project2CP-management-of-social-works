using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prjp
{
    public class Type_pret
    {
        private int type_du_pret;
        private int disponibilité;
        private string description;
        private int remboursable;

        public Type_pret(int type_du_pret)
        {
            this.type_du_pret = type_du_pret;
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
