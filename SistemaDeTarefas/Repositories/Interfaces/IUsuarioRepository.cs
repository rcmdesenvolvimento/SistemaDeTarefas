using SistemaDeTarefas.Models;

namespace SistemaDeTarefas.Repositories.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<List<UsuarioModel>> BuscarTodosUsuarios();
        Task<UsuarioModel> BuscarPorId(int id);
        Task<UsuarioModel> Adicionar(UsuarioModel usuarioModel);
        Task<UsuarioModel> Atualizar(UsuarioModel usuarioModel, int id);
        Task<bool> Apagar(int id);

    }
}
