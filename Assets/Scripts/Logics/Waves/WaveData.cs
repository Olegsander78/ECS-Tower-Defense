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

        public static WaveData Emty = new();
    }
}