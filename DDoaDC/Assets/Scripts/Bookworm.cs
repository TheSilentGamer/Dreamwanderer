using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bookworm : MonoBehaviour
{
    public bool inRange = false;
    SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        sr.color = RandomColor();
    }
    Color RandomColor()
    {
        return new Color(Random.value, Random.value, Random.value);
    }
    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.Z) && inRange)
        {

            sr.color = RandomColor();
        }

    }
    private void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("No triggers?");

        sr = GetComponent<SpriteRenderer>();
        if (other.gameObject.tag == "Player")
        {
            inRange = true;

            //  if (Input.GetKeyDown("Z"))
            //   {
            //       sr.color = RandomColor();
            //   }

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            inRange = false;

    

        }
    }
}
