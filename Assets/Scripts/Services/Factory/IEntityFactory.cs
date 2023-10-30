using Leopotam.Ecs;
using Services.Builders;
using UnityEngine;

namespace Services.Factory
{
    public interface IEntityFactory
    {
        ref EcsEntity CreateEntity(EntityBuilder builder, Vector3 position, Quaternion rotation = default);
    }
}