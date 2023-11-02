using ECS.Components;
using ECS.Marks;
using Leopotam.Ecs;
using Services.ServiceManager;
using Services.Storages;
using UnityEngine;

namespace ECS.Systems
{
    public class Movement_System : IEcsRunSystem
    {
        private EcsFilter<Movement_Component, Transform_Component> _movementFilter;

        private readonly PathStorage _pathStorage;

        public Movement_System(IServiceLocator serviceLocator)
        {
            _pathStorage = serviceLocator.GetService<PathStorage>();
        }

        public void Run()
        {
            foreach (var item in _movementFilter)
            {
                ref var entity = ref _movementFilter.GetEntity(item);
                ref var movementComponent = ref _movementFilter.Get1(item);
                ref var transformComponent = ref _movementFilter.Get2(item);

                var travaledTimer = movementComponent.TraveledTimer;

                var travaledPosition = _pathStorage.GetTravaledDistance(travaledTimer);
                var travaledRotation = _pathStorage.GetTravaledRotation(travaledTimer);

                movementComponent.TraveledTimer += movementComponent.Speed * Time.deltaTime;

                if (_pathStorage.IsEndTravaledDistance(movementComponent.TraveledTimer))
                {
                    float pathLenth = _pathStorage.GetPathLength();
                    travaledPosition = _pathStorage.GetTravaledDistance(pathLenth);
                    travaledRotation = _pathStorage.GetTravaledRotation(pathLenth);

                    entity.Get<EntityDestroy_Mark>();
                }

                transformComponent.Transform.SetPositionAndRotation(travaledPosition, travaledRotation);
            }
        }
    }
}