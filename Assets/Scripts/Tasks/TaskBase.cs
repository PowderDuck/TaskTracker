using TaskTracker.Scripts.Progress;
using UnityEngine;

namespace TaskTracker.Scripts.Tasks
{
    public abstract class TaskBase : ScriptableObject
    {
        [field: SerializeField]
        public string Title { get; private set; }

        [field: SerializeField]
        public ProgressBase ProgressPrefab { get; private set; }

        protected ProgressBase _progress { get; set; } = default!;

        // Potentially add the Completed event for the TaskManager to subscribe to

        public virtual void Initialize(
            ProgressBase progress, TaskBase reference)
        {
            _progress = progress;
            Copy(reference);
            SetProgress();
        }

        protected virtual void Copy(TaskBase reference)
        {
            Title = reference.Title;
        }

        public virtual void Update() { }

        public virtual void Disable() { }

        public virtual void SetProgress()
        {
            _progress.SetProgress(
                GetTaskTitle(), GetTaskProgress());
        }

        protected virtual string GetTaskTitle()
        {
            return Title;
        }

        protected abstract float GetTaskProgress();
    }
}
