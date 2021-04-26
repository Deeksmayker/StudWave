using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Win32.SafeHandles;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    #region perks

    private static int knowledgeXP;

    public static int KnowledgeXP
    {
        get => knowledgeXP;
        set
        {
            if (value / 5 > KnowledgeLevel)
                InfoPanelScript.PerkIncreaseInfo("Ёнциклопедические знани€", KnowledgeLevel + (value / 5));
            knowledgeXP = Mathf.Clamp(value, 0, 100);
        }
    }

    public static int KnowledgeLevel
    {
        get => knowledgeXP / 5;
    }

    private static int physicalXP;

    public static int PhysicalXP
    {
        get => physicalXP;
        set => physicalXP = Mathf.Clamp(value, 0, 100);
    }

    public static int PhysicalLevel
    {
        get => physicalXP / 5;
    }

    private static int charismaXP;

    public static int CharismaXP
    {
        get => charismaXP;
        set => charismaXP = Mathf.Clamp(value, 0, 100);
    }

    public static int CharismaLevel
    {
        get => charismaXP / 5;
    }

    private static int studWaveXP;

    public static int StudWaveXP
    {
        get => studWaveXP;
        set => studWaveXP = Mathf.Clamp(value, 0, 100);
    }

    public static int StudWaveLevel
    {
        get => studWaveXP / 5;
    }

    private static int techXP;

    public static int TechXP
    {
        get => techXP / 5;
        set => techXP = Mathf.Clamp(value, 0, 100);
    }

    public static int TechLevel
    {
        get => techXP / 5;
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

    private static int study = 50;

    public static int Study
    {
        get => study;
        set
        {
            study = Mathf.Clamp(value, 0, 100);
        }
    }

    private static int mood = 50;

    public static int Mood
    {
        get => mood;
        set => mood = Mathf.Clamp(value, 0, 100);
    }
    #endregion


    [SerializeField] private Slider sliderHunger;
    [SerializeField] private Slider sliderEnergy;
    [SerializeField] private Slider sliderHealth;
    [SerializeField] private Slider sliderMood;
    [SerializeField] private Slider sliderStudy;

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
        sliderMood.value = mood;
        sliderStudy.value = study;
    }
}
