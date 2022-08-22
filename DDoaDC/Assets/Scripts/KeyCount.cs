using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class KeyCount : MonoBehaviour
{
    public Text keyCount;
    public static int KeyNumbers;
    // Start is called before the first frame update
    void Start()
    {
        KeyNumbers = 0;
    }

    // Update is called once per frame
    void Update()
    {
        keyCount.text = KeyNumbers.ToString("0");
    }
}
