using Microsoft.EntityFrameworkCore;
using SistemaDeTarefas.Data;
using SistemaDeTarefas.Models;
using SistemaDeTarefas.Repositories.Interfaces;

namespace SistemaDeTarefas.Repositories
{
    public class TarefaRepository : ITarefaRepository
    {

        private readonly SistemaTarefasDBContext _sistemaTarefasDBContext;

        public TarefaRepository(SistemaTarefasDBContext sistemaTarefasDBContext)
        {
            this._sistemaTarefasDBContext = sistemaTarefasDBContext;
        }

        public async Task<TarefaModel> BuscarPorId(int id)
        {
            return await _sistemaTarefasDBContext.Tarefas.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<List<TarefaModel>> BuscarTodasTarefas()
        {
            return await _sistemaTarefasDBContext.Tarefas.ToListAsync();
        }
        public async Task<TarefaModel> Adicionar(TarefaModel tarefaModel)
        {
            await _sistemaTarefasDBContext.Tarefas.AddAsync(tarefaModel);
            await _sistemaTarefasDBContext.SaveChangesAsync();
            return tarefaModel;
        }

        public async Task<TarefaModel> Atualizar(TarefaModel tarefaModel, int id)
        {
            TarefaModel tarefaPorid = await BuscarPorId(id);

            if (tarefaPorid == null)
            {
                throw new Exception($"Tarefa com o id : {id}, não foi encontrada.");
            }

            tarefaPorid.Nome = tarefaModel.Nome;
            tarefaPorid.Descricao = tarefaModel.Descricao;
            tarefaPorid.Status = tarefaModel.Status;
            tarefaPorid.UsuarioId = tarefaModel.UsuarioId;

            _sistemaTarefasDBContext.Tarefas.Update(tarefaPorid);
            await _sistemaTarefasDBContext.SaveChangesAsync();
            return tarefaPorid;
        }


        public async Task<bool> Apagar(int id)
        {
            TarefaModel tarefaPorid = await BuscarPorId(id);

            if (tarefaPorid == null)
            {
                throw new Exception($"Tarefa com o id : {id}, não foi encontrada.");
            }

            _sistemaTarefasDBContext.Tarefas.Remove(tarefaPorid);
            await _sistemaTarefasDBContext.SaveChangesAsync();
            return true;

        }

    }
}
