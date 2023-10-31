using Leopotam.Ecs;
using Logics.Waves;
using Services.Factory;
using Services.ServiceManager;
using UnityEngine;

namespace Levels
{
    public class LevelServices : MonoBehaviour
    {
        [SerializeField] private WaveStorage _waveStorage;

        private ServiceLocator _serviceLocator;
        private EntityFactory _entityFactory;

        public void Init(EcsWorld world)
        {
            _serviceLocator = new ServiceLocator();

            _entityFactory = new EntityFactory(world, _serviceLocator);

            _serviceLocator
                .RegisterService<IEntityFactory>(_entityFactory)
                .RegisterService<WaveStorage>(_waveStorage);

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