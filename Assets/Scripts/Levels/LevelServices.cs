using Leopotam.Ecs;
using Services.ServiceManager;
using System.Collections;
using UnityEngine;

namespace Levels
{
    public class LevelServices : MonoBehaviour
    {
        private ServiceLocator _serviceLocator;

        public void Init(EcsWorld world)
        {
            _serviceLocator = new ServiceLocator();

            InjectServicesToSceneObjects();
        }
        
        public ServiceLocator GetServiceLocator() => _serviceLocator;

        private void InjectServicesToSceneObjects()
        {
            foreach (var mono in FindObjectsOfType<MonoBehaviour>())
            {
                if (mono is IInjectServices dependency)
                {
                    dependency.Inject(_serviceLocator);
                }
            }
        }
    }
}