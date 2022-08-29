using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class keydoor : MonoBehaviour
{
    public KeyCount KC;
    public int KeyGoal = 5;

    public Sprite[] DoorSprite;

    // Start is called before the first frame update
    void Start()
    {
        SpriteUpdate();
    }

    // Update is called once per frame
    void Update()
    {
        SpriteUpdate();

        if (KC.KeyNumbers == KeyGoal)
        {
            gameObject.SetActive(false);
            KC.KeyNumbers = 0;
        }

    }

    public void SpriteUpdate()
    {
        GetComponent<SpriteRenderer>().sprite = DoorSprite[KeyGoal - KC.KeyNumbers];
    }
}
