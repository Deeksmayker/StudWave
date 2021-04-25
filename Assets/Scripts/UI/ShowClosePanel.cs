using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowClosePanel : MonoBehaviour
{
    public static void LayoutInteract(GameObject layout)
    {
        layout.gameObject.SetActive(!layout.active);
    }
}
