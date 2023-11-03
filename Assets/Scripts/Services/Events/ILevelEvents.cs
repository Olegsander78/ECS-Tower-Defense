using System;

namespace Services.Events
{
    public interface ILevelEvents
    {
        event Action LevelStarted;
    }
}