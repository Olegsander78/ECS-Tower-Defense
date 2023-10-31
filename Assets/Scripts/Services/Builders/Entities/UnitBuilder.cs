using ECS.Components;
using Leopotam.Ecs;

namespace Services.Builders.Entities
{
    public class UnitBuilder : EntityBuilder
    {
        public UnitBuilder(UnitConfig config) : base(config)
        {
        }

        public override void Make()
        {
            base.Make();

            Entity.Get<Movement_Component>();
        }
    }
}