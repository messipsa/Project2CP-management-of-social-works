using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Employé
{
    private string nom;
    private string prenom;
    private string num_sec_social;
    private DateTime date_naissance;
    private DateTime date_prem;
    private string grade;
    private string ccp;
    private string cle_ccp;
    private double salaire;
    private Etat etat;
    private string num_tel;
    private Boolean demande;

    private List<Prets> pret = new List<Prets>();


    public Employé(string nom,string prenom , string num_sec_social, DateTime date_naissance, DateTime date_prem, string grade, string ccp ,string cle_ccp , double salaire, Boolean demande)
    {
        this.nom = nom;
        this.prenom = prenom;
        this.num_sec_social = num_sec_social;
        this.date_naissance = date_naissance;
        this.date_prem = date_prem;
        this.grade = grade;
        this.ccp = ccp;
        this.cle_ccp = cle_ccp;
        this.salaire = salaire;
        this.ccp = ccp;
        this.demande = demande;
    }
        
    public string Nom
    {
        get
        {
            return this.nom;
        }
        set
        {
            this.nom = value;
        }
    }

    public string Prenom
    {
        get
        {
            return this.prenom;
        }
        set
        {
            this.prenom = value;
        }
    }
    public string sec_soc
    {
        get
        {
            return this.num_sec_social;
        }
        set
        {
            this.num_sec_social = value;
        }
    }
    public string compte_ccp
    {
        get
        {
            return this.ccp;
        }
        set
        {
            this.ccp = value;
        }

    }
    public string Cle_ccp
    {
        get
        {
            return this.cle_ccp;
        }
        set
        {
            this.cle_ccp = value;
        }
    }
    public double Salaire
    {
        get
        {
            return this.salaire;
        }
        set
        {
            this.salaire = value;
        }
    }
    public Etat etats
    {
        get
        {
            return this.etat;
        }
        set
        {
            this.etat = value;
        }
    }
    public string tel
    {
        get
        {
            return this.num_tel;
        }
        set
        {
            this.num_tel = value;
        }
    }
    public Boolean Demande
    {
        get
        {
            return this.demande;
        }
        set
        {
            this.demande = value;
        }
    }

    public DateTime Date_naissance
    {
        get
        {
            return this.date_naissance;
        }
        set
        {
            this.date_naissance = value;
        }
    }

    public DateTime Date_prem
    {
        get
        {
            return this.date_prem;
        }
        set
        {
            this.date_prem = value;
        }
    }

    public string Grade
    {
        get
        {
            return this.grade;
        }
        set
        {
            this.grade = value;
        }
    }
  
}
