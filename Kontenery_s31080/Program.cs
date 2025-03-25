using System.Security.AccessControl;
using Kontenery_s31080;

var kon1 = new KontenerL(5, 100, 10, 1000);
var kon2 = new KontenerG(5, 150, 10, 1500, 1000);
var kon3 = new KontenerC(5, 200, 10, 1000, -20);

var statek1 = new Kontenerowiec(4.5, 4, 5);
var statek2 = new Kontenerowiec(6, 5, 3);

//--------- kon1(L)

kon1.Zaladuj(new LadunekL("mleko", 800, false));
//operacja udana

Console.WriteLine(kon1);

kon1.Oproznij();

Console.WriteLine(kon1);

kon1.Zaladuj(new LadunekL("rtec", 300, true));
//operacja udana

kon1.Zaladuj(new LadunekL("bezyna", 300, true));
//operacja nie udana- za duża masa niebiezpiecznego ładunku

Console.WriteLine(kon1);



//------------ kon2(G)
kon2.Zaladuj(new LadunekG("azot", 300, 200));
//operacja udana

Console.WriteLine(kon2);

kon2.Zaladuj(new LadunekG("tlenekMiedzi", 600, 50));
//operacja nieudana- coś jest w kontenerze

Console.WriteLine(kon2);

kon2.Oproznij();

Console.WriteLine(kon2);

kon2.Zaladuj(new LadunekG("azot", 300, 2000));
//operacja nieudana- za duże ciśnienie

kon2.Zaladuj(new LadunekG("azot", 300, 900));

Console.WriteLine(kon2);


//------------ kon3(C)
kon3.Zaladuj(new LadunekC("Pizza", 300, -30));
//operacja nieudana- za wysoka temperatura w kontenerze

Console.WriteLine(kon3);

kon3.Zaladuj(new LadunekC("Lody", 300, -18));
//operacja udana

Console.WriteLine(kon3);

kon3.Zaladuj(new LadunekC("Lody", 500, -18));
//operacja udana- bo ten sam typ=nazwa

Console.WriteLine(kon3);

kon3.Oproznij();

Console.WriteLine(kon3);

kon3.Zaladuj(new LadunekC("Lody", 300, -18));
//operacja udana

Console.WriteLine(kon3);




//----------- statek
statek1.Zaladuj(kon1);
statek1.Zaladuj(kon2);

Console.WriteLine(statek1);

statek1.PrzeniesKontener(kon1, statek2);
//operacja udana

Console.WriteLine(statek1);
Console.WriteLine(statek2);

statek2.ZastapKontener(kon1,kon3);
//operacja udana

Console.WriteLine(statek1);
Console.WriteLine(statek2);

statek1.UsunKontener(kon2);
//operacja udana

Console.WriteLine(statek1);
Console.WriteLine(statek2);

statek1.UsunKontener(kon3);
//opercaj nieudana- nie ma takiego kontenera na tym statku

Console.WriteLine(statek1);
Console.WriteLine(statek2);





