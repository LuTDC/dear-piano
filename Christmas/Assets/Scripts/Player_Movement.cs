using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public Rigidbody2D rigidBody;
    public float speed = 5f;
    public float move_horizontal;
    public float move_vertical;
    public Animator playerAnimation;
    public bool idea = false;
    public Vector2 checkpoint;
    public Animator panel;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        playerAnimation = GetComponent<Animator>();
        checkpoint = transform.position;
        panel.SetTrigger("swat");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        move_horizontal = Input.GetAxis ("Horizontal");
        rigidBody.velocity = new Vector2(move_horizontal * speed, rigidBody.velocity.y);

        move_vertical = Input.GetAxis ("Vertical");
        rigidBody.velocity = new Vector2(rigidBody.velocity.x, move_vertical * speed);

        playerAnimation.SetFloat("speed_horizontal", rigidBody.velocity.x);
        playerAnimation.SetFloat("speed_vertical", rigidBody.velocity.y);
        playerAnimation.SetFloat("speed", Mathf.Abs(rigidBody.velocity.magnitude * speed));
        //if(playerAnimation.speed > 0f) playerAnimation.SetBool("hug", false);

        if(Input.GetKey(KeyCode.LeftShift)) speed = 10f;
        else speed = 5f;
    }
}
