using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionController : MonoBehaviour
{

    public GameObject golfer;
    public GameObject ball;
    public Vector3 offset;
    public bool isRotating = true;

	// Use this for initialization
	void Start ()
    {
        gameObject.transform.rotation *= Quaternion.Euler(0, -90, 0);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(isRotating)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.RotateAround(ball.transform.position, Vector3.up, Time.deltaTime * 90f);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.RotateAround(ball.transform.position, Vector3.up, Time.deltaTime * -90f);
            }
        }

        gameObject.transform.position = ball.transform.position + offset;
    }

    public void ballObject(GameObject ball)
    {
        this.ball = ball;
    }
}
