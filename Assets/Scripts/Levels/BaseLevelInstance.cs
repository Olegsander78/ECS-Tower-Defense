using Game;
using UnityEngine;

namespace Levels
{
    public class BaseLevelInstance : MonoBehaviour
    {
        public GameInstance GameInstance { get; private set; }

        public virtual void Init(GameInstance gameInstance)
        {
            GameInstance = gameInstance;
        }
    }
}