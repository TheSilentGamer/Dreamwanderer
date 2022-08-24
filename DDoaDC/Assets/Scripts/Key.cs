using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{


        public KeyCount KC;

    // Start is called before the first frame update
    void Start()
    {

      //  KeyCount.GetComponent<KeyNumber
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            KC.KeyNumbers = KC.KeyNumbers + 1;
            gameObject.SetActive(false);
        }
       
    }
    // Update is called once per frame
    void Update()
    {
        if (KC.KeyNumbers > 99)
        {
            KC.KeyNumbers = 99;
        }
            
            
    }
}
