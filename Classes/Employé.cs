using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Employé
{
    private string nom;
    private string prenom;
    private long num_sec_social;
    private DateTime date_naissance;
    private DateTime date_prem;
    private string grade;
    private string cpt_ccp;
    private int clé_ccp;
    private double salaire;
    private Etat etat;
    private string num_tel;
    private Boolean demande;

    private List<Prets> pret = new List<Prets>();


    public Employé(string nom,string prenom , string ccp ,int cle_ccp ,Boolean demande)
    {
        this.nom = nom;
        this.prenom = prenom;
        this.clé_ccp = cle_ccp;
        this.cpt_ccp = ccp;
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
    public long sec_soc
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
            return this.cpt_ccp;
        }
        set
        {
            this.cpt_ccp = value;
        }

    }
    public int cle_ccp
    {
        get
        {
            return this.clé_ccp;
        }
        set
        {
            this.clé_ccp = value;
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
