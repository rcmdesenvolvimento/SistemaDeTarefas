using Microsoft.EntityFrameworkCore;
using SistemaDeTarefas.Data;
using SistemaDeTarefas.Models;
using SistemaDeTarefas.Repositories.Interfaces;

namespace SistemaDeTarefas.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {

        private readonly SistemaTarefasDBContext _sistemaTarefasDBContext;

        public UsuarioRepository(SistemaTarefasDBContext sistemaTarefasDBContext)
        {
            this._sistemaTarefasDBContext = sistemaTarefasDBContext;
        }

        public async Task<UsuarioModel> BuscarPorId(int id)
        {
            return await _sistemaTarefasDBContext.Usuarios.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<List<UsuarioModel>> BuscarTodosUsuarios()
        {
            return await _sistemaTarefasDBContext.Usuarios.ToListAsync();
        }
        public async Task<UsuarioModel> Adicionar(UsuarioModel usuarioModel)
        {
            await _sistemaTarefasDBContext.Usuarios.AddAsync(usuarioModel);
            await _sistemaTarefasDBContext.SaveChangesAsync();
            return usuarioModel;
        }

        public async Task<UsuarioModel> Atualizar(UsuarioModel usuarioModel, int id)
        {
            UsuarioModel usuarioPorid = await BuscarPorId(id);

            if (usuarioPorid == null)
            {
                throw new Exception($"Usuário com o id : {id}, não foi encontrado.");
            }

            usuarioPorid.Nome = usuarioModel.Nome;   
            usuarioPorid.Email = usuarioModel.Email;

            _sistemaTarefasDBContext.Usuarios.Update(usuarioPorid);
            await _sistemaTarefasDBContext.SaveChangesAsync();
            return usuarioPorid;
        }


        public async Task<bool> Apagar(int id)
        {
            UsuarioModel usuarioPorid = await BuscarPorId(id);

            if (usuarioPorid == null)
            {
                throw new Exception($"Usuário com o id : {id}, não foi encontrado.");
            }

            _sistemaTarefasDBContext.Usuarios.Remove(usuarioPorid);
            await _sistemaTarefasDBContext.SaveChangesAsync();
            return true;

        }

    }
}
