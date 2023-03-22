using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestion_materiel.Models
{
    class Combinaison:Materiel
    {
        public int taille { get; set; }

        public string saison { get; set; }

        public int GetId()
        {
            return Id;
        }

        public string GetMarque()
        {
            return Marque;
        }

        public void SetId(int id)
        {
            if (id != 0)
                Id = id;
        }

        public void SetMarque(string marque)
        {
            Marque = marque;
        }
    }
}
