using System;
using System.Collections.Generic;

namespace Models
{
    public partial class Commission
    {
        public Commission()
        {
            MembreCommissions = new HashSet<MembreCommission>();
        }
        public int Id { get; set; }
        public string Type { get; set; }
        public string Pv { get; set; }
        public DateTime DateEvenement { get; set; }
        public virtual ICollection<MembreCommission> MembreCommissions { get; set; }
    }
}
