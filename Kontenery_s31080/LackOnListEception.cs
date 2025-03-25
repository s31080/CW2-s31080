namespace Kontenery_s31080;

public class LackOnListEception : Exception
{
    public LackOnListEception() : base("\n[BLAD]\nNIE MOZNA USUNAC, NIE MA DANEGO KONTENERA"){}
}