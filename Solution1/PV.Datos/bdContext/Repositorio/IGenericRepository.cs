namespace Datos.bdContext.Repositorio
{
    public interface IGenericRepository<TEntityBD> where TEntityBD : class
    {
        Task<bool> Insert(TEntityBD modelo);
        Task<bool> Update(TEntityBD modelo);
        Task<bool> Delete(int id);
        Task<TEntityBD> Select(int id);
        Task<IQueryable<TEntityBD>> ObtenerDatos();
    }
}
