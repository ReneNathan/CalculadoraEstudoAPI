using API_Calculadora_Estudo.Entidades;
using API_Calculadora_Estudo.Database;

namespace API_Calculadora_Estudo.Actions
{
    public class RegisterOperation
    {
        public string Execute(Conta conta)
        {
            //validate

            var dbContext = new Db_Connection();

            dbContext.Contas.Add(conta);
            dbContext.SaveChanges();

            return "Cadastrado com Sucesso";
        }
    }
}
