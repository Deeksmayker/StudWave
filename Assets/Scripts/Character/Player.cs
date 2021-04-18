using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Win32.SafeHandles;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    #region perks

    private int knowlendge;

    public int Knowledge
    {
        get => knowlendge;
        set => knowlendge = value >= 0 ? value : 0;
    }

    private int physical;

    public int Physical
    {
        get => physical;
        set => physical = value >= 0 ? value : 0;
    }

    private int charisma;

    public int Charisma
    {
        get => charisma;
        set => charisma = value >= 0 ? value : 0;
    }

    private int studWave;

    public int StudWave
    {
        get => studWave;
        set => studWave = value >= 0 ? value : 0;
    }

    private int tech;

    public int Techíàïñàë 
    {
        get => tech;
        set => tech = value >= 0 ? value : 0;
    }

    #endregion

    #region stats
    private static int hunger = 50;
    public static int Hunger
    {
        get => hunger;
        set
        {
            hunger = Mathf.Clamp(value, 0, 100);
        }
    }

    private static int energy = 50;
    public static int Energy
    {
        get => energy;
        set
        {
            energy = Mathf.Clamp(value, 0, 100);
        }
    }

    private static int health = 50;
    public static int Health
    {
        get => health;
        set
        {
            health = Mathf.Clamp(value, 0, 100);
        }
    }
    #endregion


    [SerializeField] private Slider sliderHunger;
    [SerializeField] private Slider sliderEnergy;
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
