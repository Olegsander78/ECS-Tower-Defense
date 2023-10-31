using ECS.Components;
using Leopotam.Ecs;

namespace ECS.Systems
{
    public class ShowDescription_System : IEcsRunSystem
    {
        private EcsFilter<EntityDescription_Component> _filter;

        public void Run()
        {
            //Debug.Log(_filter.GetEntitiesCount());

            foreach (var component in _filter)
            {
                ref var description = ref _filter.Get1(component);

                //Debug.Log(description.Name);
            }
        }
    }
}