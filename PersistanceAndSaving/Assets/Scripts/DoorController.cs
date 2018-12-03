using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DoorController : InteractiveObject {

    public bool isOpen = false;
    public float OpenYRotation = 90;
    public Transform Pivot;
    NavMeshObstacle navObstacle;

	// Use this for initialization
	void Start ()
    {
        navObstacle = GetComponent<NavMeshObstacle>();	
	}
	
	// Update is called once per frame
	void Update ()
    {
	    	
	}
}
