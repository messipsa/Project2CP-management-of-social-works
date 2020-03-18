using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

public class responsable
{
    public static List<Employé> liste_employes = new List<Employé>();
    public static List<Type_pret> liste_types = new List<Type_pret>();
    public static List<Archive> liste_archives = new List<Archive>();
    public static List<Pret_remboursable> liste_pret_remboursable = new List<Pret_remboursable>();
    public static List<Pret_non_remboursable> liste_pret_Non_Remboursables = new List<Pret_non_remboursable>();

}
