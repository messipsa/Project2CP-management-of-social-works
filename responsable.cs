using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

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
        public static Dictionary<int, Pret_remboursable> liste_pret_remboursable_provisoire = new Dictionary<int, Pret_remboursable>();
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
                liste_employes.Add(b.Cle, b);
                //cle_liste_employe++;
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

                liste_types.Add(b.Type_de_pret, b);
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
                liste_pret_remboursable.Add(b.Cle, b);
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
                liste_pret_Non_Remboursables.Add(b.Cle, b);
                cle_liste_non_remboursable++;
            }
            else
            {
                Console.WriteLine("pas d'ajout");
            }
        }
        public static void suivi()
        {
            foreach ( Pret_remboursable p in responsable.liste_pret_remboursable.Values)
            {
                p.paiement();
                

            }
            foreach(KeyValuePair<int,Pret_remboursable> element in responsable.liste_pret_remboursable_provisoire)
            {
                responsable.liste_pret_remboursable.Add(element.Key, element.Value);
            }
            foreach (KeyValuePair<int, Pret_remboursable> element in responsable.liste_pret_remboursable)
            {
                responsable.liste_pret_remboursable_provisoire.Remove(element.Key);
            }
        }
        public static void paiement_anticipé(Pret_remboursable p)
        {
            
                p.paiement_anticipé();
            foreach (KeyValuePair<int, Pret_remboursable> element in responsable.liste_pret_remboursable_provisoire)
            {
                responsable.liste_pret_remboursable.Add(element.Key, element.Value);
            }
            foreach (KeyValuePair<int, Pret_remboursable> element in responsable.liste_pret_remboursable)
            {
                responsable.liste_pret_remboursable_provisoire.Remove(element.Key);
            }
        }

        public static void retardement(Pret_remboursable p)
        {
            p.retardement();
        }
        /*  public static void paiement_anticipé(Pret_remboursable pret)
          {
              foreach (Pret_remboursable p in responsable.liste_pret_remboursable.Values)
              {
                  if (p.Equals(pret))
                      {
                      p.paiement_anticipé();
                  }

              }
              foreach (KeyValuePair<int, Pret_remboursable> element in responsable.liste_pret_remboursable_provisoire)
              {
                  responsable.liste_pret_remboursable.Add(element.Key, element.Value);
              }
              foreach (KeyValuePair<int, Pret_remboursable> element in responsable.liste_pret_remboursable)
              {
                  responsable.liste_pret_remboursable_provisoire.Remove(element.Key);
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



          }*/
        public static void retardement_paiement(Pret_remboursable p)
        {
            p.retardement();
        }

        public static int cle_a_affecter_employe()
        {
            int cpt = 1;
           foreach(KeyValuePair <int , Employé> kvp in liste_employes)
            {
                if(kvp.Key >= cpt)
                {
                    cpt = kvp.Key+1;
                }
            }
            return cpt;
        }
        public static int cle_a_affecter_pret_remboursable()
        {
            int cpt = 1;
            foreach (KeyValuePair<int, Pret_remboursable> kvp in liste_pret_remboursable)
            {
                if (kvp.Key >= cpt)
                {
                    cpt = kvp.Key + 1;
                }
            }
            return cpt;
        }
        public static int cle_a_affecter_pret_non_remboursable()
        {
            int cpt = 1;
            foreach (KeyValuePair<int, Pret_non_remboursable> kvp in liste_pret_Non_Remboursables)
            {
                if (kvp.Key >= cpt)
                {
                    cpt = kvp.Key + 1;
                }
            }
            return cpt;
        }
        public static int cle_a_affecter_type_pret()
        {
            int cpt = 1;
            foreach (KeyValuePair<int, Type_pret> kvp in liste_types)
            {
                if (kvp.Key >= cpt)
                {
                    cpt = kvp.Key + 1;
                }
            }
            return cpt;
        }
        public static Pret_remboursable Creer_pret_remboursable(Employé employé, Type_pret type, string motif, int num_pv, DateTime date_pv, double montant, DateTime date_demande, string montant_lettre, DateTime date_premier_paiment, int en_cours, Dictionary<int, double> dico, int debordement)
        {
            int cle = cle_a_affecter_pret_remboursable();
            Pret_remboursable p = new Pret_remboursable(cle, employé, type, motif, num_pv, date_pv, montant, date_demande, montant_lettre, date_premier_paiment, en_cours, dico, debordement);
            return p;
        }
       
        
        public static Pret_non_remboursable Creer_pret_non_remboursable(Employé employé, Type_pret type, string motif, int num_pv, DateTime date_pv, double montant, DateTime date_demande, string montant_lettre)
        {
            int cle = cle_a_affecter_pret_non_remboursable();
            Pret_non_remboursable p = new Pret_non_remboursable(cle, employé, type, motif, num_pv, date_pv, montant, date_demande, montant_lettre);
            return p;
        }
        
        public static Type_pret Creer_Type_pret(int dispo, string descri, int remboursable)
        {
            int cle = cle_a_affecter_type_pret();
            Type_pret p = new Type_pret(cle, dispo, descri, remboursable);
            return p;
        }

        public static Employé Creer_employe(string matricule, string nom, string prenom, string num_sec_social, DateTime date_naissance, string grade, DateTime date_prem, string etat, string ccp, string cle_ccp, string tel, bool demande)
        {
            int cle = cle_a_affecter_employe();
            Employé p = new Employé(cle, matricule, nom, prenom, num_sec_social, date_naissance, grade, date_prem, etat, ccp, cle_ccp, tel, demande);
            return p;
         }

    }
}
