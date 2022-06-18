using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Slider healthbar;

    public void HealthMax(int health)
    {
        healthbar.maxValue = health;
        healthbar.value = health;
    }


    public void HealthSet(int health)
    {
        healthbar.value = health;
    }
}
