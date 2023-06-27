using Microsoft.AspNetCore.Mvc;

namespace retornarIdadeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdadeController : ControllerBase
    {
        [HttpGet("dataNascimento")]
        public ActionResult<string> GetIdade(string dataNascimento)
        {
            if (DateTime.TryParse(dataNascimento, out DateTime data))
            {
                int idade = DateTime.Today.Year - data.Year;

                if (data > DateTime.Today.AddYears(-idade))
                    idade--;

                string mensagem = $"Sua idade é: {idade} anos.";

                return mensagem;
            }
            else
            {
                return BadRequest("Data de nascimento inválida.");
            }
        }
    }
}
