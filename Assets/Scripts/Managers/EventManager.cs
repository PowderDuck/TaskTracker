using System;
using TaskTracker.Scripts.Args;

namespace TaskTracker.Scripts.Managers
{
    public static class EventManager
    {
        public static event Action<object, DestructibleDestroyedEventArgs>? DestructibleDestroyed;

        public static void OnDestructibleDestroyed(
            object sender, DestructibleDestroyedEventArgs eventArgs)
        {
            DestructibleDestroyed?.Invoke(sender, eventArgs);
        }
    }
}
