namespace Services.ServiceManager
{
    public interface IServiceLocator
    {
        T GetService<T>();
    }
}