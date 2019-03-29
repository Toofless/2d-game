using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float speed = 40f;
    private Rigidbody2D rb2d;
    float moveHorz = 0f;
    Animator anim;
    SpriteRenderer flip;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        flip = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        moveHorz = Input.GetAxisRaw("Horizontal") * speed;
    }
    void FixedUpdate()
    {
        float moveVert = Input.GetAxisRaw("Vertical");
        Vector2 movement = new Vector2(moveHorz, moveVert);
        rb2d.AddForce(movement * speed);

        //Ensure that we move the same amount no matter how often it's called
        //controller.Move(moveHorz * Time.fixedDeltaTime, false, false);

        //Flips animation direction
        if ((Input.GetKey(KeyCode.D)) || (Input.GetKey(KeyCode.A)))
        {
            if (Input.GetKey(KeyCode.A))
            {
                flip.flipX = true;
            }
            if (Input.GetKey(KeyCode.D))
            {
                flip.flipX = false;
            }
            anim.SetBool("IsRunning", true);
            anim.SetBool("IsIdle", false);
        }
        else
        {
            anim.SetBool("IsRunning", false);
            anim.SetBool("IsIdle", true);
        }
    }
}
