using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    


	private void Awake ()
    {
        GameControl.control.health.Initialize();
        GameControl.control.bladder.Initialize();
        GameControl.control.energy.Initialize();
    }
	

	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            GameControl.control.health.CurrentVal -= 10;
            GameControl.control.bladder.CurrentVal += 5;
        }

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
