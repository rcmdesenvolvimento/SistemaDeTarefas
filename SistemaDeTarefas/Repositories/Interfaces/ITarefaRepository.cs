using SistemaDeTarefas.Models;

namespace SistemaDeTarefas.Repositories.Interfaces
{
    public interface ITarefaRepository
    {
        Task<List<TarefaModel>> BuscarTodasTarefas();
        Task<TarefaModel> BuscarPorId(int id);
        Task<TarefaModel> Adicionar(TarefaModel usuarioModel);
        Task<TarefaModel> Atualizar(TarefaModel usuarioModel, int id);
        Task<bool> Apagar(int id);

    }
}
