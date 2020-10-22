using System.Collections.Generic;

namespace Models
{
    public partial class Nature
    {
        public Nature()
        {
            Mesures = new HashSet<Mesure>();
        }
        public int Id { get; set; }
        public string Label { get; set; }

        public virtual ICollection<Mesure> Mesures { get; set; }
    }
}
