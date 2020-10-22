
namespace Models
{
    public partial class Partenariat
    {
        public Partenariat()
        {
        }

        public int IdMesure { get; set; }
        public int IdOrganisme { get; set; }
        public Mesure Mesure { get; set; }
        public Organisme Organisme { get; set; }
    }
}
