using UnityEngine;

namespace Services.Builders.Entities
{
    [CreateAssetMenu(menuName = "Game/Actors/BaseUnits", fileName = "Base Unit")]
    public class UnitConfig : EntityConfig
    {
        public override EntityBuilder GetBuilder()
        {
            return new UnitBuilder(this);
        }
    }
}