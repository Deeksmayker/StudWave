using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Model;
using UnityEngine;

public class PanelTrigger : MonoBehaviour
{
    public GameObject Panel;
    public string Key;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter()
    {
        var branch = new ChoiceBranches(Panel, Key);
    }
}
