namespace Kontenery_s31080;

public class LadunekC(string nazwa, double masa, double temperatura) : Ladunek(nazwa, masa)
{
    public double WymaganaTemperatura { get; set; } = temperatura;
    
    
    public override string ToString()
    {
        return $"{this.Nazwa}, {this.Masa}, {this.WymaganaTemperatura}[C]";
    }
    
}