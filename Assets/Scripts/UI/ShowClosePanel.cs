using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowClosePanel : MonoBehaviour
{
    public static GameObject layout;
    private static bool isLayoutOpen = false;

    public static void LayoutInteract(GameObject layout)
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
