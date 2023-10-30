﻿using Leopotam.Ecs;
using Services.Factory;
using Services.ServiceManager;
using UnityEngine;

namespace Levels
{
    public class LevelServices : MonoBehaviour
    {
        private ServiceLocator _serviceLocator;
        private EntityFactory _entityFactory;

        public void Init(EcsWorld world)
        {
            _serviceLocator = new ServiceLocator();

            _entityFactory = new EntityFactory(world, _serviceLocator);

            _serviceLocator.RegisterService<IEntityFactory>(_entityFactory);

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