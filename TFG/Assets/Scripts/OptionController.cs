using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionController : MonoBehaviour
{
    public Slider slider;
    public float sliderValue;
    public Image imagenMute;
    public Image imagenNoMute;
    // Start is called before the first frame update
    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("volumenAudio", 0.5f);
        AudioListener.volume = slider.value;
        CheckMute();
    }

    public void ChangeSlider(float valor)
    {
        sliderValue = valor;
        PlayerPrefs.SetFloat("volumenAudio", sliderValue);
        AudioListener.volume = slider.value;
        CheckMute();
    }

    private void CheckMute()
    {
        if (sliderValue == 0)
        {
            imagenMute.enabled = true;
            imagenNoMute.enabled = false;
        }
        else
        {
            imagenMute.enabled = false;
            imagenNoMute.enabled = true;
        }
    }
}
