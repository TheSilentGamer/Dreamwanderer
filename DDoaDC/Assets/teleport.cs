using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleport : MonoBehaviour
{
    private GameObject currentTeleporer;
    public Transform teleportPoint;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("E");
            if (currentTeleporer != null)
            {
                transform.position = currentTeleporer.GetComponent<Teleporter>().GetDestination().position;
                GameObject obj = GameObject.FindGameObjectWithTag("TestObject");
                
                    obj.transform.position = teleportPoint.transform.position;
                
            }
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Teleporter"))
        {
            currentTeleporer = collision.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Teleporter"))
        {
            if (collision.gameObject == currentTeleporer)
            {
                currentTeleporer = null;
            }
        }
    }
}
