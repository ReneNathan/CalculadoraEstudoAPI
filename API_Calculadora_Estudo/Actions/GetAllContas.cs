using API_Calculadora_Estudo.Database;
using API_Calculadora_Estudo.Entidades;

namespace API_Calculadora_Estudo.Actions
{
    public class GetAllContas
    {
        public List<Conta> Execute()
        {
            var dbContext = new Db_Connection();

            List<Conta> ContasThatExists = dbContext.Contas.ToList();

            return ContasThatExists;
        }
    }
}
