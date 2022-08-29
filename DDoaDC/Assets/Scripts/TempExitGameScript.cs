using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempExitGameScript : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
