using Logics.Views;
using System.Collections;
using UnityEngine;

namespace Services.Builders
{
    public class EntityConfig : ScriptableObject
    {
        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField] public string Description { get; private set; }
        [field: SerializeField] public Sprite Avatar { get; private set; }

        [field: SerializeField] public EntityView EntityPrefab { get; private set; } 
        
        public virtual EntityBuilder GetBuilder()
        {
            return new EntityBuilder(this);
        }        
    }
}