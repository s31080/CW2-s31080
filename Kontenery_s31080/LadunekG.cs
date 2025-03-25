namespace Kontenery_s31080;

public class LadunekG(string nazwa, double masa, double cisnienie) : Ladunek(nazwa, masa)
{
    public double Cisnienie { get; set; }= cisnienie;
    
    
    
    public override string ToString()
    {
        return $"{this.Nazwa}, {this.Masa}, {this.Cisnienie}[bar]";
    }
}