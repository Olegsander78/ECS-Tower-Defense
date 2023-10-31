using ECS.Systems;
using ECS.Systems.Init;
using Game;
using Leopotam.Ecs;
using UnityEngine;

namespace Levels
{
    public class LevelInstance : BaseLevelInstance
    {
        [SerializeField] private LevelServices _levelServices;

        //public UnitConfig UnitConfig;

        private EcsWorld _world;
        private EcsSystems _updateSystems;
        private EcsSystems _lateUpdateSystems;
        private EcsSystems _fixedUpdateSystems;

        private void Update()
        {
            _updateSystems?.Run();

            //if (Input.GetKeyDown(KeyCode.W))
            //{
            //    var builder = UnitConfig.GetBuilder();

            //    builder.SetWorld(_world);
            //    builder.SetSpawnPosition(Vector3.zero);
            //    builder.SetSpawnRotation(Quaternion.identity);
            //    builder.Make();
            //}
        }

        private void FixedUpdate()
        {
            _fixedUpdateSystems?.Run();
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

            _updateSystems
                .Add(new WaveInit_System(_levelServices.GetServiceLocator()))
                .Add(new WaveSystem(_levelServices.GetServiceLocator()));
            //_fixedUpdateSystems.Add(new ShowDescription_System());

            _updateSystems.Init();
            _fixedUpdateSystems.Init();
            _lateUpdateSystems.Init();
        }

        private void CreatingSystems()
        {
            _updateSystems = new EcsSystems(_world);
            _lateUpdateSystems = new EcsSystems(_world);
            _fixedUpdateSystems = new EcsSystems(_world);
        }
    }
}