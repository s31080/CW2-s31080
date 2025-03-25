namespace Kontenery_s31080;

public abstract class Ladunek(string nazwa, double masa)
{
    public string Nazwa { get; set; } = nazwa;
    public double Masa { get; set; } = masa;
    


    public override string ToString()
    {
        return $"{this.Nazwa}, {this.Masa}";
    }
}
