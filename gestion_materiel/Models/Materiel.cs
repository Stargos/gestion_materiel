using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestion_materiel.Models
{
    public abstract class Materiel
    {
        private int id;
        private string marque;

        protected int Id { get => id; set => id = value; }
        protected string Marque { get => marque; set => marque = value; }
    }
}