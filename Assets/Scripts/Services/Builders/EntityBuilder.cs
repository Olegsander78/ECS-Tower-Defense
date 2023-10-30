using ECS.Components;
using Leopotam.Ecs;
using Logics.Views;
using UnityEngine;

namespace Services.Builders
{
    public class EntityBuilder
    {
        private readonly EntityConfig _config;

        protected EcsWorld World;
        protected EcsEntity Entity;

        private Vector3 _spawnPosition;
        private Quaternion _spawnRotation;

        public EntityBuilder(EntityConfig config)
        {
            _config = config;
        }

        public void SetWorld(EcsWorld world) => World = world;

        public void SetSpawnPosition(Vector3 spawnPosition) => _spawnPosition = spawnPosition;
        public void SetSpawnRotation(Quaternion spawnRotation) => _spawnRotation = spawnRotation;

        public virtual void Make()
        {
            Entity = World.NewEntity();
            EntityView entityView = Object.Instantiate(_config.EntityPrefab, _spawnPosition, _spawnRotation);

            entityView.Init(World, in Entity);

            ref var Description = ref Entity.Get<EntityDescription_Component>();
            Description.Name = _config.Name;
            Description.Description = _config.Description;
            Description.Avatar = _config.Avatar;
        }

        public EcsEntity GetResult()
        {
            return Entity;
        }
    }
}