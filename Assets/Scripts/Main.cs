using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        #if UNITY_ANDROID
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
        QualitySettings.antiAliasing = 0;
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        #endif
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
