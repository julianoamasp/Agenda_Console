using Agenda_Console.Context;
using Agenda_Console.Models;
using System.Linq;
using System;

namespace Agenda_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new AgendaContext();
            Program program = new Program();
            
            int opc = 0;

            Console.Title ="Lembrete de Tarefas";

            while (opc >= 0) {

                Console.WriteLine("1 - Todos\n2 - Adicionar\n3 - Atualizar\n4 - Remover\n0 - Sair");

                opc = Convert.ToInt32(Console.ReadLine());

                Console.Clear();

                switch (opc)
                {
                    case 1:
                        program.buscarTodos(db);
                        break;
                    case 2:
                        program.adicionarCategoria(db);
                        break;
                    case 3:
                        program.atualizarCategoria(db);
                        break;
                    case 4:
                        program.removerCategoria(db);
                        break;
                    case 0:
                        opc = -1;
                        break;
                }
            }
        }

        private void adicionarCategoria(AgendaContext db)
        {
            int opc = 0;

            while (opc >= 0)
            {
                Console.WriteLine("1 - Adicionar Categoria\n2 - Adicionar Atividade\n0 - Sair");
                
                opc = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                switch (opc)
                {
                    case 1:
                        Console.WriteLine("Digite o nome da categoria");
                        db.Add(new Categorias { nome = Console.ReadLine() });
                        db.SaveChanges();
                        Console.Clear();
                        opc = - 1;
                        break;
                    case 2:
                        Console.WriteLine("Digite o id da categoria");
                        int idCategoria = Convert.ToInt32(Console.ReadLine());
                        var categoria = (from cct in db.Categorias where cct.CategoriasID == idCategoria select cct).FirstOrDefault();

                        Console.WriteLine("A categoria se chama "+categoria.nome+ " ?\n1 - confirmar\n0 - não, quero tentar novamente");
                        
                        int opcConfirm = Convert.ToInt32(Console.ReadLine());
                        Console.Clear();
                        if (opcConfirm == 1)
                        {
                            Console.WriteLine("Digite o nome da atividade");
                            categoria.Atividades.Add(new Atividades { nome = Console.ReadLine() });
                            db.SaveChanges();
                            Console.Clear();
                            opc = -1;
                        }
            
                        break;
                    case 0:
                        opc = -1;
                        break;
                }
            }
        }
        private void removerCategoria(AgendaContext db)
        {
            int opc = 0;

            while (opc >= 0)
            {
                Console.WriteLine("1 - Remover categoria\n2 - 1 - Remover atividade\n0 - Sair");
                opc = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                switch (opc)
                {
                    case 1:
                        Console.WriteLine("Digite o ID categoria");
                        var cat = (from cct in db.Categorias where cct.CategoriasID == Convert.ToInt32(Console.ReadLine()) select cct).FirstOrDefault();
                        db.Remove(cat);
                        db.SaveChanges();
                        Console.Clear();
                        opc = -1;
                        break;
                    case 2:
                        Console.WriteLine("Digite o ID categoria");
                        var catq = (from cct in db.Categorias where cct.CategoriasID == Convert.ToInt32(Console.ReadLine()) select cct).FirstOrDefault();
                        Console.WriteLine("A categoria se chama \""+ catq.nome+ "\" digite o id da atividade");
                        var atvq = (from aatv in catq.Atividades where aatv.AtividadesID == Convert.ToInt32(Console.ReadLine()) select aatv).FirstOrDefault();
                        Console.WriteLine("A atividade se chama \"" + atvq.nome + "\"\n1 - sim\n2 - não, quero tentar novamente");
                        if (Convert.ToInt32(Console.ReadLine()) == 1)
                        {
                            catq.Atividades.Remove(atvq);
                            db.SaveChanges();
                            Console.Clear();
                            opc = -1;
                        }
                        break;
                    case 0:
                        opc = -1;
                        break;
                }
            }
        }
        private void atualizarCategoria(AgendaContext db)
        {
            int opc = 0;

            while (opc >= 0)
            {
                Console.WriteLine("1 - Categoria\n2 - Atividade\n0 - Sair");
                opc = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                switch (opc)
                {
                    case 1:
                        Console.WriteLine("Digite o ID categoria");
                        var cat = (from cct in db.Categorias where cct.CategoriasID == Convert.ToInt32(Console.ReadLine()) select cct).FirstOrDefault();
                        Console.WriteLine("Digite um novo nome para a categoria \""+ cat.nome+ "\"");
                        cat.nome = Console.ReadLine();
                        db.SaveChanges();
                        Console.Clear();
                        opc = -1;
                        break;
                    case 2:
                        Console.WriteLine("Digite o ID categoria");
                        var catA = (from cct in db.Categorias where cct.CategoriasID == Convert.ToInt32(Console.ReadLine()) select cct).FirstOrDefault();
                        Console.WriteLine("Categoria \"" + catA.nome + "\" selecionada digite o id da atividade");
                        var atv = (from atvq in catA.Atividades where atvq.AtividadesID == Convert.ToInt32(Console.ReadLine()) select atvq).FirstOrDefault();
                        Console.WriteLine("A atividade se chama "+ atv.nome+"? \n1 - sim\n0 - não, quero tentar novamente");
                        
                        if (Convert.ToInt32(Console.ReadLine()) == 1)
                        {
                            Console.Clear();
                            Console.WriteLine("Digite um novo nome para a atividade \""+ atv.nome + "\"");
                            atv.nome = Console.ReadLine();
                            db.SaveChanges();
                            Console.Clear();
                            opc = -1;
                        }
       
                        break;
                    case 0:
                        opc = -1;
                        break;
                }
            }
        }
        public void buscarTodos(AgendaContext db)
        {
            //var todasCategorias = from cats in db.Categorias select cats;
            var arrCats = db.Categorias.ToArray();
            Console.WriteLine("---------------------------------------Todas as categorias---------------------------------------------------");
            if (arrCats.Count() > 0)
            {
                foreach (Categorias cat in arrCats)
                {
                    Console.WriteLine("Categoria ID: " + cat.CategoriasID + " | Categoria Nome: "+cat.nome);
                    if (cat.Atividades.Count() > 0)
                    {
                        foreach (Atividades atv in cat.Atividades)
                        {
                            Console.WriteLine("----------AtividadeId: " + atv.AtividadesID+ " | AtividadeNome: " + atv.nome);
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Sem registros");
            }
            Console.WriteLine("---------------------------------------Todas as categorias---------------------------------------------------\n\n");
        }
    }
}
