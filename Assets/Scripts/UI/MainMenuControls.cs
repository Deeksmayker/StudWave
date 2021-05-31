using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuControls : MonoBehaviour
{
    public void NewGamePressed()
    {
        SceneManager.LoadScene(1);
    }
}
