using Game;
using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Levels
{
    public class LevelInstance : BaseLevelInstance
    {
        [SerializeField] private LevelServices _levelServices;

        private EcsWorld _world;
        private EcsSystems _updateSystems;
        private EcsSystems _lateUpdateSystems;
        private EcsSystems _fixedUpdateSystems;

        private void Update()
        {
            _updateSystems?.Run();
        }

        private void FixedUpdate()
        {
            _fixedUpdateSystems?.Init();            
        }

        private void LateUpdate()
        {
            _lateUpdateSystems?.Run();
        }

        public override void Init(GameInstance gameInstance)
        {
            base.Init(gameInstance);

            _world = new EcsWorld();

            _levelServices.Init(_world);

            CreatingSystems();

            _updateSystems.Init();
            //_fixedUpdateSystems.Init();
            //_lateUpdateSystems.Init();
        }

        private void CreatingSystems()
        {
            _updateSystems = new EcsSystems(_world);
            _lateUpdateSystems = new EcsSystems(_world);
            _fixedUpdateSystems = new EcsSystems(_world);
        }
    }
}