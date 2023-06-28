using Microsoft.AspNetCore.Mvc;

namespace retornarIdadeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdadeController : ControllerBase
    {
        [HttpGet("{dataNascimento}")]
        public ActionResult<string> GetIdade(string dataNascimento)
        {
            if (DateTime.TryParse(dataNascimento, out DateTime data))
            {
                int idade = CalcularIdade(data);
                string mensagem = $"Sua idade �: {idade} anos.";

                return mensagem;
            }
            else
            {
                return BadRequest("Data de nascimento inv�lida.");
            }
        }

        [HttpPost]
        public ActionResult<string> PostIdade([FromBody] DateTime dataNascimento)
        {
            int idade = CalcularIdade(dataNascimento);
            string mensagem = $"Sua idade �: {idade} anos.";

            return mensagem;
        }

        private int CalcularIdade(DateTime dataNascimento)
        {
            int idade = DateTime.Today.Year - dataNascimento.Year;

            if (dataNascimento > DateTime.Today.AddYears(-idade))
                idade--;

            return idade;
        }
    }
}
