using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TaskTracker.Scripts.Progress
{
    public class CommonProgress : ProgressBase
    {
        [SerializeField] private TextMeshProUGUI _titleText = default!;
        [SerializeField] private Image _progressImage = default!;

        public override void SetProgress(string title, float progress)
        {
            base.SetProgress(title, progress);

            _titleText.text = title;
            _progressImage.fillAmount = progress;
        }

        public override void Completed()
        {
            base.Completed();

            _titleText.color = Color.green;
        }
    }
}
