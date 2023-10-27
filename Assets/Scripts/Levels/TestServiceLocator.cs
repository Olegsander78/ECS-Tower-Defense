using Services.ServiceManager;
using UnityEngine;

public class TestServiceLocator : MonoBehaviour, IInjectServices
{
    public void Inject(IServiceLocator locator)
    {
        Debug.Log("Inject test service: " + name);
    }
}
