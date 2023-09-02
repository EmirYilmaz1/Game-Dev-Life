using UnityEngine;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour 
{
    Slider slider;
    Energy energy;
    float sliderMax = 100; 
    private void Awake() 
    {
        slider = GetComponent<Slider>();
        slider.maxValue = sliderMax;
        energy = FindObjectOfType<Energy>();
        ChangeBar();
        energy.OnEnergyChange += ChangeBar;
    }

    private void ChangeBar()
    {
        slider.value = energy.GetEnergyAmount();
    }

}