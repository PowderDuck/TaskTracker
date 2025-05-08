using System;
using TaskTracker.Scripts.Destructibles;

namespace TaskTracker.Scripts.Args
{
    public class DestructibleDestroyedEventArgs : EventArgs
    {
        public Destructible Destructible { get; }

        public DestructibleDestroyedEventArgs(Destructible destructible)
        {
            Destructible = destructible;
        }
    }
}
