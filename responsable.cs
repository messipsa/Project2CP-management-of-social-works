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
        public static int cle_liste_types = 1;                 // des attributs statiques permettant de donner des
        public static int cle_liste_pret_remboursable = 1;            // cles uniques aux differents dictionnaires 
        public static int cle_liste_non_remboursable = 1;                 // utilisés en s'incrémentant à chaque ajout
        public static int cle_liste_employe = 1;                             // les clés se sont gérées par nous et pas selon l'introduction
        public static int cle_liste_archive = 1;                                     // de l'utilisateur.
        public static Dictionary<int, Employé> liste_employes = new Dictionary<int, Employé>();
        public static Dictionary<int, Type_pret> liste_types = new Dictionary<int, Type_pret>();
        public static Dictionary<int, Archive> liste_archives = new Dictionary<int, Archive>();
        public static Dictionary<int, Pret_remboursable> liste_pret_remboursable = new Dictionary<int, Pret_remboursable>();
        public static Dictionary<int, Pret_non_remboursable> liste_pret_Non_Remboursables = new Dictionary<int, Pret_non_remboursable>();
        public responsable ()
        {

        }
        public static void affiche_liste_employes()
        {
            foreach (KeyValuePair<int, Employé> liste in responsable.liste_employes)
            {
                Console.Write("Clé = " + liste.Key + " ||  ");
                liste.Value.affiche_attribus();
            }
        }

        public static void affiche_liste_archive()
        {
            foreach (KeyValuePair<int, Archive> liste in responsable.liste_archives)
            {
                Console.WriteLine("*********************************");
                Console.WriteLine("Clé = " + liste.Key + " || ");
                liste.Value.affiche_attribue();
            }
        }

        public static void affiche_liste_type_pret()
        {
            foreach (KeyValuePair<int, Type_pret> liste in responsable.liste_types)
            {
                Console.WriteLine("*********************************");
                Console.WriteLine("Clé = " + liste.Key + " || ");
                liste.Value.affiche_attribus();
            }
        }
        public static void affiche_liste_pret_remboursable()
        {
            foreach (KeyValuePair<int, Pret_remboursable> liste in responsable.liste_pret_remboursable)
            {
                Console.WriteLine("*********************************");
                Console.WriteLine("Clé = " + liste.Key + " || ");
                liste.Value.affiche_attributs_complets();
            }
        }
        public static void affiche_liste_pret_non_remboursable()
        {
            foreach (KeyValuePair<int, Pret_non_remboursable> liste in responsable.liste_pret_Non_Remboursables)
            {
                Console.WriteLine("*********************************");
                Console.WriteLine("Clé = " + liste.Key + " || ");
                liste.Value.affiche_attribus();
            }
        }

        public static void ajouter_employe(  Employé b)
        {
            
            if (!(liste_employes.ContainsValue(b)))
                {
                liste_employes.Add(cle_liste_employe, b);
                cle_liste_employe++;
              }
            else
            {
                Console.WriteLine("pas d'ajout");
            }
        }
        public static void ajouter_type_pret(Type_pret b)
        {
            
            if (!(liste_types.ContainsValue(b)))
            {

                liste_types.Add(cle_liste_types, b);
                cle_liste_types++;
            }
            else
            {
                Console.WriteLine("pas d'ajout");
            }
        }
        public static void ajouter_pret_remboursable(Pret_remboursable b)
        {
           
            if (!(liste_pret_remboursable.ContainsValue(b)))
            {
                liste_pret_remboursable.Add(cle_liste_pret_remboursable, b);
                cle_liste_pret_remboursable++;
            }
            else
            {
                Console.WriteLine("pas d'ajout");
            }
        }
        public static void ajouter_pret_non_remboursable(Pret_non_remboursable b)
        {
            
            if (!(liste_pret_Non_Remboursables.ContainsValue(b)))
            {
                liste_pret_Non_Remboursables.Add(cle_liste_non_remboursable, b);
                cle_liste_non_remboursable++;
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
                if(kvp.Value.Equals(e))
                {
                    Console.WriteLine(kvp.Key);
                }
                
            }

            

        }
        
    }
}
