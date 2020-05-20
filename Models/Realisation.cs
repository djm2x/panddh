using System.Collections.Generic;

namespace Models
{
    public partial class Realisation
    {
        public Realisation()
        {
            // IndicateurRealisations = new HashSet<IndicateurRealisation>();
        }
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Situation { get; set; }
        public int Annee { get; set; }
        public string Taux { get; set; }
        public string Effet { get; set; }
        public int IdActivite { get; set; }
        public Activite Activite { get; set; }
        // public virtual ICollection<IndicateurRealisation> IndicateurRealisations { get; set; }

    }
}
