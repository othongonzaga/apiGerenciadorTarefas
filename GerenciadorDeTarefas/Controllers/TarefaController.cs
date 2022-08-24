﻿using GerenciadorDeTarefas.Dtos;
using GerenciadorDeTarefas.Models;
using GerenciadorDeTarefas.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GerenciadorDeTarefas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TarefaController : BaseController
    {
        private readonly ILogger<TarefaController> _logger;
        private readonly ITarefaRepository _trefaRepository;

        public TarefaController(ILogger<TarefaController> logger, IUsuarioRepository usuarioRepository, ITarefaRepository tarefaRepository) : base(usuarioRepository)
        {
            _logger = logger;
            _trefaRepository = tarefaRepository;
        }

        [HttpPost]
        public IActionResult AdicionarTarefa([FromBody] Tarefa tarefa)
        {
            try
            {
                var usuario = ReadToken();
                var erros = new List<string>();
                if(tarefa == null || usuario == null)
                {
                    erros.Add("Favor informar tarefa ou usuário");
                }
                else
                {
                    if (string.IsNullOrEmpty(tarefa.Nome))
                    {
                        erros.Add("Por favor, informar um nome!");
                    }

                    if(tarefa.DataPrevistaConclusao == DateTime.MinValue || tarefa.DataPrevistaConclusao < DateTime.Now)
                    {
                        erros.Add("Data de previsão não pode ser menor que hoje");
                    }
                }

                if (erros.Count > 0)
                {
                    return BadRequest(new ErroRespostaDto()
                    {
                        Status = StatusCodes.Status400BadRequest,
                        Erros = erros
                    });
                }

                tarefa.IdUsuario = usuario.Id;
                tarefa.DataConclusao = null;
                _trefaRepository.AdicionarTarefa(tarefa);

                return Ok(new { msg = "Tarefa criada com sucesso!" });
            }
            catch(Exception e)
            {
                _logger.LogError("Ocorreu erro ao adicionar tarefa", e);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErroRespostaDto()
                {
                    Status = StatusCodes.Status500InternalServerError,
                    Erro = "Ocorreu erro ao adicionar tarefa, tente novamente!"
                });
            }
        }

        [HttpDelete("{idTarefa}")]
        public IActionResult DeletarTarefa(int idTarefa)
        {
            try
            {
                var usuario = ReadToken();
                if(usuario == null || idTarefa <= 0)
                {
                    return BadRequest(new ErroRespostaDto()
                    {
                        Status = StatusCodes.Status400BadRequest,
                        Erro = "Usuário ou tarefa inválidos"
                    });
                }

                var tarefa = _trefaRepository.GetById(idTarefa);

                if(tarefa == null || tarefa.IdUsuario != usuario.Id)
                {
                    return BadRequest(new ErroRespostaDto()
                    {
                        Status = StatusCodes.Status400BadRequest,
                        Erro = "Tarefa não encontrada"
                    });
                }

                _trefaRepository.RemoverTarefa(tarefa);
                return Ok(new {msg = "Tarefa deletada com sucesso!"});
            }
            catch(Exception e)
            {
                _logger.LogError("Ocorreu erro ao deletar tarefa", e);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErroRespostaDto()
                {
                    Status = StatusCodes.Status500InternalServerError,
                    Erro = "Ocorreu erro ao deletar tarefa, tente novamente!"
                });
            }
        }
    }
}