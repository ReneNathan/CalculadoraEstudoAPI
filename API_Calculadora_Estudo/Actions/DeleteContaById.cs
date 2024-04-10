using API_Calculadora_Estudo.Database;
using API_Calculadora_Estudo.Entidades;
using API_Calculadora_Estudo.Errors;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace API_Calculadora_Estudo.Actions
{
    public class DeleteContaById
    {
        public string Execute(Guid id)
        {
            var dbContext = new Db_Connection();
            
            //primeiro já uso o método existe de "pegar" uma conta do id para localizar a conta a ser excluida e depois realizo a exclusão
            var GetConta = new GetContaById();
            var contaToDelete = GetConta.Execute(id);

            dbContext.Contas.Remove(contaToDelete);
            dbContext.SaveChanges();

            return "Exclusão realizada com sucesso!!!";

        }
    }
}
