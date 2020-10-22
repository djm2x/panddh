using System;
using System.Collections.Generic;

namespace Models
{
    public partial class Permission
    {
        public Permission()
        {
        }

        public int Id { get; set; }
        public int IdProfil { get; set; }
        public string Action { get; set; }
        public string RouteScreen { get; set; }
        public string RouteScreenAr { get; set; }
        public Profil Profil { get; set; }
        // [System.Text.Json.Serialization.JsonIgnore]


    }
}
