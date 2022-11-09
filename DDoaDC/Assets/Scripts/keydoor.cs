using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class keydoor : MonoBehaviour
{
    AudioSource m_DoorOpen;
    bool m_Play;

    public KeyCount KC;
    public int KeyGoal = 5;

    public Sprite[] DoorSprite;
    bool startDelete;

    // Start is called before the first frame update
    void Start()
    {
        m_DoorOpen = GetComponent<AudioSource>();
        SpriteUpdate();
        m_Play = true;
    }

    // Update is called once per frame
    void Update()
    {

        SpriteUpdate();

        if (KC.KeyNumbers == KeyGoal && !startDelete)
        {
            Debug.Log("OPEN");
            m_DoorOpen.Play();
            StartCoroutine(SelfDelete());
        }

    }

    public void SpriteUpdate()
    {
     
        GetComponent<SpriteRenderer>().sprite = DoorSprite[KeyGoal - KC.KeyNumbers];
    }

    IEnumerator SelfDelete()
    {
        startDelete = true;
        yield return new WaitForSeconds(2);

        gameObject.SetActive(false);
        KC.KeyNumbers = 0;
    }
}
