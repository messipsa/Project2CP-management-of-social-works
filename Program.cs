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
            
            Employé emp1 = new Employé("1818", "hadadou", "hamid", "12121212", d3, "maa", d2, "marié", "12154847845", "23", "0777777845", true);
            Employé emp2 = new Employé("17718", "ait amrane", "lyes", "1218569", d1, "maa", d4, "marié", "125458845", "25", "07448915", false);
            Type_pret t1 = new Type_pret(1, "pret social", 1);
            Type_pret t2 = new Type_pret(0, "pret electromenager", 1);
            Type_pret t3 = new Type_pret(1, "don", 0);
            double[] tab = new double[10];
            Pret_remboursable p1 = new Pret_remboursable(emp2, t2, "mariage", 2725, d2, 25000, d4, "25000", d3, 1,tab,-1) ;
            Pret_non_remboursable p2 = new Pret_non_remboursable(emp2, t3, "efondrement de maison", 2725, d2, 45200, d2, "45200");
            Pret_non_remboursable p5 = new Pret_non_remboursable(emp2, t3, "maladie grave", 2725, d2, 4200, d2, "4200");
            responsable.affiche_liste_type_pret();
            responsable.affiche_liste_employes();
            responsable.affiche_liste_pret_non_remboursable();
            responsable.affiche_liste_pret_remboursable();
            emp2.affiche_liste_pret_remboursable();
            emp2.affiche_liste_pret_non_remboursable();
            Console.ReadLine();
        }

        
    }
}
