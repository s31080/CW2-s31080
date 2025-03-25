using System.Security.AccessControl;

namespace Kontenery_s31080;

public class Kontenerowiec(double maxPredkosc, int maxIloscKontenerow, double maxLadownosc)
{
    
    private static int Licznik = 1;
    string NumerSeryjny = $"KONTENEROWIEC-{Licznik++}";
    public List<Kontener> Kontenery = new List<Kontener>();
    public double MaxPredkosc { get; set; } = maxPredkosc;
    public int MaxIloscKontenetow { get; set; } = maxIloscKontenerow;
    public double MaxLadownosc { get; set; } = maxLadownosc;
    public double MasaLadunku { get; set; }

    
    

    public void Zaladuj(Kontener kontener)
    {
        try
        {
            if (this.Kontenery.Count < this.MaxIloscKontenetow &&
                this.MaxLadownosc * 1000 > this.MasaLadunku + 
                kontener.MasaLadunku + kontener.MasaWlasna && !kontener.CzyNaStatku)
            {
                Kontenery.Add(kontener);
                kontener.CzyNaStatku = true;
                this.MasaLadunku += kontener.MasaLadunku + kontener.MasaLadunku;
                
                Console.WriteLine($"\n[AKCJA]\nZALADOWANO {kontener.Nazwa()} na " +
                                  $"{this.NumerSeryjny}");
            }
            else
            {
                throw new OverfillException();
            }
        }
        catch (OverfillException e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public void UsunKontener(Kontener kontener)
    {
        try
        {
            if (this.Kontenery.Contains(kontener))
            {
                this.Kontenery.Remove(kontener);
                
                Console.WriteLine($"\n[AKCJA]\nUSUNIETO {kontener.Nazwa()}");
            }
            else
            {
                throw new LackOnListEception();
            }
        }
        catch(LackOnListEception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public void ZastapKontener(Kontener staryKontener, Kontener nowyKontener)
    {
        try
        {
            if (this.Kontenery.Contains(staryKontener) && !nowyKontener.CzyNaStatku)
            {
                this.Kontenery.Remove(staryKontener);
                staryKontener.CzyNaStatku = false;
                this.Kontenery.Add(nowyKontener);
                nowyKontener.CzyNaStatku = true;
                Console.WriteLine($"\n[AKCJA]\nZASTAPIONO {staryKontener.Nazwa()} na " +
                                  $"{nowyKontener.Nazwa()}");
            }
            else
            {
                throw new LackOnListEception();
            }
        }
        catch (LackOnListEception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public void PrzeniesKontener(Kontener kontener, Kontenerowiec nowyKontenerowiec)
    {
        try
        {
            if (this.Kontenery.Contains(kontener))
            {
                this.Kontenery.Remove(kontener);
                nowyKontenerowiec.Kontenery.Add(kontener);
                Console.WriteLine($"\n[AKCJA]\nPRZENIESIONO {kontener.Nazwa()} z " +
                                  $"{this.NumerSeryjny} na {nowyKontenerowiec.NumerSeryjny}");
            }
            else
            {
                throw new LackOnListEception();
            }
        }
        catch (LackOnListEception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public override string ToString()
    {
        string ladunek = "";
        for (int i = 0; i < this.Kontenery.Count; i++)
        {
            ladunek += $"\n{this.Kontenery[i].Nazwa()}";
        }

        return $"\n[INFO]\n{this.NumerSeryjny}" +
               $"\nMAX PREDKOSC: {this.MaxPredkosc} wezlow" +
               $"\nMASA LADUNKOW: {this.MasaLadunku} kg" +
               $"\nLADOWNOSC: {this.MaxLadownosc} ton" +
               $"\n-----LADUNEK:{ladunek}" +
               $"\n-----------";
    }
}