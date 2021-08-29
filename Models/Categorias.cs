using System.Collections.Generic;

namespace Agenda_Console.Models
{
    class Categorias
    {
        public int CategoriasID { get; set; }
        public string nome { get; set; }
        public List<Atividades> Atividades = new List<Atividades>();
    }
}
