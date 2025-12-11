using UnityEngine;
using UnityEngine.UI;

public class UIHealthBar : MonoBehaviour
{
    public static UIHealthBar instance;

    public Image fillImage;

    void Awake()
    {
        instance = this;
    }

    public void UpdateHealthBar(float current, float max)
    {
        fillImage.fillAmount = current / max;
    }
}
