using ECS.Components;
using Leopotam.Ecs;
using Services.ServiceManager;
using Services.Storages;

namespace ECS.Systems.Init
{
    public class WaveInit_System : IEcsInitSystem
    {
        private EcsWorld _world;

        private WavesStorage _waveStorage;

        public WaveInit_System(IServiceLocator serviceLocator)
        {
            _waveStorage = serviceLocator.GetService<WavesStorage>();
        }

        public void Init()
        {
            EcsEntity waveEntity = _world.NewEntity();

            ref var waveComponent = ref waveEntity.Get<Wave_Component>();

            int firstWaveIndex = 0;

            waveComponent.IndexWave = firstWaveIndex;
            waveComponent.IntervalWaveTimer = _waveStorage.IntervalWaveTimer;
        }
    }
}