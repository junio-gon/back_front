using System;
using System.Collections.Generic;
using System.Text.Json;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestDDD.API.Constants;
using RestDDD.Application.DTOS;
using RestDDD.Application.Interfaces;

namespace RestDDD.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ContatosController : ControllerBase
    {
        private readonly IApplicationServiceContato _applicationServiceContato;

        public ContatosController(IApplicationServiceContato applicationServiceContato)
        {
            _applicationServiceContato = applicationServiceContato;
        }

        /// <summary>
        /// Retorna uma lista de contatos
        /// </summary>
        /// <returns>ListContatos</returns>
        /// <response code="200">Resultados Encontrados</response>
        /// <response code="400">Erro ao obter os resultados</response>
        [HttpGet]
        [ProducesResponseType(typeof(List<Page>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public ActionResult<IEnumerable<string>> GetContatosListAll()
        {
            List<Page> page = new List<Page>();
            int count = 0; 
            int pagenumber = 1;
            try
            {
                foreach (var item in _applicationServiceContato.GetAll())
                {
                    if (count == 3)
                    {
                        pagenumber += 1;
                        count = 0;
                    }
                    page.Add(new Page { pagina = pagenumber, contato = item });
                    count += 1;
                }
            }
            catch (Exception e)
            {
                return BadRequest($"Erro ao obter os registros: {e.Message}");
            }
            return Ok(page);
        }

        /// <summary>
        /// Retorna um contato de acordo com o Id
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Resultado encontrado</response>
        /// <response code="400">Erro ao obter dados do contato</response>
        /// <response code="404">Contato não encontrado</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ContatoDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public ActionResult<string> GetContatoById(int id)
        {
            try
            {
                var result = _applicationServiceContato.GetById(id);

                if (result is null)
                {
                    return NotFound($"Contato {id} não foi encontrado");
                }

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest($"Erro ao obter os dados: {e.Message}");
            }
            
        }

        /// <summary>
        /// Cadastra um contato
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Cadatrado com sucesso</response>
        /// <response code="400">Erro ao obter</response>
        [HttpPost]
        [ProducesResponseType(typeof(ContatoDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public ActionResult CreateContato([FromBody] ContatoDTO contatoDTO)
        {
            try
            {
                if (contatoDTO is null)
                    return BadRequest("Contato não pode ser nulo!");

                _applicationServiceContato.Add(contatoDTO);
                return Ok("Contato cadastrado com sucesso!");
            }
            catch (Exception e)
            {
                return BadRequest($"Erro ao salvar os dados: {e.Message}");
            }
        }

        /// <summary>
        /// Atualiza um contato existente de acordo com o Id
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Atualizado com Sucesso</response>
        /// <response code="400">Erro ao Atualizar o contato</response>
        /// <response code="404">Contato não encontrado</response>
        [HttpPut]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public ActionResult UpdateContato([FromBody] ContatoDTO contatoDTO)
        {
            try
            {
                if (contatoDTO is null)
                    return NotFound();

                _applicationServiceContato.Update(contatoDTO);
                return Ok("Contato atualizado com sucesso!");
            }
            catch (Exception e)
            {
                return BadRequest($"Erro ao atualizar os dados: {e.Message}");
            }
        }

        /// <summary>
        /// Remove um contato existente
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Excluído com sucesso</response>
        /// <response code="400">Erro ao excluir</response>
        /// <response code="404">Contato não encontrado</response>
        [HttpDelete("{id}")]
        //adaptação para o Entity receber corretamente a requisição do Axios
        //public ActionResult Delete([FromBody] ContatoDTO contatoDTO)
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public ActionResult DeleteContatoById(string id)
        {
            try
            {
                /*if (contatoDTO == null)
                    return NotFound();

                _applicationServiceContato.Remove(contatoDTO);*/

                _applicationServiceContato.Remove(Convert.ToInt32(id));
                return Ok("Contato removido com sucesso");
            }
            catch (Exception e)
            {
                return BadRequest($"Erro ao excluir os dados: {e.Message}");
            }

        }
    }
}
