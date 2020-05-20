using System;
using System.Collections.Generic;

namespace Models
{
    public partial class MembreCommission
    {
        public MembreCommission()
        {
        }
        public int Id { get; set; }
        public string NomComplete { get; set; }
        public string Email { get; set; }
        public int IdCommission { get; set; }
        public Commission Commission { get; set; }
    }
}
