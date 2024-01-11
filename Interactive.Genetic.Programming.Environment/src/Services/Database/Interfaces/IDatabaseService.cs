namespace Database.Interfaces;

public interface IDatabaseService<T>
{
    void Create(T entity);
    void Delete(T entity);
    public IEnumerable<T> FetchAll();
}