using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField]
    private Stats health, bladder, energy;


	private void Awake ()
    {
        health.Initialize();
        bladder.Initialize();
        energy.Initialize();
    }
	

	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            health.CurrentVal -= 10;
            bladder.CurrentVal += 5;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            health.CurrentVal += 8;
            bladder.CurrentVal -= 12;
            energy.CurrentVal += 3;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            health.CurrentVal += 2;
            bladder.CurrentVal += 7;
            energy.CurrentVal -= 14;
        }
    }
}
