using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private const float coef = 0.5f;


	private void Awake ()
    {
        GameControl.control.health.Initialize();
        GameControl.control.bladder.Initialize();
        GameControl.control.energy.Initialize();
    }

    private IEnumerator Rest()
    {
        GetComponent<PlayerController>().canMove = false;
        yield return new WaitForSecondsRealtime(5);
        GetComponent<PlayerController>().canMove = true;
    }

	void Update ()
    {

        GameControl.control.bladder.CurrentVal -= coef * Time.deltaTime;
        GameControl.control.energy.CurrentVal -= coef * Time.deltaTime;

        if (GameControl.control.energy.CurrentVal <= 0)
        {
            StartCoroutine(Rest());
            GameControl.control.energy.CurrentVal = GameControl.control.energy.MaxVal;
        }

        if (GameControl.control.bladder.CurrentVal <= 0)
        {
            StartCoroutine(Rest());
            GameControl.control.bladder.CurrentVal = GameControl.control.bladder.MaxVal;
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            GameControl.control.energy.CurrentVal -= 10;
        }
        /*
        if (Input.GetKeyDown(KeyCode.W))
        {
            GameControl.control.health.CurrentVal += 8;
            GameControl.control.bladder.CurrentVal -= 12;
            GameControl.control.energy.CurrentVal += 3;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            GameControl.control.health.CurrentVal += 2;
            GameControl.control.bladder.CurrentVal += 7;
            GameControl.control.energy.CurrentVal -= 14;
        }
        */

        if (Input.GetKeyDown(KeyCode.K))
        {
            GameControl.control.Save();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            GameControl.control.Load();
        }
    }
}
