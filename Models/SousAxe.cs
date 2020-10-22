using System;
using System.Collections.Generic;

namespace Models
{
    public partial class SousAxe
    {
        public SousAxe()
        {
            Mesures = new HashSet<Mesure>();
        }

        public int Id { get; set; }
        public string Label { get; set; }
        public int IdAxe { get; set; }
        public Axe Axe { get; set; }
        public virtual ICollection<Mesure> Mesures { get; set; }
    }
}
