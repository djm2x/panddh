using System;
using System.Collections.Generic;

namespace Models
{
    public partial class IndicateurMesure
    {
        
        public int IdMesure { get; set; }
        public int IdIndicateur { get; set; }
        // public string Value { get; set; }
        // public DateTime Date { get; set; }
        public Mesure Mesure { get; set; }
        public Indicateur Indicateur { get; set; }

    }
}
