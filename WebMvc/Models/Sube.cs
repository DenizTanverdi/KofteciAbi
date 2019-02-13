using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMvc.Models
{
    public class Sube:BaseEntity
    {
        public string SubeAdi { get; set; }
        public string Telefon { get; set; }
        public string Telefon2 { get; set; }
        public string Adres { get; set; }
    }
}