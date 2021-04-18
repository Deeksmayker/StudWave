using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowClosePanel : MonoBehaviour
{
    public GameObject layout;
    private bool isLayoutOpen = false;

    public void LayoutInteract()
    {
        layout.gameObject.SetActive(!isLayoutOpen);
        isLayoutOpen = !isLayoutOpen;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
