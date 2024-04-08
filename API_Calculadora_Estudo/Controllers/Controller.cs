using API_Calculadora_Estudo.Actions;
using API_Calculadora_Estudo.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Calculadora_Estudo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Controller : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(200)]
        public IActionResult register([FromBody] Conta conta)
        {
            var actions = new RegisterOperation();

            Conta conta_cadastro = new Conta();

            conta_cadastro.Id = new Guid();
            conta_cadastro.Num1 = conta.Num1;
            conta_cadastro.Num2 = conta.Num2;
            conta_cadastro.Operation = conta.Operation;
            conta_cadastro.Result = conta.Result;

            var ok = actions.Execute(conta_cadastro);

            return Created(string.Empty, ok);
        }
    }
}
