using Agenda_Console.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Agenda_Console.Context
{
    class AgendaContext : DbContext
    {
        public DbSet<Atividades> Atividades { get; set; }
        public DbSet<Categorias> Categorias { get; set; }

        public string DbPath { get; private set; }

        public AgendaContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = $"{path}{System.IO.Path.DirectorySeparatorChar}Agenda.db";
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }
}
