using Services.Builders.Entities;
using System;

namespace Logics.Waves
{
    [Serializable]
    public struct WaveData
    {
        public string Title;
        public float IntervalSpawn;
        public UnitConfig[] UnitConfigs;

        public static WaveData Empty = new();

        public static bool operator ==(in WaveData lhs, in WaveData rhs)
        {
            return lhs.Title == rhs.Title;
        }

        public static bool operator !=(in WaveData lhs, in WaveData rhs)
        {
            return lhs.Title != rhs.Title;
        }
    }
}