using API_Calculadora_Estudo.Database;
using API_Calculadora_Estudo.Entidades;
using API_Calculadora_Estudo.Errors;

namespace API_Calculadora_Estudo.Actions
{
    public class GetContaById
    {
        public Conta Execute(Guid id)
        {
            var dbContext = new Db_Connection();

            var entityExists = dbContext.Contas.Find(id);

            if (entityExists == null)
            {
                throw new NotFoundError("Operação não localizada na base de dados!");
            }

            var contaFound = new Conta();

            contaFound.Id = entityExists.Id;
            contaFound.Num1 = entityExists.Num1;
            contaFound.Num2 = entityExists.Num2;
            contaFound.Operation = entityExists.Operation;
            contaFound.Result = entityExists.Result;

            return contaFound;
        }
    }
}
