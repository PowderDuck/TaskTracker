using System.Collections.Generic;
using TaskTracker.Scripts.Tasks;
using UnityEngine;

namespace TaskTracker.Scripts
{
    public class TaskManager : MonoBehaviour
    {
        [SerializeField] private List<TaskBase> _tasks = new();
        [SerializeField] private GameObject _taskHolder = default!;

        private List<TaskBase> _taskInstances { get; } = new();

        private void Start()
        {
            foreach (var task in _tasks)
            {
                var taskInstance = (TaskBase)ScriptableObject.CreateInstance(task.GetType());
                var progressObject = Instantiate(
                    task.ProgressPrefab, _taskHolder.transform);
                taskInstance.Initialize(progressObject, task);

                _taskInstances.Add(taskInstance);
            }
        }

        private void Update()
        {
            _taskInstances
                .ForEach(instance => instance.Update());
        }

        private void OnDisable()
        {
            _taskInstances
                .ForEach(instance => instance.Disable());
        }
    }
}
