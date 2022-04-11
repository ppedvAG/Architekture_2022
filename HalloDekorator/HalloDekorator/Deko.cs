namespace HalloDekorator
{
    internal interface IComponent
    {
        public string Beschreibung { get; }
        public decimal Preis { get; }
    }

    abstract class Deko : IComponent
    {
        protected readonly IComponent parent;

        public Deko(IComponent parent)
        {
            this.parent = parent;
        }

        public abstract string Beschreibung { get; }
        public abstract decimal Preis { get; }
    }

    class Ei : Deko
    {
        public Ei(IComponent parent) : base(parent)
        { }

        public override string Beschreibung => parent.Beschreibung + " Ei";

        public override decimal Preis => parent.Preis + 0.27m;
    }

    class Käse : Deko
    {
        public Käse(IComponent parent) : base(parent)
        { }

        public override string Beschreibung => parent.Beschreibung + " Käse";

        public override decimal Preis => parent.Preis + 2.30m;
    }

    class Salami : Deko
    {
        public Salami(IComponent parent) : base(parent)
        { }

        public override string Beschreibung => parent.Beschreibung + " Salami";

        public override decimal Preis => parent.Preis + 2m;
    }

    class Pizza : IComponent
    {
        public string Beschreibung => "Pizza";

        public decimal Preis => 6m;
    }

    class Brot : IComponent
    {
        public string Beschreibung => "Brot";

        public decimal Preis => 2m;
    }
}
