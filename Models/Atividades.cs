using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda_Console.Models
{
    class Atividades
    {
        public int AtividadesID { get; set; }
        public string nome { get; set; }

        public int CatId { get; set; }
        public Categorias Categorias { get; set; }
    }
}
