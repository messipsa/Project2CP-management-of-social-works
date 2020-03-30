using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prjp
{
    public class Pret_non_remboursable : Prets
    {
        public Pret_non_remboursable(int cle_, Employé employé, Type_pret type, string motif, int num_pv, DateTime date_pv, double montant, DateTime date_demande, string montant_lettre) : base( cle_, employé, type, motif, num_pv, date_pv, montant, date_demande, montant_lettre)
        {
           
           
            responsable.tresor = responsable.tresor - this.Montant;
          //responsable.ajouter_pret_non_remboursable(this);//ajut automatique du pret a la liste des prets non remboursables
          // this.Employé.ajouter_pret_non_remboursable_employe(this);//ajout automatique du pret a la liste des prets non remboursables de l'employe.
        }
        public override void affiche_attributs_complets()
        {
            
        }
    }
}
