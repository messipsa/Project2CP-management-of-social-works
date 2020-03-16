using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Pret_remboursable : Prets
{
    private DateTime date_premier_paiment;
    private Type_pret type_pret;
    private int en_cours;
    private int[] etat_rembouressement = new int [12];
    private int debordement;

    public Pret_remboursable(Employé employe,double montant , int[] mois ,int en_cours , Type_pret type_pret, DateTime date_premier_paiment,int debordement):base(employe,montant)
    {
        this.etat_rembouressement = mois;
        this.date_premier_paiment = date_premier_paiment;
        this.en_cours = en_cours;
        this.type_pret = type_pret;
        this.debordement = debordement;
    }
    public int[] Etat_Rembouressement
    {
        get
        {
            return this.etat_rembouressement;
        }
        set
        {
            this.etat_rembouressement = value;
        }
    }
    public Type_pret Type_prets
    {
        get
        {
            return this.type_pret;
        }
        set
        {
            this.type_pret = value;
        }
    }

    public int En_cours
    {
        get
        {
            return this.en_cours;
        }
        set
        {
            this.en_cours = value;
        }
    }

    public DateTime Date_premier_paiment
    {
        get
        {
            return this.date_premier_paiment;
        }
        set
        {
            this.date_premier_paiment = value;
        }
    }

    public int Debordement
    {
        get
        {
            return this.debordement;
        }
        set
        {
            this.debordement = value;
        }
    }
}

