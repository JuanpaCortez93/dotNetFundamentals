namespace _004_Example5_Complete.Repositories
{
    public interface IRepository <TEntity>
    {

        Task<IEnumerable<TEntity>> GetValues();
        Task<TEntity> GetValue (Guid id);
        Task AddValue (TEntity t);
        void Update(TEntity t);
        void Delete(TEntity t);
        Task Save();
        

    }
}
