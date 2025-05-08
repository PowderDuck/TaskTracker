using System;
using TaskTracker.Scripts.Args;
using TaskTracker.Scripts.Enums;
using TaskTracker.Scripts.Managers;
using UnityEngine;

namespace TaskTracker.Scripts.Destructibles
{
    public abstract class Destructible : MonoBehaviour
    {
        [field: SerializeField]
        public DestructibleType Type { get; private set; }

        public event Action<object, DestructibleDestroyedEventArgs>? Destroyed;

        protected virtual void OnEnable()
        {
            Destroyed += EventManager.OnDestructibleDestroyed;
        }

        protected virtual void OnDisable()
        {
            Destroyed -= EventManager.OnDestructibleDestroyed;
        }

        public virtual void Destroy()
        {
            Destroyed?.Invoke(this, new(this));
        }
    }
}
