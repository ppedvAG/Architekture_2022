// See https://aka.ms/new-console-template for more information
using HalloCompositePattern;


Console.WriteLine("Hello, World!");

var sys1 = new List<Lautsprecher>();
sys1.Add(new Tweeter() { Typ = "T1" });
sys1.Add(new Tweeter() { Typ = "T2" });

var s1 = new Subwoofer() { Typ = "S1" };
s1.Lautsprecher.Add(new Tweeter() { Typ = "S1T1" });
s1.Lautsprecher.Add(new Tweeter() { Typ = "S1T2" });
sys1.Add(s1);

var s2 = new Subwoofer() { Typ = "S2" };
s2.Lautsprecher.Add(new Tweeter() { Typ = "S2T1" });
var s2s2 = new Subwoofer() { Typ = "S2S2" };
s2s2.Lautsprecher.Add(new Tweeter() { Typ = "S2S2T1" });
s2.Lautsprecher.Add(s2s2);
sys1.Add(s2);


sys1.ForEach(x => ShowLautsprecher(x, 0));


void ShowLautsprecher(Lautsprecher ls, int depth)
{
    for (int i = 0; i < depth; i++)
        Console.Write("-");

    //Console.WriteLine($"Typ: {ls.Typ}");
    ls.Mute();
    if (ls is Subwoofer sub)
    {
        sub.Lautsprecher.ForEach(x => ShowLautsprecher(x, depth + 1));
    }
}

