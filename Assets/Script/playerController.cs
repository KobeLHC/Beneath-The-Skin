using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D body;

    float horizontal;
    float vertical;
    float moveLimiter = 0.7f;

    public float runSpeed = 8.0f;
    public int susLevel = 0;

    //Change Sprite
    private SpriteRenderer spriteRenderer;
    public Sprite newSprite;
    public Sprite basicSprite;

    //which shape to change
    private bool sciOn;

    //Animation
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        sciOn = false;
    }

    void Update()
    {
        // Gives a value between -1 and 1
        horizontal = Input.GetAxisRaw("Horizontal"); // -1 is left | 1 is right
        vertical = Input.GetAxisRaw("Vertical"); // -1 is down | 1 is up

        //shape shift
        if(Input.GetKeyDown(KeyCode.C) == true)
        {
            if (sciOn == true)
            {
                ChangePlayerSci();
            }

            else
            {
                Debug.Log("No collision yet");
            }
        }
    }

    void FixedUpdate()
    {
        if (horizontal != 0 && vertical != 0) // Check for diagonal movement
        {
            // limit movement speed diagonally, so you move at 70% speed
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        }

        body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
    }

    public void moreSus(int value)
    {
        susLevel += value;
    }

    public void lessSus(int value)
    {
        susLevel -= value;
    }

    public void ChangePlayerSci()
    {
        if (anim.GetBool("changeSci") == false)
        {
            spriteRenderer.sprite = newSprite;
            anim.SetBool("changeSci", true);
        }

        else
        {
            spriteRenderer.sprite = basicSprite;
            anim.SetBool("changeSci", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //control which sprite to change into
        if(collision.gameObject.tag == "Sci")
        {
            sciOn = true;
        }
    }
}
