using System;
using System.Collections;
using UnityEngine;

namespace Services.Events
{
    public class LevelEvents : ILevelEvents, ILevelEventsExec
    {
        public event Action LevelStarted;

        public void OnLevelStarted() => LevelStarted?.Invoke();
    }
}