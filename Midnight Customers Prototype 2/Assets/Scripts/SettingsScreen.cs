using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsScreen : MonoBehaviour
{
    // Fields
    
    // References
    //Sloppy implementation, nested GetComponent might work better or Find
    [Header("References")]
    [Tooltip("Reference to a TMP Dropdown for the resolution options.")]
    [SerializeField] TMPro.TMP_Dropdown resolutionDropdown;
    [Tooltip("Reference to the TMP font for the anti-dyslexia font.")]
    public TMPro.TMP_FontAsset anti_dyslexia_font;
    [Tooltip("Reference to the default TMP font.")]
    public TMPro.TMP_FontAsset default_font;
    [Tooltip("Reference to a TMP text object.")]
    public TMPro.TMP_Text text;
    [Tooltip("Reference to an AudioMixer.")]
    [SerializeField] AudioMixer audioMixer;
    Resolution[] resolutions;

    void Start(){
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        //Could be written better
        List<string> options = new List<string>();

        int currentresolutionindex = 0;

        for(int i =0; i <resolutions.Length; i++){
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            bool width_match = resolutions[i].width == Screen.currentResolution.width;
            bool height_match = resolutions[i].height == Screen.currentResolution.height;
            if (width_match && height_match) currentresolutionindex = i;
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentresolutionindex;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetResolution (int resolution_index){
        Resolution resolution = resolutions[resolution_index];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetVolume (float volume){
        audioMixer.SetFloat("volume", volume);
    }

    public void SetQuality (int quality){
        QualitySettings.SetQualityLevel(quality);
    }

    public void SetFullscreen (bool isfullscreen){
        Screen.fullScreen = isfullscreen;
    }

    public void SetFont(bool is_on){
        //Will add toggle for all text present (harder to change fonts back though)
        if (is_on) text.font = anti_dyslexia_font;
        else text.font = default_font;
    }
}