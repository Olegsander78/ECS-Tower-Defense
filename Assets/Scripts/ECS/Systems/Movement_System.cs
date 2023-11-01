using ECS.Components;
using Leopotam.Ecs;
using Services.ServiceManager;
using Services.Storages;
using System.Collections;
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
                ref var movementComponent = ref _movementFilter.Get1(item);
                ref var transformComponent = ref _movementFilter.Get2(item);

                var travaledTimer = movementComponent.TraveledTimer;

                var travaledPosition = _pathStorage.GetTravaledDistance(travaledTimer);
                var travaledRotation = _pathStorage.GetTravaledRotation(travaledTimer);

                transformComponent.Transform.SetPositionAndRotation(travaledPosition, travaledRotation);

                movementComponent.TraveledTimer += movementComponent.Speed * Time.deltaTime;
            }
        }
    }
}