
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DefenseHealthUpdater : MonoBehaviour
{
    public TMP_Text nameText;
    public Slider healthSlider;

    public void UpdateHealth(string name, float percent)
    {
        if (nameText != null)
            nameText.text = name;

        if (healthSlider != null)
            healthSlider.value = percent;
    }
}


