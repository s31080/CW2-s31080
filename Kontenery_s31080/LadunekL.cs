namespace Kontenery_s31080;

public class LadunekL(string nazwa, double masa, bool czyNiebezpieczny) : Ladunek(nazwa, masa)
{
    public bool CzyNiebezpieczny { get; set; } = czyNiebezpieczny;
    
    
    
    public override string ToString()
    {
        return $"{this.Nazwa}, {this.Masa}, Czy niebezpieczny: {this.CzyNiebezpieczny}";
    }
}