using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsInteraction : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public static void PlusTenHealth()
    {
        Player.Health += 10;
    }

    public static void MinusTenHealth()
    {
        Player.Health -= 10;
    }

    public static void PlusTenHunger()
    {
        Player.Hunger += 10;
    }

    public static void MinusTenHunger()
    {
        Player.Hunger -= 10;
    }

    public static void PlusTenEnergy()
    {
        Player.Energy += 10;
    }

    public static void MinusTenEnergy()
    {
        Player.Energy -= 10;
    }
}
