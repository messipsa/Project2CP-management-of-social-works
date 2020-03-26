using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace Prjp
{
    class Program
    {
        public static void Main(string[] args)
        {
            
            DateTime d1 = new DateTime(1957, 12, 22, 14, 30, 20);
            DateTime d2 = new DateTime(2015, 6,29, 9, 32, 40);
            DateTime d3 = new DateTime(1970, 1, 24, 22, 00, 00);
            DateTime d4 = new DateTime(2007, 4, 19, 8, 2, 6);
            Employé emp1 = new Employé(1,"1818", "hadadou", "hamid", "12121212", d3, "maa", d2, "marié", "12154847845", "23", "0777777845", true);
            Employé emp2 = new Employé(2,"17718", "ait amrane", "lyes", "1218569", d1, "maa", d4, "marié", "125458845", "25", "07448915", false);
            Type_pret t1 = new Type_pret(1,1, "pret social", 1);
            Type_pret t2 = new Type_pret(2,0, "pret electromenager", 1);
            Type_pret t3 = new Type_pret(3,1, "don", 0);
            
            Dictionary<int, double> dico = new Dictionary<int, double>();
            Dictionary<int, double> dicoo = new Dictionary<int, double>();
            for (int i=0;i<10;i++)
            {
                dico.Add(i, -1);
            }
            dicoo.Add(0, 0);
            dicoo.Add(1, 5500);
            for (int i = 2; i < 10; i++)
            {
                dicoo.Add(i, -1);
            }
            Pret_remboursable p = (Pret_remboursable)responsable.Creer_pret_remboursable(emp1, t1, "demenagement", 25, d2, 71000, d4, "71000", d2, 1, dico, -1);
          
            Pret_remboursable pp = responsable.Creer_pret_remboursable(emp2, t1, "achat de maison", 25, d2, 55000, d4, "55000", d2, 1, dicoo, -1);
         for(int i =0;i<24;i++)
            {
                pp.retardement();
                responsable.suivi();
            }
            //responsable.suivi();
            //responsable.suivi();
          responsable.suivi();
            //pp.retardement();
            responsable.suivi();
            for (int i = 0; i < 11; i++)
            {
                //pp.retardement();
                //responsable.suivi();
            }
            responsable.paiement_anticipé(pp);
            //responsable.suivi();
            // responsable.suivi();
            //responsable.suivi();
            //responsable.suivi();
            //responsable.suivi();
            //responsable.suivi();
            //pp.retardement();
            //responsable.suivi();
            //responsable.suivi();
            //responsable.suivi();
            // responsable.suivi();
            responsable.affiche_liste_pret_remboursable();
            // Pret_remboursable p1 = new Pret_remboursable(emp2, t2, "mariage", 2725, d2, 25000, d2, "25000", d2, 1,dico,-1) ;
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
            }
           // Pret_remboursable p47 = new Pret_remboursable(2,emp1, t1, "mariage", 2225, d1, 33000, d1, "33000", d1, 1, dico2, -1);
            //Pret_remboursable p48 = new Pret_remboursable(3,emp1, t1, "mariage", 2225, d1,17000, d1, "17000", d1, 1, dico3, -1);
           // Console.WriteLine(p48.Mois_actuel);
           //responsable.suivi();
           /* p48.retardement();
            responsable.suivi();
            responsable.suivi();
           responsable.suivi();
          p48.retardement();
            responsable.suivi();*/
         /* //  responsable.suivi();*/
            //p48.retardement();
            //responsable.suivi();
           // responsable.suivi();*/
            // responsable.suivi();
             //p48.paiement_anticipé();

             //responsable.suivi();
            //responsable.suivi();
            // responsable.suivi();
            /* responsable.suivi();
            responsable.suivi();
             responsable.suivi();*/
            /// p47.paiement_anticipé();
            //p48.paiement_anticipé();
            /*responsable.suivi();
              responsable.suivi();
              p1.retardement();
              p1.retardement();
              p1.retardement();
              p1.retardement();
              p1.retardement();
              p1.retardement();
              p1.retardement();
              responsable.suivi();
              responsable.suivi();
              responsable.paiement_anticipé(p1);
          //p47.paiement_anticipé();
       //iement_anticipé();
              Console.WriteLine(p48.Mois_actuel);
            //responsable.suivi();
              Console.WriteLine(p48.Mois_actuel);
           // p48.paiement_anticipé();
             //responsable.suivi();
              // responsable.suivi();
              /* p1.retardement();
               p47.retardement();
               responsable.suivi();
               responsable.suivi();
               p1.retardement();
               responsable.suivi();
               p1.retardement();
               responsable.suivi();
               p1.retardement();
               responsable.suivi();
               responsable.suivi();
               p1.retardement();
               responsable.suivi();
                responsable.suivi();
               responsable.suivi();
               responsable.suivi();
               p1.retardement();*/
            // responsable.suivi();






           // Pret_non_remboursable p2 = new Pret_non_remboursable(1,emp2, t3, "efondrement de maison", 2725, d1, 45200, d1, "45200");
            //Pret_non_remboursable p5 = new Pret_non_remboursable(2,emp2, t3, "maladie grave", 2725, d2, 4200, d2, "4200");
           // responsable.affiche_liste_type_pret();
            //responsable.affiche_liste_employes();
           // responsable.affiche_liste_pret_non_remboursable();
            //
            
            //responsable.affiche_liste_pret_remboursable();
           // emp2.affiche_liste_pret_remboursable_employe();
           // emp2.affiche_liste_pret_non_remboursable_employe();
            Console.ReadLine();
        }

        
    }
}
