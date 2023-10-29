using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Services.Builders
{
    public class EntityBuilder
    {
        private readonly EntityConfig _config;

        public EntityBuilder(EntityConfig config)
        {
            _config = config;
        }
    }
}