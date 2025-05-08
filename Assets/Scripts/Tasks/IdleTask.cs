using UnityEngine;

namespace TaskTracker.Scripts.Tasks
{
    [CreateAssetMenu(fileName = "IdleTask", menuName = "Tasks/Idle")]
    public class IdleTask : TaskBase
    {
        [field: SerializeField]
        public float IdleDuration { get; private set; }

        private float _currentTime { get; set; } = 0f;

        private bool _timerActive => _currentTime < IdleDuration;

        protected override void Copy(TaskBase reference)
        {
            base.Copy(reference);

            IdleDuration = ((IdleTask)reference).IdleDuration;
        }

        public override void Update()
        {
            if (_timerActive)
            {
                _currentTime += Time.deltaTime;
                SetProgress();

                if (!_timerActive)
                {
                    _progress.Completed();
                }
            }
        }

        protected override string GetTaskTitle()
        {
            return Title.Replace("{0}", IdleDuration.ToString());
        }

        protected override float GetTaskProgress()
        {
            return _currentTime / IdleDuration;
        }
    }
}
