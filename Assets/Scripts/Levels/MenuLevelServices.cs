using Services.ServiceManager;
using UnityEngine;

namespace Levels
{
    public class MenuLevelServices : MonoBehaviour
    {
        private ServiceLocator _serviceLocator;

        public void Init(MenuLevelinstance levelInstance)
        {
            _serviceLocator = new ServiceLocator();

            _serviceLocator.RegisterService<MenuLevelinstance>(levelInstance);

            RegistrationServices();
            InjectToSceneObjects();
        }

        public IServiceLocator GetServiceLocator() => _serviceLocator;

        private void RegistrationServices()
        {

        }

        private void InjectToSceneObjects()
        {
            foreach (var item in FindObjectsOfType<MonoBehaviour>())
            {
                if (item is IInjectServices dependency)
                {
                    dependency.Inject(_serviceLocator);
                }
            }
        }
    }
}