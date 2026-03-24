using EsportsArena.Data.Interface;
using EsportsArena.Entities.Models;
using EsportsArena.Logic.Util;

namespace EsportsArena.Logic.Services
{
    public class UsuarioService
    {
        private readonly IGenericDAO<Usuario> _usuarioDAO;

        public UsuarioService(IGenericDAO<Usuario> usuarioDAO)
        {
            _usuarioDAO = usuarioDAO;
        }

        // Método para registrar con SHA256
        public void RegistrarUsuario(Usuario usuario, string passwordPlana)
        {
            usuario.PasswordHash = HashUtil.EncriptarSHA256(passwordPlana);
            _usuarioDAO.Insertar(usuario);
            _usuarioDAO.Guardar();
        }

        // Agrega este método dentro de la clase UsuarioService
        public IEnumerable<Usuario> ObtenerTodosLosUsuarios()
        {
            // Usamos el DAO genérico para traer la lista de la tabla Usuarios
            return _usuarioDAO.ObtenerTodos();
        }

        // Método para el Login funcional
        public Usuario ValidarLogin(string username, string passwordPlana)
        {
            string hashIntento = HashUtil.EncriptarSHA256(passwordPlana);
            return _usuarioDAO.ObtenerTodos()
                .FirstOrDefault(u => u.Username == username && u.PasswordHash == hashIntento);
        }

        public bool Actualizar(Usuario usuario)
        {
            try
            {
                _usuarioDAO.Actualizar(usuario);
                _usuarioDAO.Guardar();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Eliminar(int id)
        {
            try
            {
                // El DAO genérico se encarga de buscar y remover
                _usuarioDAO.Eliminar(id);
                _usuarioDAO.Guardar(); // CRÍTICO: Sin esto, los cambios no se envían a MySQL
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Usuario ObtenerPorId(int id)
        {
            return _usuarioDAO.ObtenerPorId(id);
        }
    }
}
