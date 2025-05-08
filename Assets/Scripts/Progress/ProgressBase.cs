using UnityEngine;

namespace TaskTracker.Scripts.Progress
{
    public abstract class ProgressBase : MonoBehaviour
    {
        public string Title { get; private set; } = string.Empty;
        public float Progress { get; protected set; } = 0f;

        protected bool _completed { get; set; } = false;

        public virtual void SetProgress(string title, float progress)
        {
            Title = title;
            Progress = progress;
        }

        public virtual void Completed()
        {
            _completed = true;
        }
    }
}
