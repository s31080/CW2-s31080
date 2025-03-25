namespace Kontenery_s31080;

public class OverfillException : Exception
{
    public OverfillException() : base("\n[BLAD]\nNIE MOZNA ZALADOWAC\n"){}
}