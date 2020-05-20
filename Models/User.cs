using System;
using System.Collections.Generic;

namespace Models
{
    public partial class User
    {
        public User()
        {
            Mesures = new HashSet<Mesure>();
        }

        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        // [System.Text.Json.Serialization.JsonIgnore]
        public string Password { get; set; }
        public string Adresse { get; set; }
        public string Tel { get; set; }
        public string Fix { get; set; }
        // [System.Text.Json.Serialization.JsonIgnore]
        public string Username { get; set; }
        public bool? Actif { get; set; }
        public int IdOrganisme { get; set; }
        public int IdProfil { get; set; }

        public virtual Organisme Organisme { get; set; }
        public virtual Profil Profil { get; set; }
        // [System.Text.Json.Serialization.JsonIgnore]
        public virtual ICollection<Mesure> Mesures { get; set; }
    }
}
