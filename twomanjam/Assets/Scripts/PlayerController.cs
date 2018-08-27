using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {


    private Animator anim;
    private Rigidbody2D myRigidBody;
    private SpriteRenderer playerSprite;

    [HideInInspector]
    public bool isMoving;

    [HideInInspector]
    public bool canMove = true;
    public float movementSpeed;

    [HideInInspector]
    public float startMovementSpeed;

    [HideInInspector]
    public string playerNumber;
    public bool inputSelection; //true represents 'controller, false represents 'keyboard'.
    private GameObject weaponContainer;




    void Start ()
    {
        startMovementSpeed = movementSpeed;
        anim = GetComponentInChildren<Animator>();
        myRigidBody = GetComponent<Rigidbody2D>();
        playerSprite = GetComponentInChildren<SpriteRenderer>();
    }
	

	void Update ()
    {
        isMoving = false;

        //Rotate the playersprite, depending on direction
        //Skal måske gøres en del anderledes- læs:      Flips the sprite on the X axis. Only the rendering is affected. Use negative Transform.scale, if you want to affect all the other components (for example colliders).
		if (myRigidBody.velocity.x <= -0.15f)
        {
            playerSprite.flipX = true;
        }
		else if (myRigidBody.velocity.x >= 0.15f)
        {
            playerSprite.flipX = false;
        }


        if (canMove)
        {
            //If using a Keyboard:
            if (!inputSelection)
            {
                //SIDEWAYSMOVEMENT with KEYBOARD
                if (Input.GetAxisRaw("Horizontal") > 0.15f || Input.GetAxisRaw("Horizontal") < -0.15f)
                {
                        myRigidBody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * movementSpeed, myRigidBody.velocity.y);
                        isMoving = true;
                }
                //STOP GLIDING SIDEWAYS with KEYBOARD
                if (Input.GetAxisRaw("Horizontal") < 0.15f && Input.GetAxisRaw("Horizontal") > -0.15f)
                {
                    myRigidBody.velocity = new Vector2(0f, myRigidBody.velocity.y);
                }



                //UP- AND DOWNWARDS MOVEMENT with KEYBOARD
                if (Input.GetAxisRaw("Vertical") > 0.15f || Input.GetAxisRaw("Vertical") < -0.15f)
                {
                        myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, Input.GetAxisRaw("Vertical") * (movementSpeed));
                        isMoving = true;
                }
                //STOP GLIDING UP AND DOWN with KEYBOARD
                if (Input.GetAxisRaw("Vertical") < 0.15f && Input.GetAxisRaw("Vertical") > -0.15f)
                {
                    myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, 0f);
                }

              //  anim.SetBool("PlayerMoving", isMoving);
            }
        }
    }
}
