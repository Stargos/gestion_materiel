using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestion_materiel.Models
{
    class Pret
    {
        public int Id { get; set; }

        public DateTime date_debut { get; set; }

        public DateTime date_fin { get; set; }
    }
}