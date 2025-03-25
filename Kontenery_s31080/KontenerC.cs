namespace Kontenery_s31080;

public class KontenerC(double wysokosc, double masaWlasna, double glebokosc, double ladownosc, double temperatura) : 
        Kontener(wysokosc, masaWlasna, glebokosc, ladownosc), IHazardNotifier
{
    private static int Licznik = 1;
    public string NumerSeryjny { get; set; } = $"KON-C-{Licznik++}";
    public LadunekC Ladunek { get; set; }
    public double Temperatura { get; set; } = temperatura;
    
    
    public void Zaladuj(LadunekC ladunek)
    {
        try
        {
            if (this.MasaLadunku + ladunek.Masa <= this.Ladownosc &&
                this.Temperatura <= ladunek.WymaganaTemperatura && 
                (Ladunek == null || this.Ladunek.Nazwa == ladunek.Nazwa))
            {
                this.MasaLadunku += ladunek.Masa;
                Ladunek = ladunek;
                
                Console.WriteLine($"\n[INFO]\nZALADOWANO {ladunek.Nazwa} na " +
                                  $"{this.NumerSeryjny}");
            }
            else
            {
                if (this.Temperatura > ladunek.WymaganaTemperatura)
                {
                    NotifyHazard(this.NumerSeryjny);
                }

                if (this.MasaLadunku + ladunek.Masa > this.Ladownosc)
                {
                    throw new OverfillException();
                }
                
                if (this.Ladunek != null && this.Ladunek.Nazwa != ladunek.Nazwa)
                {
                    throw new OverfillException();
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
        this.MasaLadunku = 0;
        this.Ladunek = null;
        
        Console.WriteLine($"\n[INFO]\nOPROZNIONO {this.NumerSeryjny}");
    }

    public void NotifyHazard(string numerKontenera)
    {
        Console.WriteLine($"\n[UWAGA]\nPROBA WYKONANIA NIEBEZPIECZNEJ SYTUACJI NA {numerKontenera}");
    }
    
    public override string ToString()
    {
        if (this.Ladunek == null)
        {
            return $"\n[INFO]\n{this.NumerSeryjny}\n" +
                   $"MASA: {this.MasaLadunku}kg\n" +
                   $"TEMPERATURA: {this.Temperatura}C\n" +
                   $"-----LADUNEK:\nBRAK\n-----------";
        }
        else
        {
            return $"\n[INFO]\n{this.NumerSeryjny}\n" +
                   $"MASA: {this.MasaLadunku}kg\n" +
                   $"TEMPERATURA: {this.Temperatura}C\n" +
                   $"-----LADUNEK:\n{this.Ladunek.Nazwa}\n-----------";
        }
    }
    
    
    public override string Nazwa()
    {
        return this.NumerSeryjny;;
    }
}