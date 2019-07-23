using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClubFollower : MonoBehaviour {

    GameObject target;
    public Rigidbody rb;
    Vector3 previous;

    public Vector3 offset;

	// Use this for initialization
	void Start ()
    {
        //gameObject.GetComponent<Renderer>().enabled = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        rb.position = new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z);// + offset;
        rb.rotation = target.transform.rotation;
        rb.rotation *= Quaternion.Euler(90, 0, 0);
        rb.velocity = ((rb.position - previous)) / Time.deltaTime;

        previous = rb.position;
    }

    public void FollowTarget(GameObject target)
    {
        this.target = target;
    }
}
