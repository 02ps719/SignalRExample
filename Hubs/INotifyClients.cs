namespace Core
{
    public interface INotifyClients<T>
    {
        void Notify(T entity);
    }
}