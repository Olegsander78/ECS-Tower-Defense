using ECS.Components;
using Leopotam.Ecs;

namespace Services.Builders.Entities
{
    public class UnitBuilder : EntityBuilder
    {
        private readonly UnitConfig _config;

        public UnitBuilder(UnitConfig config) : base(config)
        {
            _config = config;
        }

        public override void Make()
        {
            base.Make();

            ref var transformComponent = ref Entity.Get<Transform_Component>();
            transformComponent.Transform = EntityView.SelfTransform;

            ref var movementComponent = ref Entity.Get<Movement_Component>();
            movementComponent.Speed = _config.MoveSpeed;
        }
    }
}