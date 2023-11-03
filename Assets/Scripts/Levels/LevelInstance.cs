using ECS.Marks;
using ECS.Systems;
using ECS.Systems.Init;
using Game;
using Leopotam.Ecs;
using Services.Events;
using UnityEngine;

namespace Levels
{
    public class LevelInstance : BaseLevelInstance
    {
        [SerializeField] private LevelServices _levelServices;

        //public UnitConfig UnitConfig;

        private EcsWorld _world;

        private EcsSystems _initSystems;
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

            _initSystems
                .Add(new WaveInit_System(_levelServices.GetServiceLocator()));

            _updateSystems
                .Add(new Wave_System(_levelServices.GetServiceLocator()))
                .Add(new Movement_System(_levelServices.GetServiceLocator()))
                .Add(new EntityDestroy_System());

            _updateSystems
                .OneFrame<EntityDestroy_Mark>();

            _initSystems.Init();
            _updateSystems.Init();
            _fixedUpdateSystems.Init();
            _lateUpdateSystems.Init();
            
        }

        private void CreatingSystems()
        {
            _initSystems = new EcsSystems(_world);
            _updateSystems = new EcsSystems(_world);
            _lateUpdateSystems = new EcsSystems(_world);
            _fixedUpdateSystems = new EcsSystems(_world);
        }
    }
}