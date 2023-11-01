using UnityEngine;

namespace Services.Builders.Entities
{
    [CreateAssetMenu(menuName = "Game/Actors/BaseUnits", fileName = "Base Unit")]
    public class UnitConfig : EntityConfig
    {
        [field: Header("Movement")]
        [field: SerializeField] public float MoveSpeed { get; private set; }
        public override EntityBuilder GetBuilder()
        {
            return new UnitBuilder(this);
        }
    }
}