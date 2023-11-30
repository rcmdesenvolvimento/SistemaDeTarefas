using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaDeTarefas.Models;
using SistemaDeTarefas.Repositories.Interfaces;

namespace SistemaDeTarefas.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioRepository _usuarioRepository;

    public UsuarioController(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    [HttpGet]
    public async Task<ActionResult<List<UsuarioModel>>> BuscarTodosUsuarios()
    {
        List<UsuarioModel> lstUsuarios = await _usuarioRepository.BuscarTodosUsuarios();
        return Ok(lstUsuarios);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UsuarioModel>> BuscarPorId(int id)
    {
        UsuarioModel Usuario = await _usuarioRepository.BuscarPorId(id);
        return Ok(Usuario);
    }

    [HttpPost]
    public async Task<ActionResult<UsuarioModel>> CadastrarUsuario([FromBody] UsuarioModel usuarioModel)
    {
        UsuarioModel usuario = await _usuarioRepository.Adicionar(usuarioModel);
        return Ok(usuario);
    }

    [HttpPut]
    public async Task<ActionResult<UsuarioModel>> AtualizarUsuario([FromBody] UsuarioModel usuarioModel, int id)
    {
        usuarioModel.Id = id;
        UsuarioModel usuario = await _usuarioRepository.Atualizar(usuarioModel, id);
        return Ok(usuario);
    }

    [HttpDelete]
    public async Task<ActionResult<UsuarioModel>> ApagarUsuario(int id)
    {
        bool usuario = await _usuarioRepository.Apagar(id);
        return Ok(usuario);
    }
}


// https://www.youtube.com/watch?v=2TxePNK0kc8&t=114s - aula 44:52
