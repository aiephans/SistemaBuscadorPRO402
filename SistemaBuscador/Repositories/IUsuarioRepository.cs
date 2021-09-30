using SistemaBuscador.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaBuscador.Repositories
{
    public interface IUsuarioRepository
    {
        Task ActualizarPassword(UsuarioCambioPasswordModel model);
        Task ActualizarUsuario(UsuarioEdicionModel model);
        Task EliminarUsuario(int id);
        Task InsertatUsuario(UsuarioCreacionModel model);
        Task<UsuarioCreacionModel> NuevoUsuarioCreacion();
        Task<List<UsuarioListaModel>> ObtenerListaUsuarios();
        Task<UsuarioEdicionModel> ObtenerUsuarioPorId(int id);
    }
}
