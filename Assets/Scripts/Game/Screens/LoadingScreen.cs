using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Screens
{
    public class LoadingScreen : MonoBehaviour
    {
        [SerializeField] private Canvas _loadingScreenCanvas;
        [SerializeField] private Image _progressImage;
        [SerializeField] private TMP_Text _progressText;

        public void Show()
        {
            _progressText.text = "";
            _progressImage.fillAmount = 0f;
            _loadingScreenCanvas.enabled = true;
        }

        public void UpdateProgressText(float progress)
        {
            _progressText.text = (100f * progress).ToString() + "%";
            _progressImage.fillAmount = progress;
        }

        public void Hide() => _loadingScreenCanvas.enabled = false;
    }
}