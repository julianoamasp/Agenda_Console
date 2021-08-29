using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda_Console.Models
{
    class Categorias
    {
        public int CategoriasID { get; set; }
        public string nome { get; set; }
        public List<Atividades> Atividades = new List<Atividades>();
    }
}
