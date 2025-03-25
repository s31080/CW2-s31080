namespace Kontenery_s31080;

public abstract class Kontener(double wysokosc, double masaWlasna, double glebokosc, double ladownosc)
{
    public double MasaLadunku { get; set; } = 0;
    public double Wysokosc { get; set; } = wysokosc;
    public double MasaWlasna  { get; set; } = masaWlasna;
    public double Glebokosc { get; set; } = glebokosc;
    public string NumerSeryjny { get; set; } = "TY DEBILU NIE TO";
    public bool CzyNaStatku { get; set; } = false;
    public double Ladownosc { get; set; } = ladownosc;
    
    
    

    public virtual string Nazwa()
    {
        return this.NumerSeryjny;
    }

    public override string ToString()
    {
        return "";
    }

    public void Oproznij() { }

    //public virtual void Zaladuj(Ladunek ladunek) { }
}