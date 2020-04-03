using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Data.SqlClient;

namespace Prjp
{
    public class responsable
    {
        public static double tresor;
        public static int cle_liste_types = 1;              // des attributs statiques permettant de donner des
        public static int cle_liste_pret_remboursable = 1;           // cles uniques aux differents dictionnaires 
        public static int cle_liste_non_remboursable = 1;                 // utilisés en s'incrémentant à chaque ajout
        public static int cle_liste_employe = 1;                             // les clés se sont gérées par nous et pas selon l'introduction
        public static int cle_liste_archive = 1;                                     // de l'utilisateur.
        public static Dictionary<int, Employé> liste_employes = new Dictionary<int, Employé>();
        public static Dictionary<int, Type_pret> liste_types = new Dictionary<int, Type_pret>();
        public static Dictionary<int, Archive> liste_archives = new Dictionary<int, Archive>();
        public static List<Pret_remboursable> l = new List<Pret_remboursable>();
        public static Dictionary<int, Pret_remboursable> liste_pret_remboursable = new Dictionary<int, Pret_remboursable>();
        public static Dictionary<int, Pret_non_remboursable> liste_pret_Non_Remboursables = new Dictionary<int, Pret_non_remboursable>();
        public static Dictionary<int, Pret_remboursable> liste_pret_remboursable_provisoire = new Dictionary<int, Pret_remboursable>();
        public static Dictionary<int, Archive> liste_archives_provisoire = new Dictionary<int, Archive>();
        public responsable ()
        {

        }
        public static void initialiser_dictionnaire_employes()
        {
            SqlConnection cnx = new SqlConnection("Data Source = .\\SQLEXPRESS; Initial Catalog = BDD_COS_finale_v2; Integrated Security = True");
            cnx.Open();
            SqlCommand cmd = cnx.CreateCommand();
            string commande = "SELECT COUNT(*) FROM employes;";
            int longueur_table = 0;
            cmd.CommandText = commande;
            cmd.ExecuteNonQuery();
            SqlDataReader rdr1 = cmd.ExecuteReader();
            rdr1.Read();
            longueur_table = (int)rdr1.GetValue(0);
            rdr1.Close();
            for (int i = 1; i <= longueur_table; i++)
            {
                commande = "SELECT * FROM employes WHERE cle = " + i.ToString() + " ;";
                cmd.CommandText = commande;
                cmd.ExecuteNonQuery();
                SqlDataReader rdr = cmd.ExecuteReader();
                rdr.Read();
                DateTime date_naiss = DateTime.Parse(rdr.GetValue(4).ToString());
                DateTime date_prem = DateTime.Parse(rdr.GetValue(6).ToString());
                bool demandé = false;
                if ((int)rdr.GetValue(12) == 0)
                    demandé = false;
                if ((int)rdr.GetValue(12) == 1)
                    demandé = true;
                Employé emp = new Employé((int)rdr.GetValue(0), rdr.GetValue(13).ToString(), rdr.GetValue(1).ToString(), rdr.GetValue(2).ToString(), rdr.GetValue(3).ToString(), date_naiss, rdr.GetValue(5).ToString(), date_prem, rdr.GetValue(7).ToString(), rdr.GetValue(8).ToString(), rdr.GetValue(9).ToString(), rdr.GetValue(11).ToString(), demandé);
                rdr.Close();
                responsable.liste_employes.Add(emp.Cle, emp);
            }
            cnx.Close();
        }

        public static void initialiser_dictionnaire_archive()
        {
            int longueur_table = 0;
            SqlConnection cnx = new SqlConnection("Data Source = .\\SQLEXPRESS; Initial Catalog = BDD_COS_finale_v2; Integrated Security = True");
            cnx.Open();
            SqlCommand cmd = cnx.CreateCommand();
            cmd.CommandText = "SELECT COUNT(*) FROM archive;";
            cmd.ExecuteNonQuery();
            SqlDataReader rdr1 = cmd.ExecuteReader();
            rdr1.Read();
            longueur_table = (int)rdr1.GetValue(0);
            rdr1.Close();
            cmd.Cancel();
            for (int i = 1; i <= longueur_table; i++)
            {
                SqlCommand commande = cnx.CreateCommand();
                commande.CommandText = "SELECT * FROM archive WHERE cle = " + i.ToString() + " ;";
                commande.ExecuteNonQuery();
                SqlDataReader rdr = commande.ExecuteReader();
                rdr.Read();
                float var = (float)rdr.GetDouble(9);
                if (var != -1.0)
                {
                    int id_employe = (int)rdr.GetValue(1);
                    Employé emp = responsable.liste_employes[id_employe];
                    Dictionary<int, double> mois = new Dictionary<int, double>();
                    mois.Add(0, (double)rdr.GetDouble(9));
                    mois.Add(1, (double)rdr.GetDouble(10));
                    mois.Add(2, (double)rdr.GetDouble(11));
                    mois.Add(3, (double)rdr.GetDouble(12));
                    mois.Add(4, (double)rdr.GetDouble(13));
                    mois.Add(5, (double)rdr.GetDouble(14));
                    mois.Add(6, (double)rdr.GetDouble(15));
                    mois.Add(7, (double)rdr.GetDouble(16));
                    mois.Add(8, (double)rdr.GetDouble(17));
                    mois.Add(9, (double)rdr.GetDouble(18));
                    //
                    int cle_type_pret = (int)rdr.GetValue(2);
                    SqlConnection cnx2 = new SqlConnection("Data Source = .\\SQLEXPRESS; Initial Catalog = BDD_COS_finale_v2; Integrated Security = True");
                    cnx2.Open();
                    SqlCommand cmd2 = cnx2.CreateCommand();
                    cmd2.CommandText = "SELECT * FROM type_prets WHERE cle = " + cle_type_pret.ToString() + " ;";
                    cmd2.ExecuteNonQuery();
                    SqlDataReader rdr2 = cmd2.ExecuteReader();
                    rdr2.Read();
                    Type_pret type = new Type_pret(cle_type_pret, (int)rdr2.GetValue(1), (int)rdr2.GetValue(3), rdr2.GetValue(2).ToString(), (int)rdr2.GetValue(4));
                    rdr2.Close();
                    //
                    DateTime date_pv = DateTime.Parse(rdr.GetValue(22).ToString());
                    DateTime date_demande = DateTime.Parse(rdr.GetValue(3).ToString());
                    DateTime date_premier_paiment = DateTime.Parse(rdr.GetValue(4).ToString());
                    Pret_remboursable pret = new Pret_remboursable((int)rdr.GetValue(0), emp, type, rdr.GetValue(8).ToString(), (int)rdr.GetValue(20), date_pv, (double)rdr.GetValue(5), date_demande, rdr.GetValue(6).ToString(), date_premier_paiment,10, 0, mois, (int)rdr.GetValue(21));
                    DateTime date_fin_rembourssement = DateTime.Parse(rdr.GetValue(7).ToString());
                    Archive archive = new Archive((int)rdr.GetValue(0), pret, rdr.GetValue(19).ToString(), date_fin_rembourssement);
                    responsable.liste_archives.Add(archive.Cle, archive);
                }
                else if (var == -1.0)
                {
                    int id_employe = (int)rdr.GetValue(1);
                    Employé emp = responsable.liste_employes[id_employe];
                    int cle_type_pret = (int)rdr.GetValue(2);
                    Dictionary<int, double> mois = new Dictionary<int, double>();
                    for (int k = 0; k < 10; k++)
                        mois.Add(k, -1);
                    SqlConnection cnx2 = new SqlConnection("Data Source = .\\SQLEXPRESS; Initial Catalog = BDD_COS_finale_v2; Integrated Security = True");
                    cnx2.Open();
                    SqlCommand cmd2 = cnx2.CreateCommand();
                    cmd2.CommandText = "SELECT * FROM type_prets WHERE cle = " + cle_type_pret.ToString() + " ;";
                    cmd2.ExecuteNonQuery();
                    SqlDataReader rdr2 = cmd2.ExecuteReader();
                    rdr2.Read();
                    
                    Type_pret type = new Type_pret(cle_type_pret, (int)rdr2.GetValue(1), (int)rdr2.GetValue(3), rdr2.GetValue(2).ToString(), (int)rdr2.GetValue(4));
                    
                    rdr2.Close();
                    DateTime date_pv = DateTime.Parse(rdr.GetValue(22).ToString());
                    DateTime date_demande = DateTime.Parse(rdr.GetValue(3).ToString());
                  Pret_non_remboursable pret = new Pret_non_remboursable((int)rdr.GetValue(0), emp, type, rdr.GetValue(8).ToString(), (int)rdr.GetValue(20), date_pv, (double)rdr.GetValue(5), date_demande, rdr.GetValue(6).ToString());
                    Archive archive = new Archive((int)rdr.GetValue(0), pret, rdr.GetValue(19).ToString(), date_demande);
                   responsable.liste_archives.Add(archive.Cle, archive);
                }
                rdr.Close();
            }
            cnx.Close();
        }

        public static void initialiser_dictionnaire_types_prets()
        {
            int longueur_table = 0;
            SqlConnection cnx = new SqlConnection("Data Source = .\\SQLEXPRESS; Initial Catalog = BDD_COS_finale_v2; Integrated Security = True");
            cnx.Open();
            SqlCommand cmd = cnx.CreateCommand();
            cmd.CommandText = "SELECT COUNT(*) FROM type_prets;";
            cmd.ExecuteNonQuery();
            SqlDataReader rdr1 = cmd.ExecuteReader();
            rdr1.Read();
            longueur_table = (int)rdr1.GetValue(0);
            rdr1.Close();
            SqlCommand commande = cnx.CreateCommand();
            for (int i = 1; i <= longueur_table; i++)
            {
                commande.CommandText = "SELECT * FROM type_prets WHERE cle = " + i.ToString() + " ;";
                commande.ExecuteNonQuery();
                SqlDataReader rdr = commande.ExecuteReader();
                rdr.Read();
                Type_pret type = new Type_pret((int)rdr.GetValue(0), (int)rdr.GetValue(1), (int)rdr.GetValue(3), rdr.GetValue(2).ToString(), (int)rdr.GetValue(4));
                responsable.liste_types.Add((int)rdr.GetValue(0), type);
                rdr.Close();
            }
            cnx.Close();
        }

        public static void initialiser_dictionnaire_pret_remboursable()
        {
            int longueur_table = 0;
            SqlConnection cnx = new SqlConnection("Data Source = .\\SQLEXPRESS; Initial Catalog = BDD_COS_finale_v2; Integrated Security = True");
            cnx.Open();
            SqlCommand cmd = cnx.CreateCommand();
            cmd.CommandText = "SELECT COUNT(*) FROM prets_remboursable;";
            cmd.ExecuteNonQuery();
            SqlDataReader rdr1 = cmd.ExecuteReader();
            rdr1.Read();
            longueur_table = (int)rdr1.GetValue(0);
            rdr1.Close();
            SqlCommand commande = cnx.CreateCommand();
            for (int i = 1; i <= longueur_table; i++)
            {
                commande.CommandText = "SELECT * FROM prets_remboursable WHERE cle = " + i.ToString() + " ;";
                commande.ExecuteNonQuery();
                SqlDataReader rdr = commande.ExecuteReader();
                rdr.Read();
                try
                {
                    Employé emp = responsable.liste_employes[(int)rdr.GetValue(1)];
                   // Console.WriteLine(emp.Nom);
                    Type_pret type = responsable.liste_types[(int)rdr.GetValue(2)];
                   // Console.WriteLine(type.Description);
                    DateTime date_pv = DateTime.Parse(rdr.GetValue(21).ToString());
                    DateTime date_demande = DateTime.Parse(rdr.GetValue(3).ToString());
                    DateTime date_prem_paiment = DateTime.Parse(rdr.GetValue(5).ToString());
                   // Console.WriteLine(date_pv + " " + date_demande + " " + date_prem_paiment);
                    Dictionary<int, double> mois = new Dictionary<int, double>();
                    mois.Add(0, (double)rdr.GetDouble(10));
                    mois.Add(1, (double)rdr.GetDouble(11));
                    mois.Add(2, (double)rdr.GetDouble(12));
                    mois.Add(3, (double)rdr.GetDouble(13));
                    mois.Add(4, (double)rdr.GetDouble(14));
                    mois.Add(5, (double)rdr.GetDouble(15));
                    mois.Add(6, (double)rdr.GetDouble(16));
                    mois.Add(7, (double)rdr.GetDouble(17));
                    mois.Add(8, (double)rdr.GetDouble(18));
                    mois.Add(9, (double)rdr.GetDouble(19));
                    int cpt = 0;
                   
                    Pret_remboursable pret = new Pret_remboursable((int)rdr.GetInt32(0), emp, type, rdr.GetValue(8).ToString(), (int)rdr.GetInt32(4), date_pv, (double)rdr.GetDouble(6), date_demande, rdr.GetValue(7).ToString(), date_prem_paiment,10, (int)rdr.GetInt32(9), mois, (int)rdr.GetInt32(20));
                  
                        liste_pret_remboursable.Add(pret.Cle, pret);
                        
                    
                   
                }
                catch
                {
                    longueur_table++;
                }
                
                rdr.Close();
                
            }
            cnx.Close();
        }

        public static void initialiser_dictionnaire_pret_non_remboursable()
        {
            int longueur_table = 0;
            SqlConnection cnx = new SqlConnection("Data Source = .\\SQLEXPRESS; Initial Catalog = BDD_COS_finale_v2; Integrated Security = True");
            cnx.Open();
            SqlCommand cmd = cnx.CreateCommand();
            cmd.CommandText = "SELECT COUNT(*) FROM prets_non_remboursable;";
            cmd.ExecuteNonQuery();
            SqlDataReader rdr1 = cmd.ExecuteReader();
            rdr1.Read();
            longueur_table = (int)rdr1.GetValue(0);
            rdr1.Close();
            SqlCommand commande = cnx.CreateCommand();
            for (int i = 1; i <= longueur_table; i++)
            {
                commande.CommandText = "SELECT * FROM prets_non_remboursable WHERE cle = " + i.ToString() + " ;";
                commande.ExecuteNonQuery();
                SqlDataReader rdr = commande.ExecuteReader();
                rdr.Read();
                try
                {
                    Employé emp = responsable.liste_employes[(int)rdr.GetValue(1)];
                    Type_pret type = responsable.liste_types[(int)rdr.GetValue(8)];
                    DateTime date_pv = DateTime.Parse(rdr.GetValue(7).ToString());
                    DateTime date_demande = DateTime.Parse(rdr.GetValue(2).ToString());
                    Pret_non_remboursable pret = new Pret_non_remboursable((int)rdr.GetInt32(0), emp, type, rdr.GetValue(6).ToString(), (int)rdr.GetInt32(3), date_pv, (double)rdr.GetDouble(4), date_demande, rdr.GetValue(5).ToString());
                    responsable.liste_pret_Non_Remboursables.Add((int)rdr.GetInt32(0), pret);
                    pret.Employé.ajouter_pret_non_remboursable_employe(pret);
                }
                catch
                {
                    longueur_table++;
                }
                rdr.Close();
            }
            cnx.Close();
        }
        public static void affiche_liste_employes()
        {
            foreach (KeyValuePair<int, Employé> liste in responsable.liste_employes)
            {
                Console.Write("Clé = " + liste.Key + " ||  ");
                liste.Value.affiche_attribus();
            }
        }

       /* public static void affiche_liste_archive()
        {
            foreach (KeyValuePair<int, Archive> liste in responsable.liste_archives)
            {
                Console.WriteLine("*********************************");
                Console.WriteLine("Clé = " + liste.Key + " || ");
                liste.Value.affiche_attribue();
            }
        }*/

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

        public static void affiche_liste_archive()
        {
            foreach (KeyValuePair<int, Archive> liste in responsable.liste_archives)
            {
                Console.WriteLine("*********************************");
                Console.WriteLine("Clé = " + liste.Key + " || ");
                liste.Value.affiche_attribue();
            }
        }

        public static void ajouter_employe(  Employé b)
        {
            
            if (!(liste_employes.ContainsValue(b)))
                {
                liste_employes.Add(b.Cle, b);
              }
            else
            {
                Console.WriteLine("pas d'ajout");
            }
        }
        public static void ajouter_type_pret(Type_pret b)
        {
            
            /*if (!(liste_types.ContainsValue(b)))
            {

                liste_types.Add(b.Cle, b);
            }
            else
            {
               
                Console.WriteLine(b.Cle + " " + b.Description);
                Console.WriteLine("pas d'ajout");
            }*/
            int cpt =  0;
            foreach(KeyValuePair<int,Type_pret> kvp in liste_types)
            {
                if(b.Equals(kvp.Value))
                {
                    Console.WriteLine(b.Cle + " " + b.Description);
                    cpt++;
                }

               
            }
            if(cpt==0)
            {
                liste_types.Add(b.Cle, b);
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
            }
            else
            {
                Console.WriteLine("pas d'ajout");
            }
        }

        public static void ajouter_archive(Archive b)
        {

            if (!(liste_archives.ContainsValue(b)))
            {
                liste_archives.Add(b.Cle, b);
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
        public static void paiement_anticipé(int cle)
        {

            foreach (KeyValuePair<int, Pret_remboursable> element in responsable.liste_pret_remboursable)
            {
                if (cle == element.Key)
                {
                    element.Value.paiement_anticipé();
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
        public static void ajouter_montant(Pret_remboursable p)
        {
            p.Etat.Add(p.Mois_actuel,p.Montant - p.Somme_remboursée);
        }


       
        public static void retardement_paiement(int cle)
        {
            foreach (KeyValuePair<int, Pret_remboursable> element in responsable.liste_pret_remboursable)
            {
                if (cle == element.Key)
                {
                    element.Value.retardement();
                }
            }
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
            int cpt2 = 1;
            foreach (KeyValuePair<int, Pret_remboursable> kvp in liste_pret_remboursable)
            {
                if (kvp.Key >= cpt)
                {
                    cpt = kvp.Key + 1;
                }
            }
            foreach (KeyValuePair<int, Pret_remboursable> kvp in liste_pret_remboursable_provisoire)
            {
                if (kvp.Key >= cpt)
                {
                    cpt2 = kvp.Key + 1;
                }
            }
            if(cpt>cpt2)
            {
                return cpt;
            }
            return cpt2;
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

        public static int cle_a_affecter_archive()
        {
            int cpt = 1;
            foreach (KeyValuePair<int, Archive> kvp in liste_archives)
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
        public static Pret_remboursable Creer_pret_remboursable(Employé employé, Type_pret type, string motif, int num_pv, DateTime date_pv, double montant, DateTime date_demande, string montant_lettre, DateTime date_premier_paiment, int durée ,int en_cours, Dictionary<int, double> dico, int debordement)
        {
            int cle = cle_a_affecter_pret_remboursable();
            Pret_remboursable p = new Pret_remboursable(cle, employé, type, motif, num_pv, date_pv, montant, date_demande, montant_lettre, date_premier_paiment,durée, en_cours, dico, debordement);
          //  liste_pret_remboursable.Add(p.Cle,p);
          //  p.Employé.ajouter_pret_remboursable_employe( p);
            return p;
        }
       
        
        public static Pret_non_remboursable Creer_pret_non_remboursable(Employé employé, Type_pret type, string motif, int num_pv, DateTime date_pv, double montant, DateTime date_demande, string montant_lettre)
        {
            int cle = cle_a_affecter_pret_non_remboursable();
            Pret_non_remboursable p = new Pret_non_remboursable(cle, employé, type, motif, num_pv, date_pv, montant, date_demande, montant_lettre);
            liste_pret_Non_Remboursables.Add(p.Cle, p);
            p.Employé.ajouter_pret_non_remboursable_employe(p);
            return p;
        }
        
        public static Type_pret Creer_Type_pret(int typepret,int dispo, string descri, int remboursable)
        {
            int cle = cle_a_affecter_type_pret();
            Type_pret p = new Type_pret(cle,typepret, dispo, descri, remboursable);
            liste_types.Add(p.Cle, p);
            return p;
        }

        public static Employé Creer_employe(string matricule, string nom, string prenom, string num_sec_social, DateTime date_naissance, string grade, DateTime date_prem, string etat, string ccp, string cle_ccp, string tel, bool demande)
        {
            int cle = cle_a_affecter_employe();
            Employé p = new Employé(cle, matricule, nom, prenom, num_sec_social, date_naissance, grade, date_prem, etat, ccp, cle_ccp, tel, demande);
            liste_employes.Add(p.Cle, p);
            return p;
         }

        /*public static void archiver()
        {
            foreach (KeyValuePair<int , Pret_remboursable> kvp in liste_pret_remboursable)
            { 
                 if((kvp.Value.Debordement==-1)&&(kvp.Value.Montant==kvp.Value.Somme_remboursée)&&(!(liste_archives.ContainsValue(kvp))
                {
                  
                        Archive a = new Archive(cle_a_affecter_archive(), kvp.Value, "paiement", kvp.Value.Date_actuelle);
                        liste_archives_provisoire.Add(cle_a_affecter_archive(), a);
                        liste_archives.Add(cle_a_affecter_archive(), a);
                        
                     while(kvp.Value.pere()!=null)
                    {
                        kvp.Key = kvp.Value.pere().Cle;

                    }
                }
            }
            foreach (KeyValuePair<int, Archive> kvp in liste_archives_provisoire)
            {
                liste_pret_remboursable.Remove(kvp.Value.Pret.Cle);
            }
            liste_archives_provisoire.Clear();
        }*/
        public static void archiver_pret_non_remboursable()//archivage auto apres un mois
        {
            foreach (KeyValuePair<int, Pret_non_remboursable> kvp in liste_pret_Non_Remboursables)
            {
                kvp.Value.archiver();
            }
            foreach (KeyValuePair<int, Archive> kvp in responsable.liste_archives_provisoire)
            {
                responsable.liste_pret_Non_Remboursables.Remove(kvp.Value.Pret.Cle);
            }
            responsable.liste_archives_provisoire.Clear();


        }
        public static void archiver_manuel_pret_non_remboursable(int cle)//archivage auto apres un mois
        {
            foreach (KeyValuePair<int, Pret_non_remboursable> element in responsable.liste_pret_Non_Remboursables)
            {
                Console.WriteLine(cle);
                if (cle == element.Key)
                {

                    element.Value.archiver_manuel();
                    Console.WriteLine(cle);

                }
            }
            foreach (KeyValuePair<int, Archive> kvp in responsable.liste_archives_provisoire)
            {
                responsable.liste_pret_Non_Remboursables.Remove(kvp.Value.Pret.Cle);
            }
            responsable.liste_archives_provisoire.Clear();


        }
        public static void archiver_pret_remboursable()//archivage auto apres un mois
        {
            foreach (KeyValuePair<int, Pret_remboursable> kvp in liste_pret_remboursable)
            {
                kvp.Value.archiver();
            }
            foreach (KeyValuePair<int, Archive> kvp in responsable.liste_archives_provisoire)
            {
                responsable.liste_pret_remboursable.Remove(kvp.Value.Pret.Cle);
            }
            responsable.liste_archives_provisoire.Clear();


        }
        public static void archiver_manuel_pret_remboursable(int cle) //Archiver un pret selon le voeux de l'utisitateur et ce qui est bien pour un pret
                                                       // qui s'etend sur plusieurs lignes on px citer n'imprt quel ligne pour l'archiver
        {
            foreach (KeyValuePair<int, Pret_remboursable> element in responsable.liste_pret_remboursable)
            {
                
                if (cle == element.Key)
                {
                    
                    element.Value.children();

                }
            }
            foreach (KeyValuePair<int, Archive> kvp in responsable.liste_archives_provisoire)
            {
                responsable.liste_pret_remboursable.Remove(kvp.Value.Pret.Cle);
            }
            responsable.liste_archives_provisoire.Clear();
        }

        public static void effacement_dettes(int cle)
        {
            foreach (KeyValuePair<int, Pret_remboursable> element in responsable.liste_pret_remboursable)
            {

                if (cle == element.Key)
                {

                    element.Value.children_effacement_dettes();

                }
            }
            foreach (KeyValuePair<int, Archive> kvp in responsable.liste_archives_provisoire)
            {
                responsable.liste_pret_remboursable.Remove(kvp.Value.Pret.Cle);
            }
            responsable.liste_archives_provisoire.Clear();

        }

    }
}
