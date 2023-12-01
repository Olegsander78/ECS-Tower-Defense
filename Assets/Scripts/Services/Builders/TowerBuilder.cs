using ECS.Components.Entities.Towers;
using Leopotam.Ecs;
using System.Collections;
using UnityEngine;

namespace Services.Builders
{
    public class TowerBuilder : EntityBuilder
    {
        private readonly TowerConfig _config;

        public TowerBuilder(TowerConfig config) : base(config)
        {
            _config = config;
        }

        public override void Make()
        {
            base.Make();

            ref var towerComponent = ref Entity.Get<Tower_Component>();
        }
    }
}