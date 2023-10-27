using UnityEngine;

namespace Game
{
    [CreateAssetMenu(menuName = "Game/Constants/GameConstants", fileName = "GameConstants")]
    public class GameConstants : ScriptableObject
    {
        [field: SerializeField] public int GameFrameRate { get; private set; }
        [field: SerializeField] public int FirstSceneIndex { get; private set; }

    }
}