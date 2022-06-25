using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    Slider slider;
    int MaxValue = 100;
    public int PlayerHealth = 100;
    void Start()
    {
        slider = GetComponent<Slider>();

        slider.maxValue = MaxValue;
        slider.value = MaxValue;
    }


    public void HealthDecrement(int damage)
    {
        PlayerHealth -= damage;
        if(PlayerHealth >= 0)
        {
            slider.value -= damage;
        }
         
    }
}
