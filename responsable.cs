using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prjp
{
    public class responsable
    {
        public static double tresor;
        public static int nb_pret = 1;
        public static int nb_rembours = 1;
        public static int nb_non_rembours = 1;
        public static int nb_emp = 1;
        public static int nb_archive = 1;
        public static Dictionary<int, Employé> liste_employes = new Dictionary<int, Employé>();
        public static Dictionary<int, Type_pret> liste_types = new Dictionary<int, Type_pret>();
        public static Dictionary<int, Archive> liste_archives = new Dictionary<int, Archive>();
        public static Dictionary<int, Pret_remboursable> liste_pret_remboursable = new Dictionary<int, Pret_remboursable>();
        public static Dictionary<int, Pret_non_remboursable> liste_pret_Non_Remboursables = new Dictionary<int, Pret_non_remboursable>();
        public responsable ()
        {

        }
        public static  void afficher_liste_employ()
        {
            foreach(Employé e in liste_employes.Values)
            {
                Console.WriteLine(e.Grade);
            }
        }
        public static void aj_emp(  Employé b)
        {
            
            if (!(liste_employes.ContainsValue(b)))
                {
                liste_employes.Add(nb_emp, b);
                nb_emp++;
              }
            else
            {
                Console.WriteLine("pas d'ajout");
            }
        }
        public static void aj_type_pret(Type_pret b)
        {
            
            if (!(liste_types.ContainsValue(b)))
            {

                liste_types.Add(nb_pret, b);
                nb_pret++;
            }
            else
            {
                Console.WriteLine("pas d'ajout");
            }
        }
        public static void aj_pret_remboursable(Pret_remboursable b)
        {
           
            if (!(liste_pret_remboursable.ContainsValue(b)))
            {
                liste_pret_remboursable.Add(nb_rembours, b);
                nb_rembours++;
            }
            else
            {
                Console.WriteLine("pas d'ajout");
            }
        }
        public static void aj_pret_non_remboursable(Pret_non_remboursable b)
        {
            
            if (!(liste_pret_Non_Remboursables.ContainsValue(b)))
            {
                liste_pret_Non_Remboursables.Add(nb_non_rembours, b);
                nb_non_rembours++;
            }
            else
            {
                Console.WriteLine("pas d'ajout");
            }
        }
        public static void get_cle (Dictionary<int, Employé> ls,Employé e)
        {
            foreach (KeyValuePair<int, Employé> kvp in ls)
            {
                if(kvp.Value.meme_employé(e))
                {
                    Console.WriteLine(kvp.Key);
                }
                
            }

            

        }
        
    }
}
