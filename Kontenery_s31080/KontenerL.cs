namespace Kontenery_s31080;

public class KontenerL(double wysokosc, double masaWlasna, double glebokosc, double ladownosc) : 
    Kontener(wysokosc, masaWlasna, glebokosc, ladownosc), IHazardNotifier
{
    
    private static int Licznik = 1;
    public string NumerSeryjny { get; set; } = $"KON-L-{Licznik++}";
    public List<LadunekL> Ladunki { get; set; } = new List<LadunekL>();
    
    
    public void Zaladuj(LadunekL ladunek)
    {
        try
        {
            if (!Ladunki.Any(l => l.CzyNiebezpieczny))
            {
                if (this.MasaLadunku + ladunek.Masa <= 0.9 * this.Ladownosc)
                {
                    this.MasaLadunku += ladunek.Masa;
                    Ladunki.Add(ladunek);
                    
                    Console.WriteLine($"\n[INFO]\nZALADOWANO {ladunek.Nazwa} na " +
                                      $"{this.NumerSeryjny}");
                }
                else
                {
                    throw new OverfillException();
                }
            }
            else
            {
                if (this.MasaLadunku + ladunek.Masa <= 0.5 * this.Ladownosc)
                {
                    this.MasaLadunku += ladunek.Masa;
                    Ladunki.Add(ladunek);
                }
                else
                {
                    NotifyHazard(NumerSeryjny);
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

    }
    
    public void Oproznij()
    {
        this.MasaLadunku = 0;
        this.Ladunki.Clear();

        Console.WriteLine($"\n[INFO]\nOPROZNIONO {this.NumerSeryjny}");
    }

    public override string Nazwa()
    {
        return this.NumerSeryjny;;
    }

    public void NotifyHazard(string numerKontenera)
    {
        Console.WriteLine($"\n[UWAGA]\nPROBA WYKONANIA NIEBEZPIECZNEJ SYTUACJI NA {numerKontenera}");
    }

    public override string ToString()
    {
        string ladunki = "";
        if (this.Ladunki.Any())
        {
            for (int i = 0; i < this.Ladunki.Count; i++)
            {
                ladunki += $"\n{this.Ladunki[i].ToString()} ";
            }

            return $"\n[INFO]\n{this.NumerSeryjny}\n" +
                   $"MASA: {this.MasaLadunku}kg\n" +
                   $"-----LADUNKI:{ladunki}\n-----------";
        }
        else
        {
            return $"\n[INFO]\n{this.NumerSeryjny}\n" +
                   $"MASA: {this.MasaLadunku}kg\n" +
                   $"-----LADUNKI:\nBRAK\n-----------";
        }
    }
}