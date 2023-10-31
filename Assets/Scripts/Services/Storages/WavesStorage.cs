using Logics.Waves;
using UnityEngine;

namespace Services.Storages
{
    public class WavesStorage : MonoBehaviour
    {
        [field: SerializeField] public float IntervalWaveTimer { get; private set; }
        [field: SerializeField] public Transform UnitSpawnPoint { get; private set; }

        [SerializeField] private WaveData[] _waveDatas;

        public ref WaveData GetWaveDataAt(int index)
        {
            if (_waveDatas.Length < index)
            {
                return ref _waveDatas[index];
            }

            return ref WaveData.Empty;
        }
    }
}