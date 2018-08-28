using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour {


    public GameObject guiCanvas, titleText, interactText, progressBar;

    private PlayerController playerController;

    private bool inZone = false;


    void Start ()
    {
        guiCanvas.SetActive(false);
        playerController = FindObjectOfType<PlayerController>();
	}
	
	void Update ()
    {

        if (Input.GetKey(KeyCode.E) && inZone==true)
        {
            //FREEZE PLAYER
            playerController.myRigidBody.constraints = RigidbodyConstraints2D.FreezeAll;
            playerController.canMove = false;


            //FILL BAR
            progressBar.SetActive(true);
            interactText.SetActive(false);
            GameControl.control.tumblerProgress.CurrentVal += 25 * Time.deltaTime;
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            //RESET BAR
            GameControl.control.tumblerProgress.CurrentVal = 0;

            //UNFREEZE PLAYER
            playerController.myRigidBody.constraints = RigidbodyConstraints2D.None;
            playerController.myRigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;
            playerController.canMove = true;

        }
	}


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag=="Player")
        {
            inZone = true;

            if (inZone== true)
            {
                guiCanvas.SetActive(true);
                titleText.SetActive(true);
                interactText.SetActive(true);
                progressBar.SetActive(false);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            inZone = false;

            guiCanvas.SetActive(false);
            titleText.SetActive(false);
            interactText.SetActive(false);
            progressBar.SetActive(false);

        }
    }
}
