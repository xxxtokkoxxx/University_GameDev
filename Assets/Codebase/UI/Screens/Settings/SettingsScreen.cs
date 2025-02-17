using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using VContainer;

namespace Codebase.UI.Screens.Settings
{
    public class SettingsScreen : BaseViw
    {
        [SerializeField] private Slider _audioVolumeSlider;
        [SerializeField] private TMP_Dropdown _resolutionDropdown;
        [SerializeField] private TMP_Dropdown _qualityDropdown;
        [SerializeField] private AudioMixer _mixer;

        private IUiService _uiService;
        private const string Master = "Master";

        public override ViewType ViewType => ViewType.Settings;

        [Inject]
        public SettingsScreen(IUiService uiService)
        {
            _uiService = uiService;
        }

        private void Start()
        {
            _resolutionDropdown.ClearOptions();
            _qualityDropdown.ClearOptions();

            foreach (Resolution res in Screen.resolutions)
            {
                _resolutionDropdown.options.Add(new TMP_Dropdown.OptionData(res.width + "x" + res.height));
            }
        }

        public void OnBackButtonClicked()
        {
            _uiService.HideScreen(ViewType);
            _uiService.ShowScreen(ViewType.MainMenu);
        }

        public void OnChangeVolume(float value)
        {
            _mixer.SetFloat(Master, value);
        }

        public void OnSetFullScreen(bool value)
        {
            Screen.fullScreen = value;
        }

        public void OnSetScreenResolution(int index)
        {
            Resolution resolution = Screen.resolutions[index];
            Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        }

        public void OnSetQuality(int index)
        {
            QualitySettings.SetQualityLevel(index);
        }
    }
}