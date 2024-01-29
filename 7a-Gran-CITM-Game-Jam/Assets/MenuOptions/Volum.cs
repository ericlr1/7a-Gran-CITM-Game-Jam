using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volum : MonoBehaviour
{
    public Slider slider;
    public float sliderValue;
    public Image imagenMute;
    // Start is called before the first frame update
    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("volumenAudio", 0.5f);
        AudioListener.volume = sliderValue;
        CheckMute();
    }

    public void ChangeSlider(float value)
    { 
        sliderValue = value;
        PlayerPrefs.SetFloat("volumenAudio", sliderValue);
        AudioListener.volume = slider.value;
        CheckMute();
    }
  
    public void CheckMute()
    {
        if(slider.value == 0) 
        {
            imagenMute.enabled = true;
        }
        else
        {
            imagenMute.enabled = false;
        }
    }
}
