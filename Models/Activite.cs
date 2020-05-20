using System.Collections.Generic;

namespace Models
{
    public partial class Activite
    {
        public Activite()
        {
            Realisations = new HashSet<Realisation>();
        }
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Duree { get; set; }
        public int IdMesure { get; set; }
        public Mesure Mesure { get; set; }
        public virtual ICollection<Realisation> Realisations { get; set; }
    }
}
