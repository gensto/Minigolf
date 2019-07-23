using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalDetector : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision obj)
    {
        if(obj.gameObject.tag == "Ball")
        {
            Debug.Log("GOAL!!");
        }
    }
}
