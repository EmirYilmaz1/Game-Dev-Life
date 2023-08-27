using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergySlider : MonoBehaviour
{
    Energy energy;
    Slider slider;
    void Start()
    {
        slider = GetComponent<Slider>();
        energy = FindObjectOfType<Energy>();
        slider.maxValue = 100;
        slider.value = energy.EnergyAmount();
        energy.OnEnergyChange += ChangeBar;
    }

    private void ChangeBar()
    {
         slider.maxValue = 100;
        slider.value = energy.EnergyAmount();
    }
}
