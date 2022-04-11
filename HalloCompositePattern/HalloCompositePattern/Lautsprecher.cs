namespace HalloCompositePattern
{
    public interface Lautsprecher
    {
        string Typ { get; set; }

        void Mute();
    }

    public class Subwoofer : Lautsprecher
    {
        public List<Lautsprecher> Lautsprecher { get; } = new List<Lautsprecher>();
        public string Typ { get; set; }


        public void Mute()
        {
            Console.WriteLine($"Subwoofer {Typ} wurde gemutet");
        }
    }

    public class Tweeter : Lautsprecher
    {
        public string Typ { get; set; }

        public void Mute()
        {
            Console.WriteLine($"Tweeter {Typ} wurde gemutet");
        }
    }

}
