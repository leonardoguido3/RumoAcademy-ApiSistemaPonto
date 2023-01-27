using ApiSistemaPonto.Domain.Models;
using ApiSistemaPonto.Filtro.Utilitario;
using ApiSistemaPonto.Servico;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiSistemaPonto.Controllers
{
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        // criando uma variavel readonly interna injetando Funcionario Servico
        private readonly FuncionarioServico _servico;

        // criando construtor que vai receber a injecao de dependencia
        public FuncionarioController(FuncionarioServico servico)
        {
            _servico = servico;
        }

        // metodo POST para inserir dados no banco de dados
        [HttpPost("Funcionario")]
        public IActionResult Inserir([FromBody] FuncionarioModel model)
        {
            // faço uma tratativa, se minha model está validada, após entro no TRY que irá enviar para o servico de inserção, passando a model
            // retornando valor 201 caso sucesso, caso tenha alguma falha será tratada no catch exibindo os erros específicos
            if(ModelState.IsValid)
            {
                try
                {
                    _servico.Inserir(model);
                    return StatusCode(201);
                }
                catch (ValidacaoException erro)
                {
                    return StatusCode(400, erro.Message);
                }
                catch(Exception erro)
                {
                    return StatusCode(500, erro.ToString());
                }      
            }
            return StatusCode(415);
        }

        // meotodo GET para buscar todos os funcionarios ou buscar por identificador
        [HttpGet("Funcionario")]
        public IActionResult ListarTodos([FromQuery] string? nome)
        {
            return StatusCode(200, _servico.ListarTodos(nome));
        }

        // metodo PUT para atualizar um dado do funcionario
        [HttpPut("Funcionario/{Identificador}")]
        public IActionResult Atualizar()
        {
            return StatusCode(200);
        }

        // metodo DELETE para deletar um funcionario passando seu identificador
        [HttpDelete("Funcionario/{Identificador}")]
        public IActionResult Deletar()
        {
            return StatusCode(200);
        }
    }
}
