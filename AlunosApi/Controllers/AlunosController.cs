using AlunosApi.Models;
using AlunosApi.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlunosApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes =JwtBearerDefaults.AuthenticationScheme)]
    //[Produces("application/json")]
    public class AlunosController : ControllerBase
    {
        private IAlunoService _service;
        public AlunosController( IAlunoService service)
        {
            _service = service;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IAsyncEnumerable<Aluno>>> GetAlunos()
        {
            try
            {
                var alunos = await _service.GetAlunos();
                return Ok(alunos);
            }
            catch
            {
                //return BadRequest("Request Inválido");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao obter alunos.");
            }
        }

        [HttpGet("AlunoPorNome")]
        public async Task<ActionResult<IAsyncEnumerable<Aluno>>> 
            GetAlunosByName([FromQuery] string nome)
        {
            try
            {
                var alunos = await _service.GetAlunosByNome(nome);
                if (alunos == null)
                {
                    return NotFound($"Não existem alunos com o critério {nome}.");
                }
                return Ok(alunos);
            }
            catch
            {
                //return BadRequest("Request Inválido");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao obter alunos com nome {nome}.");
            }
        }


        [HttpGet("{id:int}", Name="GetAluno")]
        public async Task<ActionResult<Aluno>> GetAluno(int id)
        {
            try
            {
                var aluno = await _service.GetAluno(id);
                if (aluno == null)
                {
                    return NotFound($"Não existe aluno com o id: {id}.");
                }
                return Ok(aluno);
            }
            catch
            {
                //return BadRequest("Request Inválido");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao obter aluno com id: {id}.");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Create(Aluno aluno)
        {
            try
            {
                if (aluno == null)
                {
                    return BadRequest("Request Inválido");
                }
                await _service.CreateAluno(aluno);
                return CreatedAtRoute(nameof(GetAluno), new { id = aluno.Id }, aluno);
            }
            catch
            {
                return BadRequest("Request Inválido");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Edit(int id, [FromBody] Aluno aluno)
        {
            try
            {
                if (aluno.Id == id)
                {
                    await _service.UpdateAluno(aluno);
                    //return NoContent();
                    return Ok($"Aluno com id {id} foi atualizado.");
                }
                return BadRequest("Dados inconsistentes.");
            }
            catch
            {
                return BadRequest("Request Inválido");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Remove(int id)
        {
            try
            {
                var aluno = await _service.GetAluno(id);
                if (aluno == null)
                {
                    return NotFound($"Id {id} não encontrado.");
                }
                await _service.DeleteAluno(aluno);
                return Ok($"Aluno com id {id} foi excluído.");
            }
            catch
            {
                return BadRequest("Request Inválido");
            }
        }


    }
}
