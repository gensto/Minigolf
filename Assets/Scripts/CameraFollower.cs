using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public GameObject ball;
    public Transform target;
    public Transform goal;
    public GameObject golfer;

    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    Vector3 rotOffset;
    Vector3 defaultPos;
    Quaternion defaultRot;

	// Use this for initialization
    void Start()
    {
        transform.position = ball.transform.position + offset;
        rotOffset = offset;
        defaultPos = transform.position;
        defaultRot = transform.rotation;
    }
	void LateUpdate()
    {
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            rotOffset = Quaternion.AngleAxis(Time.deltaTime*-90.0f, Vector3.up) * rotOffset;
            transform.position = ball.transform.position + rotOffset;
            transform.LookAt(ball.transform.position);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rotOffset = Quaternion.AngleAxis(Time.deltaTime * 90.0f, Vector3.up) * rotOffset;
            transform.position = ball.transform.position + rotOffset;
            transform.LookAt(ball.transform.position);
        }
        transform.position = ball.transform.position + rotOffset;
    }

    public void resetCamera()
    {
        transform.position = target.position + offset;
        rotOffset = offset;
        transform.rotation = defaultRot;
    }
}
