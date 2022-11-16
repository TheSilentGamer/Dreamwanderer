using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallax : MonoBehaviour
{
    public float moveSpeed = 0;
    public bool HorizontalIsPressed;
    public bool VerticalIsPressed;
    public bool HorizontalDown;
    public bool VerticalDown;
    public float ParralaxDenominator = 0

    TileBasedMovement2 playerController;
    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.FindObjectOfType<TileBasedMovement2>().GetComponent<TileBasedMovement2>();
        moveSpeed = playerController.moveSpeed / 3;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position;
    
    }
}
