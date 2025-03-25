namespace Kontenery_s31080;

public class KontenerG(double wysokosc, double masaWlasna, double glebokosc, double ladownosc, double maxCisnienie) : 
    Kontener(wysokosc, masaWlasna, glebokosc, ladownosc), IHazardNotifier
{

    private static int Licznik = 1;
    public string NumerSeryjny { get; set; } = $"KON-G-{Licznik++}";
    public double MaxCisnienie { get; set; } = maxCisnienie;
    public double Cisnienie { get; set; } = 0;
    public LadunekG Ladunek { get; set; } = null;



    public void Zaladuj(LadunekG ladunek)
    {
        try
        {
            if (this.MasaLadunku + ladunek.Masa <= this.Ladownosc &&
                this.Cisnienie + ladunek.Cisnienie <= this.MaxCisnienie && Ladunek == null)
            {
                this.MasaLadunku += ladunek.Masa;
                this.Cisnienie += ladunek.Cisnienie;
                Ladunek = ladunek;
                
                Console.WriteLine($"\n[INFO]\nZALADOWANO {ladunek.Nazwa} na " +
                                  $"{this.NumerSeryjny}");
            }
            else
            {
                
                if (this.Ladunek != null)
                {
                    throw new OverfillException();
                }
                
                if (this.MasaLadunku + ladunek.Masa > this.Ladownosc)
                {
                    throw new OverfillException();
                }
                
                if (this.Cisnienie + ladunek.Cisnienie > this.MaxCisnienie)
                {
                    NotifyHazard(this.NumerSeryjny);
                }
            }
        }
        catch (OverfillException e)
        {
            Console.WriteLine(e.Message);
        }

    }
    
    public void Oproznij()
    {
        this.MasaLadunku = 0.05*this.MasaLadunku;
        this.Cisnienie = 0.05*this.Cisnienie;
        this.Ladunek = null;
        
        Console.WriteLine($"\n[INFO]\nOPROZNIONO {this.NumerSeryjny}");
    }

    public override string ToString()
    {
        if (this.Ladunek == null)
        {
            return $"\n[INFO]\n{this.NumerSeryjny}\n" +
                   $"MASA: {this.MasaLadunku}kg\n" +
                   $"CISNIENIE: {this.Cisnienie}bar\n" +
                   $"-----LADUNEK:\nBRAK\n-----------";
        }
        else
        {
            return $"\n[INFO]\n{this.NumerSeryjny}\n" +
                   $"MASA: {this.MasaLadunku}kg\n" +
                   $"CISNIENIE: {this.Cisnienie}bar\n" +
                   $"-----LADUNEK:\n{this.Ladunek.Nazwa}\n-----------";
        }
    }
    
    
    public override string Nazwa()
    {
        return this.NumerSeryjny;;
    }
    
    public void NotifyHazard(string numerKontenera)
    {
        Console.WriteLine($"\n[UWAGA]\nPROBA WYKONANIA NIEBEZPIECZNEJ SYTUACJI NA {numerKontenera}");
    }
}