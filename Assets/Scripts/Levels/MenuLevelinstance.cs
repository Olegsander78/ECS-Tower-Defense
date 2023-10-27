using Game;
using UnityEngine;

namespace Levels
{
    public class MenuLevelinstance : BaseLevelInstance
    {
        [SerializeField] private MenuLevelServices _levelServices;
        public override void Init(GameInstance gameInstance)
        {
            base.Init(gameInstance);

            _levelServices.Init(this);
        }
    }
}