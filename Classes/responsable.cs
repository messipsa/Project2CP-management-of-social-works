using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

public class responsable
{
    public static double tresor;
    public static Dictionary<int, Employé> liste_employes = new Dictionary<int, Employé>();
    public static Dictionary<int, Type_pret> liste_types = new Dictionary<int, Type_pret>();
    public static Dictionary<int, Archive> liste_archives = new Dictionary<int, Archive>();
    public static Dictionary<int, Pret_remboursable> liste_pret_remboursable = new Dictionary<int, Pret_remboursable>();
    public static Dictionary<int, Pret_non_remboursable> liste_pret_Non_Remboursables = new Dictionary<int, Pret_non_remboursable>();


    public void ajouter_pret ()
    {

    }
}
