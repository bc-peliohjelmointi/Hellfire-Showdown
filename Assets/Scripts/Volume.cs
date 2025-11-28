using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    public AudioSource audioSource;
    public Slider slider;

    void Start()
    {
        slider.onValueChanged.AddListener(v => audioSource.volume = v);
    }
}
