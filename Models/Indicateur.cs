using System.Collections.Generic;

namespace Models
{
    public partial class Indicateur
    {
        public Indicateur()
        {
            IndicateurMesureValues = new HashSet<IndicateurMesureValue>();
            IndicateurMesures = new HashSet<IndicateurMesure>();
            // IndicateurRealisations = new HashSet<IndicateurRealisation>();
        }
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Source { get; set; }
       public virtual ICollection<IndicateurMesure> IndicateurMesures { get; set; }
       public virtual ICollection<IndicateurMesureValue> IndicateurMesureValues { get; set; }
    //    public virtual ICollection<IndicateurRealisation> IndicateurRealisations { get; set; }

    }
}
