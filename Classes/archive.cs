using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Archive 
{
    private Prets pret;
	private string observations;
	private DateTime date_fin_remboursement;

	public Archive(Prets pret_ , string observations_ , DateTime date_fin_remboursement_)
	{
        this.pret = pret_;
		this.date_fin_remboursement = date_fin_remboursement_;
		this.observations = observations_;

	}

    public Prets Pret
    {
        get
        {
            return this.pret;
        }
        set
        {
            this.pret = value;
        }
    }

    public string Observations
    {
        get
        {
            return this.observations;
        }
        set
        {
            this.observations = value;
        }
    }

    public DateTime Date_fin_remboursement
    {
        get
        {
            return this.date_fin_remboursement;
        }
        set
        {
            this.date_fin_remboursement = value;
        }
    }
}
