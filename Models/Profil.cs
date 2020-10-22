using System;
using System.Collections.Generic;

namespace Models
{
    public partial class Profil
    {
        public Profil()
        {
            Users = new HashSet<User>();
            Permissions = new HashSet<Permission>();
        }

        public int Id { get; set; }
        public string Label { get; set; }
        // [System.Text.Json.Serialization.JsonIgnore]
        public virtual ICollection<Permission> Permissions { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
