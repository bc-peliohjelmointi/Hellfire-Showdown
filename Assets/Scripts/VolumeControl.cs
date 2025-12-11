using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    public AudioSource music;

    public void ChangeVolume(float value)
    {
        music.volume = value;
    }
}

