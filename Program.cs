using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Employé emp1 = new Employé("KHELOUAT", "BOUALAM", "001245896", d1, d2, "MAITRE ASSISTANT B", "2020248", "87","0777256478", true);
            Employé emp2 = new Employé("Haddadou", "hamid", "001248896", d3, d4, "MAITRE de Conferences A", "20278548", "56","05565178965", false);
            // emp1.affich_employ();
            
            Employé emp3 = new Employé("KHELOUAT", "BOUALAM", "001245896", d1, d2, "MAITRE ASSISTANT B", "2020248", "87", "0777256478", true);
            //responsable.liste_employes.Add(4, emp1);
            /*if (emp3.meme_employé(emp1))
            {
                Console.WriteLine("massi");
            }
            else
            {
                Console.WriteLine("massipsa 8086");
            }*/
           // responsable.liste_employes.Add(5, emp2);
            /*Dictionary<int, Employé> ls = new Dictionary<int, Employé>();
            ls.Add(1, emp1);
            ls.Add(2, emp2);*/
            /*foreach (Employé e in ls.Values)
            {
                Console.WriteLine(e.Grade);
            }*/
            //emp2.affich_employ();

            responsable.aj_emp( emp1);
            responsable.aj_emp(emp2);
            responsable.get_cle(responsable.liste_employes, emp1);
            responsable.get_cle(responsable.liste_employes, emp2);
            responsable.afficher_liste_employ();
            /*foreach (Employé e in responsable.liste_employes.Values)
            {
                Console.WriteLine(e.Grade);
            }*/
            Type_pret pret_sociale = new Type_pret(1);
            pret_sociale.Description = "rembousrsable";
            pret_sociale.Disponibilité = 1;
            pret_sociale.Remboursable = 1;
            double[] tab = new double[10];
            DateTime d6 = new DateTime(2019, 3, 9, 18, 12, 53);
            DateTime d7 = new DateTime(2019, 3, 9, 18, 12, 53);
            Pret_remboursable p1 = new Pret_remboursable(emp1, 26000, tab, 1, pret_sociale, d6, -1);
            Pret_remboursable p2 = new Pret_remboursable(emp1, 26000, tab, 1, pret_sociale, d7, -1);
            if(p1.meme_pret(p2))
            {
                Console.WriteLine("ils sont egaux");
            }
            else
            {
                Console.WriteLine("non");
            }
            responsable.liste_pret_remboursable.Add(1, p1);
            Type_pret pret_electroménager = new Type_pret(2);
            Type_pret pret_electroménagere = new Type_pret(2);
           pret_electroménagere.Remboursable = 21;
            pret_sociale.Description = "refrigérateur";
            pret_sociale.Disponibilité = 1;
            pret_sociale.Remboursable = 1;
            double[] tab1 = new double[10];
            DateTime d8 = new DateTime(2009, 11, 10, 17, 32, 03);
            //Pret_remboursable p2 = new Pret_remboursable(emp2, 32000, tab1, 1, pret_electroménager, d7, -1);
            responsable.liste_pret_remboursable.Add(2, p2);
            string a = "a";
            string b = "a";
            if(a==b)
            {
                Console.WriteLine("salim");
            }
            Employé e = null;
            //Employé e1 = responsable.liste_employes.
            Console.WriteLine(pret_electroménagere.Equals(pret_electroménager));
            Console.ReadLine();
        }

        
    }
}
