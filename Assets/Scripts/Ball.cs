using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour {

    public Rigidbody rb;
    public GameObject dC;
    public GameObject dcObj;
    public bool isHit = false;
    public float powerScale = 4;
    public bool hasScored = false;
    public Text goalText;

	// Use this for initialization
	void Start () {
        spawnDC();
    }
	
	// Update is called once per frame
	void Update () {

	}

    void OnCollisionEnter(Collision obj)
    {
        if(obj.gameObject.tag == "ClubFollower")
        {
            Debug.Log("Hit the ball");
            //rb.velocity = new Vector3(-6, 0, 0);
            rb.velocity = obj.rigidbody.velocity * (10*powerScale);
            Destroy(dcObj);
            isHit = true;
        }
        if (obj.gameObject.tag == "Goal")
        {
            hasScored = true;
            Debug.Log("Goal!");
            goalText.GetComponent<Text>().enabled = true;
        }
    }

    public void spawnDC()
    {
        dcObj = Instantiate(dC);
        dcObj.GetComponent<DirectionController>().ballObject(this.gameObject);
    }
}
