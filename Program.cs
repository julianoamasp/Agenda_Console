using Agenda_Console.Context;
using Agenda_Console.Models;
using System.Linq;
using System;
using System.Collections.Generic;


namespace Agenda_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new AgendaContext();
            
            //var todasCategorias = from cats in db.Categorias select cats;
            var arrCats = db.Categorias.ToArray();
            if (arrCats.Count() > 0) {
                foreach (Categorias cat in arrCats)
                {
                    Console.WriteLine("Categoria: " + cat.nome);
                    if (cat.Atividades.Count() > 0)
                    {
                        foreach (Atividades atv in cat.Atividades)
                        {
                            Console.WriteLine("--Atividade: " + atv.nome);
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Sem registros");
            }

            db.Add(new Categorias { nome = "Estudar" });
            db.SaveChanges();
                
            
        }
    }
}
