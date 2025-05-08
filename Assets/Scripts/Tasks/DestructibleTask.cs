using TaskTracker.Scripts.Args;
using TaskTracker.Scripts.Managers;
using TaskTracker.Scripts.Progress;
using UnityEngine;

namespace TaskTracker.Scripts.Tasks
{
    [CreateAssetMenu(fileName = "DestructibleTask", menuName = "Tasks/Destructible")]
    public class DestructibleTask : TaskBase
    {
        [field: SerializeField]
        public int RequiredQuantity { get; private set; }

        protected float _currentlyDestroyed { get; set; } = 0;

        public override void Initialize(
            ProgressBase progress, TaskBase reference)
        {
            base.Initialize(progress, reference);

            EventManager.DestructibleDestroyed += OnDestructibleDestroyed;
        }

        protected override void Copy(TaskBase reference)
        {
            base.Copy(reference);

            RequiredQuantity = ((DestructibleTask)reference).RequiredQuantity;
        }

        public override void Disable()
        {
            EventManager.DestructibleDestroyed -= OnDestructibleDestroyed;
        }

        protected virtual void OnDestructibleDestroyed(
            object sender, DestructibleDestroyedEventArgs eventArgs)
        {
            _currentlyDestroyed++;
            SetProgress();
            if (_currentlyDestroyed >= RequiredQuantity)
            {
                _progress.Completed();
                Disable();
            }
        }

        protected override string GetTaskTitle()
        {
            return Title
                .Replace("{0}", _currentlyDestroyed.ToString())
                .Replace("{1}", RequiredQuantity.ToString());
        }

        protected override float GetTaskProgress()
        {
            return _currentlyDestroyed / RequiredQuantity;
        }
    }
}
