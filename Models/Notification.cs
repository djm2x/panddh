using System;
using System.Collections.Generic;

namespace Models
{
    public partial class Notification
    {
        public int Id { get; set; }
        public int IdConcerner { get; set; }
        public int IdOrganisme { get; set; }
        public string TableConcerner { get; set; }
        public string Message { get; set; }
        public string Destinataire { get; set; }
        public DateTime Date { get; set; }
        public bool Vu { get; set; }
        public int Priorite { get; set; }
    }
}
