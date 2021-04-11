using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Win32.SafeHandles;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private static int hunger = 50;
    public static int Hunger
    {
        get => hunger;
        set
        {
            hunger = Mathf.Clamp(value, 0, 100);
        }
    }

    [SerializeField] private Slider sliderHunger;

    private static int energy = 50;
    public static int Energy
    {
        get => energy;
        set
        {
            energy = Mathf.Clamp(value, 0, 100);
        }
    }

    [SerializeField] private Slider sliderEnergy;

    private static int health = 50;
    public static int Health
    {
        get => health;
        set
        {
            health = Mathf.Clamp(value, 0, 100);
        }
    }

    [SerializeField] private Slider sliderHealth;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        sliderHunger.value = hunger;
        sliderEnergy.value = energy;
        sliderHealth.value = health;
    }
}
