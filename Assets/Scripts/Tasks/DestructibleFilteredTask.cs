using TaskTracker.Scripts.Args;
using TaskTracker.Scripts.Enums;
using UnityEngine;

namespace TaskTracker.Scripts.Tasks
{
    [CreateAssetMenu(fileName = "DestructibleFilteredTask",
        menuName = "Tasks/DestructibleFiltered")]
    public class DestructibleFilteredTask : DestructibleTask
    {
        [field: SerializeField]
        public DestructibleType TargetType { get; private set; }

        protected override void Copy(TaskBase reference)
        {
            base.Copy(reference);

            TargetType = ((DestructibleFilteredTask)reference).TargetType;
        }

        protected override void OnDestructibleDestroyed(
            object sender, DestructibleDestroyedEventArgs eventArgs)
        {
            if (eventArgs.Destructible.Type == TargetType)
            {
                base.OnDestructibleDestroyed(sender, eventArgs);
            }
        }
    }
}
