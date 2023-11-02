using Leopotam.Ecs;
using Services.Factory;
using Services.PlayerInput;
using Services.ServiceManager;
using Services.Storages;
using UnityEngine;

namespace Levels
{
    public class LevelServices : MonoBehaviour
    {
        [SerializeField] private WavesStorage _waveStorage;
        [SerializeField] private PathStorage _pathStorage;

        private ServiceLocator _serviceLocator;
        private EntityFactory _entityFactory;
        private IInputHandler _inputHandler;

        public void Init(EcsWorld world)
        {
            _serviceLocator = new ServiceLocator();

            _entityFactory = new EntityFactory(world, _serviceLocator);
            _inputHandler = new InputHandler();

            _serviceLocator
                .RegisterService<IEntityFactory>(_entityFactory)
                .RegisterService<IInputHandler>(_inputHandler)
                .RegisterService<WavesStorage>(_waveStorage)
                .RegisterService<PathStorage>(_pathStorage);

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