using System;
using System.Collections.Generic;

namespace Models
{
    public partial class Axe
    {
        public Axe()
        {
            Mesures = new HashSet<Mesure>();
            SousAxes = new HashSet<SousAxe>();
        }

        public int Id { get; set; }
        public string Label { get; set; }
        
        // [JsonIgnore]
        public virtual ICollection<Mesure> Mesures { get; set; }
        public virtual ICollection<SousAxe> SousAxes { get; set; }
    }
}
