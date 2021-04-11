using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowClosePanel : MonoBehaviour
{
    public GameObject layout;
    private bool isLayoutClose = true;

    public void LayoutInteract()
    {
        if (isLayoutClose)
            layout.gameObject.SetActive(true);
        else
            layout.gameObject.SetActive(false);
        isLayoutClose = !isLayoutClose;
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
