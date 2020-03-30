using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Data.OleDb;
using System.Data.SqlClient;


namespace Prjp
{
    class Program
    {
        public static void Main(string[] args)
        {
           // responsable.affiche_liste_type_pret();
           // responsable.affiche_liste_pret_remboursable();
            responsable.initialiser_dictionnaire_employes();
             
           // responsable.affiche_liste_employes();
            responsable.initialiser_dictionnaire_archive();
            // responsable.affiche_liste_archive();
           responsable.initialiser_dictionnaire_types_prets();
            //responsable.affiche_liste_type_pret();
          

             responsable.initialiser_dictionnaire_pret_non_remboursable();
           // responsable.affiche_liste_pret_non_remboursable();
            responsable.initialiser_dictionnaire_pret_remboursable();
            responsable.liste_pret_remboursable.Remove(4);
         //  responsable.affiche_liste_pret_remboursable();
            responsable.suivi();
          /*  responsable.retardement_paiement(2);
            responsable.suivi();*/
            /*responsable.paiement_anticipé(10);
            responsable.suivi();
           responsable.suivi();
            responsable.retardement_paiement(9);
            responsable.suivi();
           responsable.retardement_paiement(9);
            responsable.suivi();
           for(int i=0;i<6;i++)
            {
                responsable.retardement_paiement(9);
                responsable.suivi();
            }
            responsable.paiement_anticipé(9);
            responsable.suivi();*/

            responsable.affiche_liste_pret_remboursable();

            /*DateTime d1 = new DateTime(1957, 12, 22, 14, 30, 20);
            DateTime d2 = new DateTime(2015, 6,29, 9, 32, 40);
            DateTime d3 = new DateTime(1970, 1, 24, 22, 00, 00);
            DateTime d4 = new DateTime(2007, 4, 19, 8, 2, 6);
            Employé emp1 = new Employé(1,"1818", "hadadou", "hamid", "12121212", d3, "maa", d2, "marié", "12154847845", "23", "0777777845", true);
            Employé emp2 = new Employé(2,"17718", "ait amrane", "lyes", "1218569", d1, "maa", d4, "marié", "125458845", "25", "07448915", false);
            Type_pret t1 = new Type_pret(100,1,1, "pret social", 1);
            Type_pret t2 = new Type_pret(200,2, 0, "pret electromenager", 1) ;
            Type_pret t3 = new Type_pret(400,3,1, "don", 0);
            
            
            Dictionary<int, double> dico = new Dictionary<int, double>();
            Dictionary<int, double> dicoo = new Dictionary<int, double>();
            for (int i=0;i<10;i++)
            {
                dico.Add(i, -1);
            }
            dicoo.Add(0, 0);
            dicoo.Add(1, 11000);
            for (int i = 2; i < 10; i++)
            {
                dicoo.Add(i, -1);
            }

            Pret_remboursable p = (Pret_remboursable)responsable.Creer_pret_remboursable(emp1, t1, "demenagement", 25, d2, 70000, d4, "70000", d2,11, 1, dico, -1);
            Pret_remboursable p1 = (Pret_remboursable)responsable.Creer_pret_remboursable(emp2, t2, "achat vehicule", 25, d2, 120000, d4, "120000", d2, 150, 1, dico, -1);
            // responsable.suivi();
            //responsable.suivi();
            //responsable.suivi();
            responsable.liste_pret_remboursable.Add(p.Cle, p);
            //responsable.liste_pret_remboursable.Add(p1.Cle, p1);
            responsable.affiche_liste_pret_remboursable();
          //  responsable.ajouter_pret_remboursable(p);
           // responsable.ajouter_pret_remboursable(p1);
            for (int i = 0; i < 12; i++)
            {
               // responsable.retardement_paiement(p);
               // responsable.suivi();
                //pp.retardement();
                // responsable.suivi();
            }
            responsable.affiche_liste_pret_remboursable();
            for (int i = 0; i < 6; i++)
            {

                responsable.suivi();
                //pp.retardement();
                // responsable.suivi();
            }
            for (int i = 0; i < 4; i++)
            {

                p1.retardement();
                 responsable.suivi();
            }
            for (int i = 0; i < 6; i++)
            {

                responsable.suivi();
                //pp.retardement();
                // responsable.suivi();
            }
            //responsable.paiement_anticipé(p);
            p1.paiement_anticipé();
           // Pret_remboursable pp = responsable.Creer_pret_remboursable(emp2, t1, "achat de maison", 25, d2, 55000, d4, "55000", d2,5, 1, dicoo, -1);
            responsable.suivi();
              
           
    Dictionary<int, double> dico2 = new Dictionary<int, double>();
            dico2.Add(0, 0);
            dico2.Add(1, 0);
            for (int i = 2; i < 10; i++)
            {
                dico2.Add(i, -1);
            }
            Dictionary<int, double> dico3 = new Dictionary<int, double>();
            dico3.Add(0, 1700);
            dico3.Add(1, 1700);
            dico3.Add(2,0);
            dico3.Add(3, 1700);
            dico3.Add(4, 0);
            for (int i = 5; i < 10; i++)
            {
                dico3.Add(i, -1);
            }*/
            // Pret_remboursable p47 = new Pret_remboursable(2,emp1, t1, "mariage", 2225, d1, 33000, d1, "33000", d1, 1, dico2, -1);
            //Pret_remboursable p48 = new Pret_remboursable(3,emp1, t1, "mariage", 2225, d1,17000, d1, "17000", d1, 1, dico3, -1);

            //Pret_non_remboursable p2 = new Pret_non_remboursable(1,emp2, t3, "efondrement de maison", 2725, d1, 45200, d1, "45200");
            //Pret_non_remboursable p5 = new Pret_non_remboursable(2,emp2, t3, "maladie grave", 2725, d2, 4200, d2, "4200");
            //responsable.affiche_liste_type_pret();
            //responsable.affiche_liste_employes();
            // responsable.affiche_liste_pret_non_remboursable();
            //
            //  responsable.initialiser_dictionnaire_types_prets();
            /* Archive a1 = new Archive(1, p1, "paiement", DateTime.Now);
             Archive a2 = new Archive(2, p2, "don", DateTime.Now);
             responsable.liste_archives.Add(a1.Cle,a1);
             responsable.liste_archives.Add(a2.Cle,a2);
             responsable.affiche_liste_archive();*/
            // emp2.affiche_liste_pret_remboursable_employe();
            // emp2.affiche_liste_pret_non_remboursable_employe();

            Console.ReadLine();
        }

        
    }
}
