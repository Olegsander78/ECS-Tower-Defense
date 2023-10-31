using Logics.Waves;

namespace ECS.Components
{
    public struct Wave_Component
    {
        public int IndexWave;
        public int IndexUnit;
        public float IntervalWaveTimer;
        public float IntervalUnitTimer;
        public WaveData WaveData;

        public bool IsCompleted;
    }
}