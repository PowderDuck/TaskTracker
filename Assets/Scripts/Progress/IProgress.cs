namespace TaskTracker.Scripts.Progress
{
    public interface IProgress
    {
        float Progress { get; }
        void SetProgress(float progress);
    }
}
