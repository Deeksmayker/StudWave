using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Win32.SafeHandles;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public static Player Instance = new Player();


    #region perks

    private int knowledgeXP;

    public int KnowledgeXP
    {
        get => knowledgeXP;
        set
        {
            if (value / 5 > KnowledgeLevel)
                InfoPanelScript.PerkIncreaseInfo("????????????????? ??????", KnowledgeLevel + (value / 5));
            knowledgeXP = Mathf.Clamp(value, 0, 100);
        }
    }

    public int KnowledgeLevel
    {
        get => knowledgeXP / 5;
    }

    private int physicalXP;

    public int PhysicalXP
    {
        get => physicalXP;
        set
        {
            if (value / 5 > PhysicalLevel)
                InfoPanelScript.PerkIncreaseInfo("?????????? ??????????", PhysicalLevel + (value / 5));
            physicalXP = Mathf.Clamp(value, 0, 100);
        }
    }

    public int PhysicalLevel
    {
        get => physicalXP / 5;
    }

    private int charismaXP;

    public int CharismaXP
    {
        get => charismaXP;
        set
        {
            if (value / 5 > CharismaLevel)
                InfoPanelScript.PerkIncreaseInfo("???????", CharismaLevel + (value / 5));
            charismaXP = Mathf.Clamp(value, 0, 100);
        }
    }

    public int CharismaLevel
    {
        get => charismaXP / 5;
    }

    private int studWaveXP;

    public int StudWaveXP
    {
        get => studWaveXP;
        set
        {
            if (value / 5 > StudWaveLevel)
                InfoPanelScript.PerkIncreaseInfo("???????????? ?????", StudWaveLevel + (value / 5));
            studWaveXP = Mathf.Clamp(value, 0, 100);
        }
    }

    public int StudWaveLevel
    {
        get => studWaveXP / 5;
    }

    private int techXP;

    public int TechXP
    {
        get => techXP / 5;
        set
        {
            if (value / 5 > TechLevel)
                InfoPanelScript.PerkIncreaseInfo("?????????? ??????????", TechLevel + (value / 5));
            techXP = Mathf.Clamp(value, 0, 100);
        }
    }

    public int TechLevel
    {
        get => techXP / 5;
    }

    #endregion

    #region stats
    private int hunger = 50;
    public int Hunger
    {
        get => hunger;
        set
        {
            hunger = Mathf.Clamp(value, 0, 100);
        }
    }

    private int energy = 50;
    public int Energy
    {
        get => energy;
        set
        {
            energy = Mathf.Clamp(value, 0, 100);
        }
    }

    private int health = 50;
    public int Health
    {
        get => health;
        set
        {
            health = Mathf.Clamp(value, 0, 100);
        }
    }

    private int study = 50;

    public int Study
    {
        get => study;
        set
        {
            study = Mathf.Clamp(value, 0, 100);
        }
    }

    private int mood = 50;

    public int Mood
    {
        get => mood;
        set => mood = Mathf.Clamp(value, 0, 100);
    }

    private int money = 10000;

    public int Money
    {
        get => money;
        set => money = value;
    }

    #endregion
}
