using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class ExitGame : MonoBehaviour
{
    void Update()
    {
        if (CrossPlatformInputManager.GetButtonDown("Cancel"))
        {
            Application.Quit();
        }
    }
}
