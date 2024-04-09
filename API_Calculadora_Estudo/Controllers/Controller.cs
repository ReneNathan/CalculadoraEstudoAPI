using API_Calculadora_Estudo.Actions;
using API_Calculadora_Estudo.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API_Calculadora_Estudo.Errors;
using API_Calculadora_Estudo.Filters;

namespace API_Calculadora_Estudo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Controller : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ContaRequest), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(Error_Base), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Error_Base),StatusCodes.Status422UnprocessableEntity)]
        public IActionResult register([FromBody] ContaRequest contaRequest)
        {
            var actions = new RegisterOperation();

            Conta conta_cadastro = new Conta();

            conta_cadastro.Id = new Guid();
            conta_cadastro.Num1 = contaRequest.Num1;
            conta_cadastro.Num2 = contaRequest.Num2;
            conta_cadastro.Operation = contaRequest.Operation;

            try
            {
                if (conta_cadastro.Operation == "sum")
                {
                    conta_cadastro.Result = conta_cadastro.Num1 + conta_cadastro.Num2;
                }
                else if (conta_cadastro.Operation == "sub")
                {
                    conta_cadastro.Result = conta_cadastro.Num1 - conta_cadastro.Num2;
                }
                else if (conta_cadastro.Operation == "mult")
                {
                    conta_cadastro.Result = conta_cadastro.Num1 * conta_cadastro.Num2;
                }
                else if (conta_cadastro.Operation == "div")
                {
                    try
                    {
                        if (conta_cadastro.Num2 != 0)
                        {
                            conta_cadastro.Result = conta_cadastro.Num1 / conta_cadastro.Num2;
                        }
                        else
                        {
                            throw new ZeroDivision("Divisão por zero, impossivel proseguir!!!");
                        }
                    } catch (ZeroDivision ex) {

                        return UnprocessableEntity(ex.Message);
                    
                    }
                }
                else
                {
                    throw new NoOperationError("Operação invalida - Use um operador valido!!! \nUse 'sum' para somar \nuse 'sub' para subtrair \nUse 'mult' para multiplica \nUse 'div' para diviir");
                }
            } catch (NoOperationError ex) {
                return BadRequest(ex.Message);
            }

            var ok = actions.Execute(conta_cadastro);

            return Created(string.Empty, ok);
        }
    }
}
