using API_Calculadora_Estudo.Database;
using API_Calculadora_Estudo.Entidades;
using Microsoft.Data.Sqlite;

namespace API_Calculadora_Estudo.Actions
{
    public class UpdateConta
    {
        public Conta Execute(Conta contaInformada)
        {

            var DbLink = new Db_Connection();
            
            var findConta = new GetContaById();
            
            var contaFound = findConta.Execute(contaInformada.Id);

            
            contaInformada.Id = contaFound.Id;
            contaFound.Num1 = contaInformada.Num1;
            contaFound.Num2 = contaInformada.Num2;
            contaFound.Operation = contaInformada.Operation;

            switch (contaFound.Operation) {
                case "sum":
                    contaFound.Result = contaFound.Num1 + contaFound.Num2;
                    break;

                case "sub":
                    contaFound.Result = contaFound.Num1 - contaFound.Num2;
                    break;

                case "mult":
                    contaFound.Result = contaFound.Num1 * contaFound.Num2;
                    break;

                case "div":
                    contaFound.Result = contaFound.Num1 / contaFound.Num2;
                    break;
            }

            string commandToSql = "UPDATE Contas set Num1 = ('" + contaFound.Num1 + "'), num2 = ('" + contaFound.Num2 + "'), " +
                "Operation = ('" + contaFound.Operation + "'), Result = ('" + contaFound.Result + "') " +
                "where id = ('" + contaFound.Id + "') ";

            DbLink.UpdateRange(contaFound);
            DbLink.SaveChanges();
            
            /*


           //-------------------------------------------------------//
           SqliteConnection connection = new SqliteConnection();
           connection.ConnectionString = "Data Source=C:\\Users\\47034764875\\source\\repos\\API_Calculadora_Estudo\\Database\\Database.db";

           SqliteCommand command = new SqliteCommand(commandToSql, connection);
           connection.Open();

           using (SqliteTransaction transaction = connection.BeginTransaction())
           {
               command.Transaction = transaction;
               command.ExecuteNonQuery();
               transaction.Commit();
               connection.Close();
           }

               /*
               SqliteTransaction transaction = connection.BeginTransaction();
               command.ExecuteNonQuery();
               transaction.Commit();
               connection.Close();
               */

            return contaInformada;

        } 
    }
}
