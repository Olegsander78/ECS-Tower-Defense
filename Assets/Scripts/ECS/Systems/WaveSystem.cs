using ECS.Components;
using Leopotam.Ecs;
using Logics.Waves;
using Services.Factory;
using Services.ServiceManager;
using Services.Storages;
using UnityEngine;

namespace ECS.Systems
{
    public class WaveSystem : IEcsRunSystem
    {
        private EcsFilter<Wave_Component> _wavesFilter;
        private EcsFilter<Movement_Component> _movementFilter;

        private readonly WavesStorage _waveStorage;
        private readonly EntityFactory _entityFactory;

        public WaveSystem(IServiceLocator serviceLocator)
        {
            _waveStorage = serviceLocator.GetService<WavesStorage>();
            _entityFactory = serviceLocator.GetService<EntityFactory>();
        }

        public void Run()
        {
            foreach (var item in _wavesFilter)
            {
                ref var waveComponent = ref _wavesFilter.Get1(item);

                if (waveComponent.IsCompleted == false)
                {
                    if (waveComponent.WaveData == WaveData.Empty)
                    {
                        ref var waveData = ref _waveStorage.GetWaveDataAt(waveComponent.IndexWave);

                        if (waveData != WaveData.Empty)
                        {
                            waveComponent.WaveData = waveData;
                        }
                        else
                        {
                            waveComponent.IsCompleted = true;
                            continue;
                        }
                    }

                    if (waveComponent.IntervalWaveTimer <= 0f)
                    {
                        if (waveComponent.IntervalUnitTimer <= 0f)
                        {
                            int unitIndex = waveComponent.IndexUnit;

                            if (unitIndex < waveComponent.WaveData.UnitConfigs.Length)
                            {
                                var builder = waveComponent.WaveData.UnitConfigs[unitIndex].GetBuilder();
                                var spawnPosition = _waveStorage.UnitSpawnPoint.position;

                                _entityFactory.CreateEntity(builder, spawnPosition);

                                waveComponent.IntervalUnitTimer = waveComponent.WaveData.IntervalSpawn;
                                waveComponent.IndexUnit++;
                            }
                            else
                            {
                                if(_movementFilter.GetEntitiesCount() == 0)
                                {
                                    waveComponent.IndexWave++;
                                    waveComponent.IntervalWaveTimer = _waveStorage.IntervalWaveTimer;
                                    waveComponent.IntervalUnitTimer = 0f;
                                    waveComponent.WaveData = WaveData.Empty;
                                }                                
                            }
                        }
                        else
                        {
                            waveComponent.IntervalUnitTimer -= Time.deltaTime;
                        }
                    }
                    else
                    {
                        waveComponent.IntervalWaveTimer -= Time.deltaTime;
                    }
                }
            }
        }
    }
}