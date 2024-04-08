using Microsoft.EntityFrameworkCore;
using API_Calculadora_Estudo.Entidades;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API_Calculadora_Estudo.Database
{
    public class Db_Connection : DbContext
    {
        
        public DbSet<Conta> Contas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=C:\\Users\\47034764875\\source\\repos\\API_Calculadora_Estudo\\Database\\Database.db");
            //UseSqlite($"Data Source={_appEnv.ApplicationBasePath}/data.db"); });
        }
    }
}
