using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsInteraction : MonoBehaviour
{
    private Player player = new Player();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlusTenHealth()
    {
        player.Health += 10;
    }

    public void MinusTenHealth()
    {
        player.Health -= 10;
    }

    public void PlusTenHunger()
    {
        player.Hunger += 10;
    }

    public void MinusTenHunger()
    {
        player.Hunger -= 10;
    }

    public void PlusTenEnergy()
    {
        player.Energy += 10;
    }

    public void MinusTenEnergy()
    {
        player.Energy -= 10;
    }
}
