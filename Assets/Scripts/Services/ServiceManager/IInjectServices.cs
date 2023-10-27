namespace Services.ServiceManager
{
    public interface IInjectServices
    {
        void Inject(IServiceLocator locator);
    }
}