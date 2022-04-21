namespace Quiz.App.Infrastructure.Repositories
{
    public interface ICacheRepository<T>
    {
        void Set(string key, T entry);
        T Get(string key);
    }
}