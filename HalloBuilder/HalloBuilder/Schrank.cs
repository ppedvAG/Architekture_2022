using Microsoft.Toolkit.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalloBuilder
{
    internal class Schrank
    {
        private Schrank()
        {
        }

        public int AnzTüren { get; private set; }
        public int AnzBöden { get; private set; }
        public string Farbe { get; private set; }
        public Oberfläche Oberfläche { get; private set; }


        public class Builder
        {
            private Schrank _newSchrank = new();

            public Builder Türen(int anzTüren)
            {
                if (anzTüren <= 0)
                    //throw new ArgumentException("Mehr Türen!!!!");
                    Guard.IsLessThanOrEqualTo(anzTüren, 2, nameof(anzTüren));

                _newSchrank.AnzTüren = anzTüren;
                return this;
            }

            public Builder Oberfläche(Oberfläche oberfläche)
            {
                _newSchrank.Oberfläche = oberfläche;
                return this;
            }

            public Builder Farbe(string farbe)
            {
                Guard.IsNullOrWhiteSpace(farbe, nameof(farbe));
                if (_newSchrank.Oberfläche != HalloBuilder.Oberfläche.Lackiert)
                    ThrowHelper.ThrowArgumentException(nameof(farbe), "Farbe nur bei Lackierung");

                _newSchrank.Farbe = farbe;
                return this;
            }

            public Schrank Build()
            {
                return _newSchrank;
            }

        }


    }

    enum Oberfläche
    {
        Unbehandelt,
        Gewachst,
        Lackiert
    }
}
