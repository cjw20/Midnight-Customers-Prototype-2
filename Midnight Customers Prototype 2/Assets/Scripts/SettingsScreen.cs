using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


public class SettingsScreen : MonoBehaviour
{
    [SerializeField]
    AudioMixer audioMixer;
    Resolution[] resolutions;
    
    //Sloppy implementation, nested GetComponent might work better or Find
    [SerializeField] 
    TMPro.TMP_Dropdown resolutionDropdown;

    public Font anti_dyslexia_font;
    public Font default_font;

    public Text text;

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
