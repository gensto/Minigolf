using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Club : MonoBehaviour
{

    public GameObject clubFollower;
    public Rigidbody rb;

    //club follower prefab with a ClubFollower script attached to it
    public ClubFollower clubFollowerPrefab;
        
	// Use this for initialization
	void Start ()
    {
        ClubFollower cF = Instantiate(clubFollowerPrefab);
        cF.FollowTarget(this.gameObject);
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
