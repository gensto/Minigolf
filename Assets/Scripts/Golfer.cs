using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Golfer : MonoBehaviour {

    public GameObject ball;
    public GameObject cam;
    public Rigidbody golfer;
    float angle = 1.0f;
    public Animator anim;
    public Vector3 offset;
    public bool isRotating = true;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        ball = GameObject.Find("Ball");
        cam = GameObject.Find("Main Camera");
        gameObject.transform.position = new Vector3(ball.transform.position.x, ball.transform.position.y, ball.transform.position.z) + offset;
    }
	
	// Update is called once per frame
	void Update () {

        //gameObject.transform.position = new Vector3(ball.transform.position.x, ball.transform.position.y, ball.transform.position.z) + offset;

        //transform.RotateAround(ball.transform.position, Vector3.up, angle + 0.1f);
        if (isRotating)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                //transform.RotateAround(ball.transform.position, Vector3.up, angle + 0.5f);
                transform.RotateAround(ball.transform.position, Vector3.up, Time.deltaTime * 90f);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.RotateAround(ball.transform.position, Vector3.up, Time.deltaTime * -90f);
            }
            if (Input.GetKey(KeyCode.Space))
            {
                isRotating = false;
                GameObject.Find("Power").GetComponent<PowerController>().stopMeter = false;
                GameObject.Find("Direction(Clone)").GetComponent<DirectionController>().isRotating = false;
                GameObject.Find("AngleInstructions").GetComponent<Text>().enabled = false;
                GameObject.Find("PowerMeterInstructions").GetComponent<Text>().enabled = true;
                //anim.SetBool("isPutting", true);
            }
        }
    }

    public void repositionGolfer()
    {
        anim.Play("Idle", -1, 0.0f);
        anim.SetBool("isPutting", false);
        gameObject.transform.position = new Vector3(ball.transform.position.x, ball.transform.position.y, ball.transform.position.z) + offset;
        gameObject.transform.eulerAngles = new Vector3(0, -90, 0);
        ball.GetComponent<Ball>().spawnDC();
    }
}
