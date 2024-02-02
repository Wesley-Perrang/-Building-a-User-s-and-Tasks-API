namespace Building_a_Users_and_Tasks_API.Repository
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        T Create(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}
