using System.Collections;
using UnityEngine;

namespace Services.Builders
{
    [CreateAssetMenu(menuName = "Game/Actors/Tower", fileName = "Tower")]
    public class TowerConfig : EntityConfig
    {
        public override EntityBuilder GetBuilder()
        {
            return new TowerBuilder(this);
        }

    }
}