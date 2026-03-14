namespace EsportsArena.Data.Interface
{
    public interface IGenericDAO<T> where T : class
    {
        IEnumerable<T> ObtenerTodos();
        T ObtenerPorId(int id);
        void Insertar(T entidad);
        void Actualizar(T entidad);
        void Eliminar(int id);
        void Guardar();
    }
}
